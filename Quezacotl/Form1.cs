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
            buttonSaveAs.Enabled = false;
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
            checkBoxGfAb001.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x01);
            checkBoxGfAb002.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x02);
            checkBoxGfAb003.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x04);
            checkBoxGfAb004.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x08);
            checkBoxGfAb005.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x10);
            checkBoxGfAb006.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x20);
            checkBoxGfAb007.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x40);
            checkBoxGfAb008.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(5, 0x80);
            checkBoxGfAb009.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x01);
            checkBoxGfAb010.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x02);
            checkBoxGfAb011.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x04);
            checkBoxGfAb012.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x08);
            checkBoxGfAb013.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x10);
            checkBoxGfAb014.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x20);
            checkBoxGfAb015.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x40);
            checkBoxGfAb016.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x80);
            checkBoxGfAb017.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x01);
            checkBoxGfAb018.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(6, 0x02);
            checkBoxGfAb019.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x04);
            checkBoxGfAb020.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x08);
            checkBoxGfAb021.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x10);
            checkBoxGfAb022.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x20);
            checkBoxGfAb023.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x40);
            checkBoxGfAb024.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x80);
            checkBoxGfAb025.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x01);
            checkBoxGfAb026.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x02);
            checkBoxGfAb027.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x04);
            checkBoxGfAb028.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x08);
            checkBoxGfAb029.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x10);
            checkBoxGfAb030.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x20);
            checkBoxGfAb031.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x40);
            checkBoxGfAb032.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(8, 0x80);
            checkBoxGfAb033.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x01);
            checkBoxGfAb034.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x02);
            checkBoxGfAb035.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x04);
            checkBoxGfAb036.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x08);
            checkBoxGfAb037.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x10);
            checkBoxGfAb038.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x20);
            checkBoxGfAb039.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x40);
            checkBoxGfAb040.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(9, 0x80);
            checkBoxGfAb041.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x01);
            checkBoxGfAb042.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x02);
            checkBoxGfAb043.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x04);
            checkBoxGfAb044.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x08);
            checkBoxGfAb045.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x10);
            checkBoxGfAb046.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x20);
            checkBoxGfAb047.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x40);
            checkBoxGfAb048.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(10, 0x80);
            checkBoxGfAb049.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x01);
            checkBoxGfAb050.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x02);
            checkBoxGfAb051.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x04);
            checkBoxGfAb052.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x08);
            checkBoxGfAb053.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x10);
            checkBoxGfAb054.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x20);
            checkBoxGfAb055.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x40);
            checkBoxGfAb056.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(11, 0x80);
            checkBoxGfAb057.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x01);
            checkBoxGfAb058.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x02);
            checkBoxGfAb059.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x04);
            checkBoxGfAb060.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x08);
            checkBoxGfAb061.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x10);
            checkBoxGfAb062.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x20);
            checkBoxGfAb063.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x40);
            checkBoxGfAb064.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(12, 0x80);
            checkBoxGfAb065.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x01);
            checkBoxGfAb066.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x02);
            checkBoxGfAb067.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x04);
            checkBoxGfAb068.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x08);
            checkBoxGfAb069.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x10);
            checkBoxGfAb070.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x20);
            checkBoxGfAb071.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x40);
            checkBoxGfAb072.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(13, 0x80);
            checkBoxGfAb073.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x01);
            checkBoxGfAb074.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x02);
            checkBoxGfAb075.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x04);
            checkBoxGfAb076.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x08);
            checkBoxGfAb077.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x10);
            checkBoxGfAb078.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x20);
            checkBoxGfAb079.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x40);
            checkBoxGfAb080.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(14, 0x80);
            checkBoxGfAb081.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x01);
            checkBoxGfAb082.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x02);
            checkBoxGfAb083.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x04);
            checkBoxGfAb084.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x08);
            checkBoxGfAb085.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x10);
            checkBoxGfAb086.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x20);
            checkBoxGfAb087.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x40);
            checkBoxGfAb088.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(15, 0x80);
            checkBoxGfAb089.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x01);
            checkBoxGfAb090.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x02);
            checkBoxGfAb091.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x04);
            checkBoxGfAb092.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x08);
            checkBoxGfAb093.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x10);
            checkBoxGfAb094.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x20);
            checkBoxGfAb095.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x40);
            checkBoxGfAb096.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(16, 0x80);
            checkBoxGfAb097.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x01);
            checkBoxGfAb098.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x02);
            checkBoxGfAb099.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x04);
            checkBoxGfAb100.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x08);
            checkBoxGfAb101.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x10);
            checkBoxGfAb102.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x20);
            checkBoxGfAb103.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x40);
            checkBoxGfAb104.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(17, 0x80);
            checkBoxGfAb105.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x01);
            checkBoxGfAb106.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x02);
            checkBoxGfAb107.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x04);
            checkBoxGfAb108.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x08);
            checkBoxGfAb109.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x10);
            checkBoxGfAb110.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x20);
            checkBoxGfAb111.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x40);
            checkBoxGfAb112.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(18, 0x80);
            checkBoxGfAb113.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x01);
            checkBoxGfAb114.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x02);
            checkBoxGfAb115.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x04);
            checkBoxGfAb116.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x08);
            checkBoxGfAb117.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x10);
            checkBoxGfAb118.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x20);
            checkBoxGfAb119.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x40);
            checkBoxGfAb120.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(19, 0x80);
            numericUpDownGfAp1.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(21, numericUpDownGfAp1.Value);
            numericUpDownGfAp2.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(22, numericUpDownGfAp2.Value);
            numericUpDownGfAp3.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(23, numericUpDownGfAp3.Value);
            numericUpDownGfAp4.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(24, numericUpDownGfAp4.Value);
            numericUpDownGfAp5.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(25, numericUpDownGfAp5.Value);
            numericUpDownGfAp6.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(26, numericUpDownGfAp6.Value);
            numericUpDownGfAp7.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(27, numericUpDownGfAp7.Value);
            numericUpDownGfAp8.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(28, numericUpDownGfAp8.Value);
            numericUpDownGfAp9.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(29, numericUpDownGfAp9.Value);
            numericUpDownGfAp10.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(30, numericUpDownGfAp10.Value);
            numericUpDownGfAp11.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(31, numericUpDownGfAp11.Value);
            numericUpDownGfAp12.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(32, numericUpDownGfAp12.Value);
            numericUpDownGfAp13.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(33, numericUpDownGfAp13.Value);
            numericUpDownGfAp14.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(34, numericUpDownGfAp14.Value);
            numericUpDownGfAp15.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(35, numericUpDownGfAp15.Value);
            numericUpDownGfAp16.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(36, numericUpDownGfAp16.Value);
            numericUpDownGfAp17.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(37, numericUpDownGfAp17.Value);
            numericUpDownGfAp18.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(38, numericUpDownGfAp18.Value);
            numericUpDownGfAp19.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(39, numericUpDownGfAp19.Value);
            numericUpDownGfAp20.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(40, numericUpDownGfAp20.Value);
            numericUpDownGfAp21.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(41, numericUpDownGfAp21.Value);
            numericUpDownGfAp22.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(42, numericUpDownGfAp22.Value);
            numericUpDownGfKills.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(43, numericUpDownGfKills.Value);
            numericUpDownGfKOs.ValueChanged += (sender, args) => InitWorker.UpdateVariable_GF(44, numericUpDownGfKOs.Value);
            comboBoxGfLearningAbility.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_GF(45, comboBoxGfLearningAbility.SelectedIndex);

            #endregion

            #region Characters event handlers

            numericUpDownCharsCurrentHp.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(0, numericUpDownCharsCurrentHp.Value);
            numericUpDownCharsHpBonus.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(1, numericUpDownCharsHpBonus.Value);
            numericUpDownCharsExp.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(2, numericUpDownCharsExp.Value);
            comboBoxCharsBody.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(3, comboBoxCharsBody.SelectedIndex);
            comboBoxCharsWeapon.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(4, comboBoxCharsWeapon.SelectedIndex);
            numericUpDownCharsStrBonus.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(5, numericUpDownCharsStrBonus.Value);
            numericUpDownCharsVitBonus.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(6, numericUpDownCharsVitBonus.Value);
            numericUpDownCharsMagBonus.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(7, numericUpDownCharsMagBonus.Value);
            numericUpDownCharsSprBonus.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(8, numericUpDownCharsSprBonus.Value);
            numericUpDownCharsSpdBonus.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(9, numericUpDownCharsSpdBonus.Value);
            numericUpDownCharsLuckBonus.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(10, numericUpDownCharsLuckBonus.Value);
            comboBoxCharsMagic1.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(11, comboBoxCharsMagic1.SelectedIndex);
            numericUpDownCharsMagicQ1.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(12, numericUpDownCharsMagicQ1.Value);
            comboBoxCharsMagic2.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(13, comboBoxCharsMagic2.SelectedIndex);
            numericUpDownCharsMagicQ2.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(14, numericUpDownCharsMagicQ2.Value);
            comboBoxCharsMagic3.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(15, comboBoxCharsMagic3.SelectedIndex);
            numericUpDownCharsMagicQ3.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(16, numericUpDownCharsMagicQ3.Value);
            comboBoxCharsMagic4.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(17, comboBoxCharsMagic4.SelectedIndex);
            numericUpDownCharsMagicQ4.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(18, numericUpDownCharsMagicQ4.Value);
            comboBoxCharsMagic5.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(19, comboBoxCharsMagic5.SelectedIndex);
            numericUpDownCharsMagicQ5.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(20, numericUpDownCharsMagicQ5.Value);
            comboBoxCharsMagic6.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(21, comboBoxCharsMagic6.SelectedIndex);
            numericUpDownCharsMagicQ6.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(22, numericUpDownCharsMagicQ6.Value);
            comboBoxCharsMagic7.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(23, comboBoxCharsMagic7.SelectedIndex);
            numericUpDownCharsMagicQ7.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(24, numericUpDownCharsMagicQ7.Value);
            comboBoxCharsMagic8.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(25, comboBoxCharsMagic8.SelectedIndex);
            numericUpDownCharsMagicQ8.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(26, numericUpDownCharsMagicQ8.Value);
            comboBoxCharsMagic9.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(27, comboBoxCharsMagic9.SelectedIndex);
            numericUpDownCharsMagicQ9.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(28, numericUpDownCharsMagicQ9.Value);
            comboBoxCharsMagic10.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(29, comboBoxCharsMagic10.SelectedIndex);
            numericUpDownCharsMagicQ10.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(30, numericUpDownCharsMagicQ10.Value);
            comboBoxCharsMagic11.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(31, comboBoxCharsMagic11.SelectedIndex);
            numericUpDownCharsMagicQ11.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(32, numericUpDownCharsMagicQ11.Value);
            comboBoxCharsMagic12.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(33, comboBoxCharsMagic12.SelectedIndex);
            numericUpDownCharsMagicQ12.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(34, numericUpDownCharsMagicQ12.Value);
            comboBoxCharsMagic13.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(35, comboBoxCharsMagic13.SelectedIndex);
            numericUpDownCharsMagicQ13.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(36, numericUpDownCharsMagicQ13.Value);
            comboBoxCharsMagic14.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(37, comboBoxCharsMagic14.SelectedIndex);
            numericUpDownCharsMagicQ14.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(38, numericUpDownCharsMagicQ14.Value);
            comboBoxCharsMagic15.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(39, comboBoxCharsMagic15.SelectedIndex);
            numericUpDownCharsMagicQ15.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(40, numericUpDownCharsMagicQ15.Value);
            comboBoxCharsMagic16.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(41, comboBoxCharsMagic16.SelectedIndex);
            numericUpDownCharsMagicQ16.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(42, numericUpDownCharsMagicQ16.Value);
            comboBoxCharsMagic17.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(43, comboBoxCharsMagic17.SelectedIndex);
            numericUpDownCharsMagicQ17.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(44, numericUpDownCharsMagicQ17.Value);
            comboBoxCharsMagic18.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(45, comboBoxCharsMagic18.SelectedIndex);
            numericUpDownCharsMagicQ18.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(46, numericUpDownCharsMagicQ18.Value);
            comboBoxCharsMagic19.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(47, comboBoxCharsMagic19.SelectedIndex);
            numericUpDownCharsMagicQ19.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(48, numericUpDownCharsMagicQ19.Value);
            comboBoxCharsMagic20.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(49, comboBoxCharsMagic20.SelectedIndex);
            numericUpDownCharsMagicQ20.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(50, numericUpDownCharsMagicQ20.Value);
            comboBoxCharsMagic21.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(51, comboBoxCharsMagic21.SelectedIndex);
            numericUpDownCharsMagicQ21.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(52, numericUpDownCharsMagicQ21.Value);
            comboBoxCharsMagic22.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(53, comboBoxCharsMagic22.SelectedIndex);
            numericUpDownCharsMagicQ22.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(54, numericUpDownCharsMagicQ22.Value);
            comboBoxCharsMagic23.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(55, comboBoxCharsMagic23.SelectedIndex);
            numericUpDownCharsMagicQ23.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(56, numericUpDownCharsMagicQ23.Value);
            comboBoxCharsMagic24.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(57, comboBoxCharsMagic24.SelectedIndex);
            numericUpDownCharsMagicQ24.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(58, numericUpDownCharsMagicQ24.Value);
            comboBoxCharsMagic25.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(59, comboBoxCharsMagic25.SelectedIndex);
            numericUpDownCharsMagicQ25.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(60, numericUpDownCharsMagicQ25.Value);
            comboBoxCharsMagic26.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(61, comboBoxCharsMagic26.SelectedIndex);
            numericUpDownCharsMagicQ26.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(62, numericUpDownCharsMagicQ26.Value);
            comboBoxCharsMagic27.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(63, comboBoxCharsMagic27.SelectedIndex);
            numericUpDownCharsMagicQ27.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(64, numericUpDownCharsMagicQ27.Value);
            comboBoxCharsMagic28.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(65, comboBoxCharsMagic28.SelectedIndex);
            numericUpDownCharsMagicQ28.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(66, numericUpDownCharsMagicQ28.Value);
            comboBoxCharsMagic29.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(67, comboBoxCharsMagic29.SelectedIndex);
            numericUpDownCharsMagicQ29.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(68, numericUpDownCharsMagicQ29.Value);
            comboBoxCharsMagic30.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(69, comboBoxCharsMagic30.SelectedIndex);
            numericUpDownCharsMagicQ30.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(70, numericUpDownCharsMagicQ30.Value);
            comboBoxCharsMagic31.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(71, comboBoxCharsMagic31.SelectedIndex);
            numericUpDownCharsMagicQ31.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(72, numericUpDownCharsMagicQ31.Value);
            comboBoxCharsMagic32.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(73, comboBoxCharsMagic32.SelectedIndex);
            numericUpDownCharsMagicQ32.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(74, numericUpDownCharsMagicQ32.Value);
            comboBoxCharsComm1.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(75, comboBoxCharsComm1.SelectedIndex);
            comboBoxCharsComm2.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(76, comboBoxCharsComm2.SelectedIndex);
            comboBoxCharsComm3.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(77, comboBoxCharsComm3.SelectedIndex);
            hexUpDownCharUnk1.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(78, hexUpDownCharUnk1.Value);
            comboBoxCharsAb1.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(79, comboBoxCharsAb1.SelectedIndex);
            comboBoxCharsAb2.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(80, comboBoxCharsAb2.SelectedIndex);
            comboBoxCharsAb3.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(81, comboBoxCharsAb3.SelectedIndex);
            comboBoxCharsAb4.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(82, comboBoxCharsAb4.SelectedIndex);
            checkBoxCharsGf1.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x01);
            checkBoxCharsGf2.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x02);
            checkBoxCharsGf3.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x04);
            checkBoxCharsGf4.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x08);
            checkBoxCharsGf5.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x10);
            checkBoxCharsGf6.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x20);
            checkBoxCharsGf7.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x40);
            checkBoxCharsGf8.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(83, 0x80);
            checkBoxCharsGf9.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x01);
            checkBoxCharsGf10.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x02);
            checkBoxCharsGf11.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x04);
            checkBoxCharsGf12.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x08);
            checkBoxCharsGf13.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x10);
            checkBoxCharsGf14.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x20);
            checkBoxCharsGf15.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x40);
            checkBoxCharsGf16.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(84, 0x80);
            hexUpDownCharUnk2.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(85, hexUpDownCharUnk2.Value);
            checkBoxCharsAltMod.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(86, 0x01);
            comboBoxCharsJunHp.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(87, comboBoxCharsJunHp.SelectedIndex);
            comboBoxCharsJunStr.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(88, comboBoxCharsJunStr.SelectedIndex);
            comboBoxCharsJunVit.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(89, comboBoxCharsJunVit.SelectedIndex);
            comboBoxCharsJunMag.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(90, comboBoxCharsJunMag.SelectedIndex);
            comboBoxCharsJunSpr.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(91, comboBoxCharsJunSpr.SelectedIndex);
            comboBoxCharsJunSpd.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(92, comboBoxCharsJunSpd.SelectedIndex);
            comboBoxCharsJunEva.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(93, comboBoxCharsJunEva.SelectedIndex);
            comboBoxCharsJunHit.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(94, comboBoxCharsJunHit.SelectedIndex);
            comboBoxCharsJunLuck.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(95, comboBoxCharsJunLuck.SelectedIndex);
            comboBoxCharsElemAtk.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(96, comboBoxCharsElemAtk.SelectedIndex);
            comboBoxCharsStatusAtk.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(97, comboBoxCharsStatusAtk.SelectedIndex);
            comboBoxCharsElemDef1.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(98, comboBoxCharsElemDef1.SelectedIndex);
            comboBoxCharsElemDef2.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(99, comboBoxCharsElemDef2.SelectedIndex);
            comboBoxCharsElemDef3.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(100, comboBoxCharsElemDef3.SelectedIndex);
            comboBoxCharsElemDef4.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(101, comboBoxCharsElemDef4.SelectedIndex);
            comboBoxCharsStatusDef1.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(102, comboBoxCharsStatusDef1.SelectedIndex);
            comboBoxCharsStatusDef2.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(103, comboBoxCharsStatusDef2.SelectedIndex);
            comboBoxCharsStatusDef3.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(104, comboBoxCharsStatusDef3.SelectedIndex);
            comboBoxCharsStatusDef4.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Characters(105, comboBoxCharsStatusDef4.SelectedIndex);
            hexUpDownCharUnk3.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(106, hexUpDownCharUnk3.Value);
            numericUpDownGfComp1.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(107, numericUpDownGfComp1.Value);
            numericUpDownGfComp2.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(108, numericUpDownGfComp2.Value);
            numericUpDownGfComp3.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(109, numericUpDownGfComp3.Value);
            numericUpDownGfComp4.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(110, numericUpDownGfComp4.Value);
            numericUpDownGfComp5.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(111, numericUpDownGfComp5.Value);
            numericUpDownGfComp6.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(112, numericUpDownGfComp6.Value);
            numericUpDownGfComp7.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(113, numericUpDownGfComp7.Value);
            numericUpDownGfComp8.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(114, numericUpDownGfComp8.Value);
            numericUpDownGfComp9.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(115, numericUpDownGfComp9.Value);
            numericUpDownGfComp10.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(116, numericUpDownGfComp10.Value);
            numericUpDownGfComp11.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(117, numericUpDownGfComp11.Value);
            numericUpDownGfComp12.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(118, numericUpDownGfComp12.Value);
            numericUpDownGfComp13.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(119, numericUpDownGfComp13.Value);
            numericUpDownGfComp14.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(120, numericUpDownGfComp14.Value);
            numericUpDownGfComp15.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(121, numericUpDownGfComp15.Value);
            numericUpDownGfComp16.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(122, numericUpDownGfComp16.Value);
            numericUpDownCharsKills.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(123, numericUpDownCharsKills.Value);
            numericUpDownCharsKOs.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(124, numericUpDownCharsKOs.Value);
            checkBoxCharsAvailable.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(125, 0x01);
            hexUpDownCharUnk4.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(126, hexUpDownCharUnk4.Value);
            checkBoxCharStatus1.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x01);
            checkBoxCharStatus2.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x02);
            checkBoxCharStatus3.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x04);
            checkBoxCharStatus4.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x08);
            checkBoxCharStatus5.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x10);
            checkBoxCharStatus6.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x20);
            checkBoxCharStatus7.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x40);
            checkBoxCharStatus8.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_Characters(127, 0x80);
            hexUpDownCharUnk5.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Characters(128, hexUpDownCharUnk5.Value);

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

        #region Open, Save, About

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
                    buttonSaveAs.Enabled = true;

                    toolStripStatusLabelStatus.Text = Path.GetFileName(_existingFilename) + " loaded successfully";
                    toolStripStatusLabelInit.Text = Path.GetFileName(_existingFilename) + " loaded";
                    statusStrip.BackColor = Color.FromArgb(255, 25, 170, 30);
                    toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 25, 170, 30);
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

                    statusStrip.BackColor = Color.FromArgb(255, 25, 170, 30);
                    toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 25, 170, 30);
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

        private async void buttonSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAsDialog = new SaveFileDialog();
            saveAsDialog.Title = "Open FF8 init.out";
            saveAsDialog.Filter = "FF8 Init File|*.out";
            saveAsDialog.FileName = Path.GetFileName(_existingFilename);

            if (!(string.IsNullOrEmpty(_existingFilename)) && InitWorker.Init != null)
            {
                try
                {
                    if (saveAsDialog.ShowDialog() != DialogResult.OK) return;
                    {
                        File.WriteAllBytes(saveAsDialog.FileName, InitWorker.Init);

                        statusStrip.BackColor = Color.FromArgb(255, 25, 170, 30);
                        toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 25, 170, 30);
                        toolStripStatusLabelStatus.Text = Path.GetFileName(_existingFilename) + " saved successfully";
                        await Task.Delay(3000);
                        statusStrip.BackColor = Color.Gray;
                        toolStripStatusLabelStatus.BackColor = Color.Gray;
                        toolStripStatusLabelStatus.Text = "Ready";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot save the file {0}, maybe it's locked by another software?", Path.GetFileName(saveAsDialog.FileName)), "Error Saving File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        #endregion

        #region Trackbars

        private void trackBarCharsRenzoInd_Scroll(object sender, EventArgs e)
        {
            labelTrackBarCharsRenzoInd.Text = trackBarCharsRenzoInd.Value.ToString();
        }

        private void trackBarCharsRenzoInd_ValueChanged(object sender, EventArgs e)
        {
            labelTrackBarCharsRenzoInd.Text = trackBarCharsRenzoInd.Value.ToString();
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
                ToolTip(checkBoxGfAb001, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb002, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb003, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb004, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb005, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb006, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb007, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb008, 1, (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb009, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb010, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb011, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb012, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb013, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb014, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb015, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb016, 1, (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb017, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb018, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb019, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb020, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb021, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb022, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb023, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb024, 1, (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb025, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb026, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb027, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb028, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb029, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb030, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb031, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb032, 1, (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb033, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb034, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb035, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb036, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb037, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb038, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb039, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb040, 1, (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb041, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb042, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb043, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb044, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb045, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb046, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb047, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb048, 1, (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb049, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb050, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb051, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb052, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb053, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb054, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb055, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb056, 1, (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb057, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb058, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb059, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb060, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb061, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb062, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb063, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb064, 1, (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb065, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb066, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb067, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb068, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb069, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb070, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb071, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb072, 1, (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb073, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb074, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb075, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb076, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb077, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb078, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb079, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb080, 1, (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb081, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb082, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb083, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb084, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb085, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb086, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb087, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb088, 1, (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb089, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb090, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb091, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb092, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb093, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb094, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb095, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb096, 1, (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb097, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb098, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb099, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb100, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb101, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb102, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb103, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb104, 1, (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb105, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb106, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb107, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb108, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb109, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb110, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb111, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb112, 1, (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxGfAb113, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxGfAb114, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxGfAb115, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxGfAb116, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxGfAb117, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxGfAb118, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxGfAb119, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxGfAb120, 1, (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x80) >= 1 ? true : false);
                ToolTip(numericUpDownGfAp1, 0, InitWorker.GetSelectedGfData.ApAbility1);
                ToolTip(numericUpDownGfAp2, 0, InitWorker.GetSelectedGfData.ApAbility2);
                ToolTip(numericUpDownGfAp3, 0, InitWorker.GetSelectedGfData.ApAbility3);
                ToolTip(numericUpDownGfAp4, 0, InitWorker.GetSelectedGfData.ApAbility4);
                ToolTip(numericUpDownGfAp5, 0, InitWorker.GetSelectedGfData.ApAbility5);
                ToolTip(numericUpDownGfAp6, 0, InitWorker.GetSelectedGfData.ApAbility6);
                ToolTip(numericUpDownGfAp7, 0, InitWorker.GetSelectedGfData.ApAbility7);
                ToolTip(numericUpDownGfAp8, 0, InitWorker.GetSelectedGfData.ApAbility8);
                ToolTip(numericUpDownGfAp9, 0, InitWorker.GetSelectedGfData.ApAbility9);
                ToolTip(numericUpDownGfAp10, 0, InitWorker.GetSelectedGfData.ApAbility10);
                ToolTip(numericUpDownGfAp11, 0, InitWorker.GetSelectedGfData.ApAbility11);
                ToolTip(numericUpDownGfAp12, 0, InitWorker.GetSelectedGfData.ApAbility12);
                ToolTip(numericUpDownGfAp13, 0, InitWorker.GetSelectedGfData.ApAbility13);
                ToolTip(numericUpDownGfAp14, 0, InitWorker.GetSelectedGfData.ApAbility14);
                ToolTip(numericUpDownGfAp15, 0, InitWorker.GetSelectedGfData.ApAbility15);
                ToolTip(numericUpDownGfAp16, 0, InitWorker.GetSelectedGfData.ApAbility16);
                ToolTip(numericUpDownGfAp17, 0, InitWorker.GetSelectedGfData.ApAbility17);
                ToolTip(numericUpDownGfAp18, 0, InitWorker.GetSelectedGfData.ApAbility18);
                ToolTip(numericUpDownGfAp19, 0, InitWorker.GetSelectedGfData.ApAbility19);
                ToolTip(numericUpDownGfAp20, 0, InitWorker.GetSelectedGfData.ApAbility20);
                ToolTip(numericUpDownGfAp21, 0, InitWorker.GetSelectedGfData.ApAbility21);
                ToolTip(numericUpDownGfAp22, 0, InitWorker.GetSelectedGfData.ApAbility22);
                ToolTip(numericUpDownGfKills, 0, InitWorker.GetSelectedGfData.Kills);
                ToolTip(numericUpDownGfKOs, 0, InitWorker.GetSelectedGfData.KOs);
                ToolTip(comboBoxGfLearningAbility, 2, comboBoxGfLearningAbility.Items[InitWorker.GetSelectedGfData.LearningAbility]);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }

            InitWorker.ReadGF(GfList, InitWorker.Init);
            try
            {
                textBoxGfName.Text = InitWorker.GetSelectedGfData.Name;
                numericUpDownGfExp.Value = InitWorker.GetSelectedGfData.Exp;
                hexUpDownGfUnknown.Value = InitWorker.GetSelectedGfData.Unknown1;
                checkBoxGfAvailable.Checked = (InitWorker.GetSelectedGfData.Available & 0x01) >= 1 ? true : false;
                numericUpDownGfHp.Value = InitWorker.GetSelectedGfData.CurrentHp;
                checkBoxGfAb001.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x01) >= 1 ? true : false;
                checkBoxGfAb002.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x02) >= 1 ? true : false;
                checkBoxGfAb003.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x04) >= 1 ? true : false;
                checkBoxGfAb004.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x08) >= 1 ? true : false;
                checkBoxGfAb005.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x10) >= 1 ? true : false;
                checkBoxGfAb006.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x20) >= 1 ? true : false;
                checkBoxGfAb007.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x40) >= 1 ? true : false;
                checkBoxGfAb008.Checked = (InitWorker.GetSelectedGfData.LearnedAbility1 & 0x80) >= 1 ? true : false;
                checkBoxGfAb009.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x01) >= 1 ? true : false;
                checkBoxGfAb010.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x02) >= 1 ? true : false;
                checkBoxGfAb011.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x04) >= 1 ? true : false;
                checkBoxGfAb012.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x08) >= 1 ? true : false;
                checkBoxGfAb013.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x10) >= 1 ? true : false;
                checkBoxGfAb014.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x20) >= 1 ? true : false;
                checkBoxGfAb015.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x40) >= 1 ? true : false;
                checkBoxGfAb016.Checked = (InitWorker.GetSelectedGfData.LearnedAbility2 & 0x80) >= 1 ? true : false;
                checkBoxGfAb017.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x01) >= 1 ? true : false;
                checkBoxGfAb018.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x02) >= 1 ? true : false;
                checkBoxGfAb019.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x04) >= 1 ? true : false;
                checkBoxGfAb020.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x08) >= 1 ? true : false;
                checkBoxGfAb021.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x10) >= 1 ? true : false;
                checkBoxGfAb022.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x20) >= 1 ? true : false;
                checkBoxGfAb023.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x40) >= 1 ? true : false;
                checkBoxGfAb024.Checked = (InitWorker.GetSelectedGfData.LearnedAbility3 & 0x80) >= 1 ? true : false;
                checkBoxGfAb025.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x01) >= 1 ? true : false;
                checkBoxGfAb026.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x02) >= 1 ? true : false;
                checkBoxGfAb027.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x04) >= 1 ? true : false;
                checkBoxGfAb028.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x08) >= 1 ? true : false;
                checkBoxGfAb029.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x10) >= 1 ? true : false;
                checkBoxGfAb030.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x20) >= 1 ? true : false;
                checkBoxGfAb031.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x40) >= 1 ? true : false;
                checkBoxGfAb032.Checked = (InitWorker.GetSelectedGfData.LearnedAbility4 & 0x80) >= 1 ? true : false;
                checkBoxGfAb033.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x01) >= 1 ? true : false;
                checkBoxGfAb034.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x02) >= 1 ? true : false;
                checkBoxGfAb035.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x04) >= 1 ? true : false;
                checkBoxGfAb036.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x08) >= 1 ? true : false;
                checkBoxGfAb037.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x10) >= 1 ? true : false;
                checkBoxGfAb038.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x20) >= 1 ? true : false;
                checkBoxGfAb039.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x40) >= 1 ? true : false;
                checkBoxGfAb040.Checked = (InitWorker.GetSelectedGfData.LearnedAbility5 & 0x80) >= 1 ? true : false;
                checkBoxGfAb041.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x01) >= 1 ? true : false;
                checkBoxGfAb042.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x02) >= 1 ? true : false;
                checkBoxGfAb043.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x04) >= 1 ? true : false;
                checkBoxGfAb044.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x08) >= 1 ? true : false;
                checkBoxGfAb045.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x10) >= 1 ? true : false;
                checkBoxGfAb046.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x20) >= 1 ? true : false;
                checkBoxGfAb047.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x40) >= 1 ? true : false;
                checkBoxGfAb048.Checked = (InitWorker.GetSelectedGfData.LearnedAbility6 & 0x80) >= 1 ? true : false;
                checkBoxGfAb049.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x01) >= 1 ? true : false;
                checkBoxGfAb050.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x02) >= 1 ? true : false;
                checkBoxGfAb051.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x04) >= 1 ? true : false;
                checkBoxGfAb052.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x08) >= 1 ? true : false;
                checkBoxGfAb053.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x10) >= 1 ? true : false;
                checkBoxGfAb054.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x20) >= 1 ? true : false;
                checkBoxGfAb055.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x40) >= 1 ? true : false;
                checkBoxGfAb056.Checked = (InitWorker.GetSelectedGfData.LearnedAbility7 & 0x80) >= 1 ? true : false;
                checkBoxGfAb057.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x01) >= 1 ? true : false;
                checkBoxGfAb058.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x02) >= 1 ? true : false;
                checkBoxGfAb059.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x04) >= 1 ? true : false;
                checkBoxGfAb060.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x08) >= 1 ? true : false;
                checkBoxGfAb061.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x10) >= 1 ? true : false;
                checkBoxGfAb062.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x20) >= 1 ? true : false;
                checkBoxGfAb063.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x40) >= 1 ? true : false;
                checkBoxGfAb064.Checked = (InitWorker.GetSelectedGfData.LearnedAbility8 & 0x80) >= 1 ? true : false;
                checkBoxGfAb065.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x01) >= 1 ? true : false;
                checkBoxGfAb066.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x02) >= 1 ? true : false;
                checkBoxGfAb067.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x04) >= 1 ? true : false;
                checkBoxGfAb068.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x08) >= 1 ? true : false;
                checkBoxGfAb069.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x10) >= 1 ? true : false;
                checkBoxGfAb070.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x20) >= 1 ? true : false;
                checkBoxGfAb071.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x40) >= 1 ? true : false;
                checkBoxGfAb072.Checked = (InitWorker.GetSelectedGfData.LearnedAbility9 & 0x80) >= 1 ? true : false;
                checkBoxGfAb073.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x01) >= 1 ? true : false;
                checkBoxGfAb074.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x02) >= 1 ? true : false;
                checkBoxGfAb075.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x04) >= 1 ? true : false;
                checkBoxGfAb076.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x08) >= 1 ? true : false;
                checkBoxGfAb077.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x10) >= 1 ? true : false;
                checkBoxGfAb078.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x20) >= 1 ? true : false;
                checkBoxGfAb079.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x40) >= 1 ? true : false;
                checkBoxGfAb080.Checked = (InitWorker.GetSelectedGfData.LearnedAbility10 & 0x80) >= 1 ? true : false;
                checkBoxGfAb081.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x01) >= 1 ? true : false;
                checkBoxGfAb082.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x02) >= 1 ? true : false;
                checkBoxGfAb083.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x04) >= 1 ? true : false;
                checkBoxGfAb084.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x08) >= 1 ? true : false;
                checkBoxGfAb085.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x10) >= 1 ? true : false;
                checkBoxGfAb086.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x20) >= 1 ? true : false;
                checkBoxGfAb087.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x40) >= 1 ? true : false;
                checkBoxGfAb088.Checked = (InitWorker.GetSelectedGfData.LearnedAbility11 & 0x80) >= 1 ? true : false;
                checkBoxGfAb089.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x01) >= 1 ? true : false;
                checkBoxGfAb090.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x02) >= 1 ? true : false;
                checkBoxGfAb091.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x04) >= 1 ? true : false;
                checkBoxGfAb092.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x08) >= 1 ? true : false;
                checkBoxGfAb093.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x10) >= 1 ? true : false;
                checkBoxGfAb094.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x20) >= 1 ? true : false;
                checkBoxGfAb095.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x40) >= 1 ? true : false;
                checkBoxGfAb096.Checked = (InitWorker.GetSelectedGfData.LearnedAbility12 & 0x80) >= 1 ? true : false;
                checkBoxGfAb097.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x01) >= 1 ? true : false;
                checkBoxGfAb098.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x02) >= 1 ? true : false;
                checkBoxGfAb099.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x04) >= 1 ? true : false;
                checkBoxGfAb100.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x08) >= 1 ? true : false;
                checkBoxGfAb101.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x10) >= 1 ? true : false;
                checkBoxGfAb102.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x20) >= 1 ? true : false;
                checkBoxGfAb103.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x40) >= 1 ? true : false;
                checkBoxGfAb104.Checked = (InitWorker.GetSelectedGfData.LearnedAbility13 & 0x80) >= 1 ? true : false;
                checkBoxGfAb105.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x01) >= 1 ? true : false;
                checkBoxGfAb106.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x02) >= 1 ? true : false;
                checkBoxGfAb107.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x04) >= 1 ? true : false;
                checkBoxGfAb108.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x08) >= 1 ? true : false;
                checkBoxGfAb109.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x10) >= 1 ? true : false;
                checkBoxGfAb110.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x20) >= 1 ? true : false;
                checkBoxGfAb111.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x40) >= 1 ? true : false;
                checkBoxGfAb112.Checked = (InitWorker.GetSelectedGfData.LearnedAbility14 & 0x80) >= 1 ? true : false;
                checkBoxGfAb113.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x01) >= 1 ? true : false;
                checkBoxGfAb114.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x02) >= 1 ? true : false;
                checkBoxGfAb115.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x04) >= 1 ? true : false;
                checkBoxGfAb116.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x08) >= 1 ? true : false;
                checkBoxGfAb117.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x10) >= 1 ? true : false;
                checkBoxGfAb118.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x20) >= 1 ? true : false;
                checkBoxGfAb119.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x40) >= 1 ? true : false;
                checkBoxGfAb120.Checked = (InitWorker.GetSelectedGfData.LearnedAbility15 & 0x80) >= 1 ? true : false;
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

        private void listViewCharactersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _loaded = false;
            if (InitWorker.Init == null || InitWorker.BackupInit == null)
                return;

            int CharList = 0;
            if (listViewCharactersList.SelectedItems.Count > 0)
                CharList = listViewCharactersList.SelectedIndices[0];

            InitWorker.ReadCharacters(CharList, InitWorker.BackupInit);
            try
            {
                ToolTip(numericUpDownCharsCurrentHp, 0, InitWorker.GetSelectedCharactersData.CurrentHp);
                ToolTip(numericUpDownCharsHpBonus, 0, InitWorker.GetSelectedCharactersData.HpBonus);
                ToolTip(numericUpDownCharsExp, 0, InitWorker.GetSelectedCharactersData.Exp);
                ToolTip(comboBoxCharsBody, 2, comboBoxCharsBody.Items[InitWorker.GetSelectedCharactersData.ModelId]);
                ToolTip(comboBoxCharsWeapon, 2, comboBoxCharsWeapon.Items[InitWorker.GetSelectedCharactersData.WeaponId]);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }

            InitWorker.ReadCharacters(CharList, InitWorker.Init);
            try
            {
                numericUpDownCharsCurrentHp.Value = InitWorker.GetSelectedCharactersData.CurrentHp;
                numericUpDownCharsHpBonus.Value = InitWorker.GetSelectedCharactersData.HpBonus;
                numericUpDownCharsExp.Value = InitWorker.GetSelectedCharactersData.Exp;
                comboBoxCharsBody.SelectedIndex = InitWorker.GetSelectedCharactersData.ModelId;
                comboBoxCharsWeapon.SelectedIndex = InitWorker.GetSelectedCharactersData.WeaponId;
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }
            _loaded = true;
        }

        private void numericUpDownCharExpLvUp_ValueChanged(object sender, EventArgs e)
        {
            CharacterLevel();
        }

        private void CharacterLevel()
        {
            int level = ((int)numericUpDownCharsExp.Value / (int)numericUpDownCharsExpLvUp.Value) + 1;
            if (level > 100)
                level = 100;
            else
                level = ((int)numericUpDownCharsExp.Value / (int)numericUpDownCharsExpLvUp.Value) + 1;

            labelCharsLv.Text = "Level: " + level.ToString();
        }

        private void numericUpDownCharExp_ValueChanged(object sender, EventArgs e)
        {
            CharacterLevel();
        }
    }
}
