using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Quezacotl
{
    public partial class Form1 : Form
    {
        public static bool _loaded = false;
        private string _existingFilename;
        private string _backup;
        private const byte _bp_numerical = 0x00;
        private const byte _bp_checked = 0x01;
        private const byte _bp_string = 0x02;

        public Form1()
        {
            InitializeComponent();

            buttonSave.Enabled = false;
            buttonDeleteTooltips.Enabled = false;

            _backup = $"{AppDomain.CurrentDomain.BaseDirectory}\\tooltips.bin";
            if (File.Exists(_backup))
            {
                buttonDeleteTooltips.Enabled = true;
            }

            #region GFs event handlers

            textBoxGfName.TextChanged += (sender, args) => InitWorker.UpdateVariable_GF(0, textBoxGfName.Text);
            numericUpDownGfExp.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(1, numericUpDownGfExp.Value);
            hexUpDownGfUnknown.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(2, hexUpDownGfUnknown.Value);
            checkBoxGfAvailable.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(3, 0x01);
            numericUpDownGfHp.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(4, numericUpDownGfHp.Value);
            numericUpDownGfKills.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, numericUpDownGfKills.Value);
            numericUpDownGfKOs.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, numericUpDownGfKOs.Value);
            comboBoxGfLearningAbility.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, comboBoxGfLearningAbility.SelectedIndex);

            #endregion
        }

        #region Listview selection style

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        internal static extern int SetWindowTheme(IntPtr hWnd, string appName, string partList);

        // You can subclass ListView and override this method
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(listViewCharactersList.Handle, "explorer", null);
            SetWindowTheme(listViewGfList.Handle, "explorer", null);
        }

        #endregion

        #region Open and Save

        private async void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open FF8 init.out";
            openFileDialog.Filter = "FF8 Init File|*.out";
            openFileDialog.FileName = "init.out";

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            {
                try
                {
                    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var BR = new BinaryReader(fileStream))
                        {
                            InitWorker.ReadInit(BR.ReadBytes((int)fileStream.Length));
                        }
                        CreateTooltipsFile();
                    }

                    _existingFilename = openFileDialog.FileName;

                    buttonSave.Enabled = true;


                    toolStripStatusLabelStatus.Text = Path.GetFileName(_existingFilename) + " loaded successfully";
                    toolStripStatusLabelInit.Text = Path.GetFileName(_existingFilename) + " loaded";
                    statusStrip.BackColor = Color.FromArgb(255, 237, 110, 0);
                    toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 237, 110, 0);
                    await Task.Delay(3000);
                    statusStrip.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.Text = "Ready";
                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot open the file {0}, maybe it's locked by another software?", Path.GetFileName(openFileDialog.FileName)), "Error Opening File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }


        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(_existingFilename)) && InitWorker.Init != null)
            {
                try
                {
                    File.WriteAllBytes(_existingFilename, InitWorker.Init);

                    statusStrip.BackColor = Color.FromArgb(255, 237, 110, 0);
                    toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 237, 110, 0);
                    toolStripStatusLabelStatus.Text = Path.GetFileName(_existingFilename) + " saved successfully";
                    await Task.Delay(3000);
                    statusStrip.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.Text = "Ready";
                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot save the file {0}, maybe it's locked by another software?", Path.GetFileName(_existingFilename)), "Error Saving File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        #endregion

        #region Tooltips file

        private void CreateTooltipsFile()
        {
            if (!File.Exists(_backup))
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to create a copy of this init.out file " +
                    "to show default values tooltips?", "Create tooltips file",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.Yes)
                {
                    File.WriteAllBytes(_backup, InitWorker.Init);
                    InitWorker.BackupInit = File.ReadAllBytes(_backup);
                    File.SetAttributes(_backup, FileAttributes.ReadOnly);
                    MessageBox.Show("The file has been created successfully in the same folder of Quezacotl.exe.",
                        "Tooltips file created", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    toolStripStatusLabelTooltips.Text = Path.GetFileName(_backup) + " loaded";
                    buttonDeleteTooltips.Enabled = true;
                }

                else if (dialogResult == DialogResult.No)
                {
                    DialogResult dialogResult2 = MessageBox.Show("Do you want to point me to another init.out file?" +
                        "\nIf you answer no the file will be created from the init.out you opened previously.", "Create tooltips file",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Title = "Open FF8 init.out";
                        openFileDialog.Filter = "FF8 Init File|*.out";
                        openFileDialog.FileName = "init.out";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                            {
                                using (var BR = new BinaryReader(fileStream))
                                {
                                    InitWorker.ReadInit(BR.ReadBytes((int)fileStream.Length));
                                    File.WriteAllBytes(_backup, InitWorker.Init);
                                    InitWorker.BackupInit = File.ReadAllBytes(_backup);
                                    File.SetAttributes(_backup, FileAttributes.ReadOnly & FileAttributes.Hidden);
                                }
                            }
                            MessageBox.Show("The file has been created successfully in the same folder of Quezacotl.exe.\nQuezacotl will now restart.",
                                "Tooltips file created", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            Process.Start(Application.ExecutablePath);
                            Environment.Exit(0);
                        }
                        else
                        {
                            File.WriteAllBytes(_backup, InitWorker.Init);
                            InitWorker.BackupInit = File.ReadAllBytes(_backup);
                            MessageBox.Show("The file has created in the same folder of Quezacotl.exe from the init.out you opened previously.",
                                "Tooltips file created", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            toolStripStatusLabelTooltips.Text = Path.GetFileName(_backup) + " loaded";
                            buttonDeleteTooltips.Enabled = true;
                        }
                    }

                    else if (dialogResult2 == DialogResult.No)
                    {
                        File.WriteAllBytes(_backup, InitWorker.Init);
                        InitWorker.BackupInit = File.ReadAllBytes(_backup);
                        File.SetAttributes(_backup, FileAttributes.ReadOnly & FileAttributes.Hidden);
                        MessageBox.Show("The file has been created successfully in the same folder of Quezacotl.exe.",
                            "Tooltips file created", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                        toolStripStatusLabelTooltips.Text = Path.GetFileName(_backup) + " loaded";
                        buttonDeleteTooltips.Enabled = true;
                    }
                }
            }


            else
            {
                InitWorker.BackupInit = File.ReadAllBytes(_backup);
                toolStripStatusLabelTooltips.Text = Path.GetFileName(_backup) + " loaded";
            }



        }

        private void deleteTooltipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will delete the tooltips.out file. " +
                "Quezacotl will restart and unsaved changes will be lost, do you want to continue?",
                "Delete tooltips file", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    File.SetAttributes(_backup, FileAttributes.Normal);
                    File.Delete(_backup);

                    DialogResult dialogResult2 = MessageBox.Show("The tooltips.out file was deleted.\nQuezacotl will now restart.",
                        "Toltips file deleted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }

                catch
                {
                    DialogResult dialogResult2 = MessageBox.Show("Sorry, i wasn't able to delete the tooltips.out file.\nTry to delete it manually.",
                        "Failed to delete", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                    if (!File.Exists(_backup))
                    {
                        buttonDeleteTooltips.Enabled = false;
                    }
                }
            }
        }

        #endregion

        #region Backup Algorithm

        private void ToolTip(Control control, byte mode, object value)
        {
            switch (mode)
            {
                case _bp_numerical:
                    {
                        toolTip1.SetToolTip(control, $"Default: {Convert.ToInt32(value)}");
                        break;
                    }
                case _bp_checked:
                    {
                        string check = Convert.ToBoolean(value) ? "Checked" : "Unchecked";
                        toolTip1.SetToolTip(control, $"Default: {check}");
                        break;
                    }
                case _bp_string:
                    {
                        toolTip1.SetToolTip(control, $"Default: {Convert.ToString(value)}");
                        break;
                    }
                case 3:
                    {
                        toolTip1.SetToolTip(control, $"Default: {Convert.ToDouble(value)}");
                        break;
                    }
                default:
                    goto case _bp_numerical;
            }
        }


        #endregion

        private void listViewGfList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _loaded = false;
            if (InitWorker.Init == null || InitWorker.BackupInit == null)
                return;

            int GfList = 0;
            if (listViewGfList.SelectedItems.Count > 0)
                GfList = listViewGfList.SelectedIndices[0];

            InitWorker.ReadGF(GfList, InitWorker.BackupInit);
            try
            {
                ToolTip(numericUpDownGfExp, 0, InitWorker.GetSelectedGfData.Exp);
                ToolTip(hexUpDownGfUnknown, 0, InitWorker.GetSelectedGfData.Unknown1);
                ToolTip(checkBoxGfAvailable, 1, (InitWorker.GetSelectedGfData.Available & 0x01) >= 1 ? true : false);
                ToolTip(numericUpDownGfHp, 0, InitWorker.GetSelectedGfData.CurrentHp);
                ToolTip(numericUpDownGfKills, 0, InitWorker.GetSelectedGfData.Kills);
                ToolTip(numericUpDownGfKOs, 0, InitWorker.GetSelectedGfData.KOs);
                ToolTip(comboBoxGfLearningAbility, 2, InitWorker.GetSelectedGfData.LearningAbility);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }

            InitWorker.ReadGF(GfList, InitWorker.Init);
            try
            {
                numericUpDownGfExp.Value = InitWorker.GetSelectedGfData.Exp;
                hexUpDownGfUnknown.Value = InitWorker.GetSelectedGfData.Unknown1;
                checkBoxGfAvailable.Checked = (InitWorker.GetSelectedGfData.Available & 0x01) >= 1 ? true : false;
                numericUpDownGfHp.Value = InitWorker.GetSelectedGfData.CurrentHp;
                numericUpDownGfKills.Value = InitWorker.GetSelectedGfData.Kills;
                numericUpDownGfKOs.Value = InitWorker.GetSelectedGfData.KOs;
                comboBoxGfLearningAbility.SelectedIndex = InitWorker.GetSelectedGfData.LearningAbility;
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }
            _loaded = true;
        }
    }
}
