using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Quezacotl.Properties;

namespace Quezacotl
{
    public partial class Form1 : Form
    {
        public static bool _loaded = false;
        private bool _opensaveException = false;
        private string _existingFilename;
        private string _backup;
        private const byte _bp_numerical = 0x00;
        private const byte _bp_checked = 0x01;
        private const byte _bp_string = 0x02;
        private const byte _bp_hex = 0x03;

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)] //used in Listview selection style method
        internal static extern int SetWindowTheme(IntPtr hWnd, string appName, string partList);

        public Form1()
        {
            InitializeComponent();

            #region Load Magic List

            string[] magicList = Resources.List_Magic.Split('\n');
            foreach (var line in magicList)
            {
                comboBoxCharsMagic1.BeginUpdate();
                comboBoxCharsMagic1.Items.Add(line);
                comboBoxCharsMagic1.EndUpdate();
                comboBoxCharsMagic2.BeginUpdate();
                comboBoxCharsMagic2.Items.Add(line);
                comboBoxCharsMagic2.EndUpdate();
                comboBoxCharsMagic3.BeginUpdate();
                comboBoxCharsMagic3.Items.Add(line);
                comboBoxCharsMagic3.EndUpdate();
                comboBoxCharsMagic4.BeginUpdate();
                comboBoxCharsMagic4.Items.Add(line);
                comboBoxCharsMagic4.EndUpdate();
                comboBoxCharsMagic5.BeginUpdate();
                comboBoxCharsMagic5.Items.Add(line);
                comboBoxCharsMagic5.EndUpdate();
                comboBoxCharsMagic6.BeginUpdate();
                comboBoxCharsMagic6.Items.Add(line);
                comboBoxCharsMagic6.EndUpdate();
                comboBoxCharsMagic7.BeginUpdate();
                comboBoxCharsMagic7.Items.Add(line);
                comboBoxCharsMagic7.EndUpdate();
                comboBoxCharsMagic8.BeginUpdate();
                comboBoxCharsMagic8.Items.Add(line);
                comboBoxCharsMagic8.EndUpdate();
                comboBoxCharsMagic9.BeginUpdate();
                comboBoxCharsMagic9.Items.Add(line);
                comboBoxCharsMagic9.EndUpdate();
                comboBoxCharsMagic10.BeginUpdate();
                comboBoxCharsMagic10.Items.Add(line);
                comboBoxCharsMagic10.EndUpdate();
                comboBoxCharsMagic11.BeginUpdate();
                comboBoxCharsMagic11.Items.Add(line);
                comboBoxCharsMagic11.EndUpdate();
                comboBoxCharsMagic12.BeginUpdate();
                comboBoxCharsMagic12.Items.Add(line);
                comboBoxCharsMagic12.EndUpdate();
                comboBoxCharsMagic13.BeginUpdate();
                comboBoxCharsMagic13.Items.Add(line);
                comboBoxCharsMagic13.EndUpdate();
                comboBoxCharsMagic14.BeginUpdate();
                comboBoxCharsMagic14.Items.Add(line);
                comboBoxCharsMagic14.EndUpdate();
                comboBoxCharsMagic15.BeginUpdate();
                comboBoxCharsMagic15.Items.Add(line);
                comboBoxCharsMagic15.EndUpdate();
                comboBoxCharsMagic16.BeginUpdate();
                comboBoxCharsMagic16.Items.Add(line);
                comboBoxCharsMagic16.EndUpdate();
                comboBoxCharsMagic17.BeginUpdate();
                comboBoxCharsMagic17.Items.Add(line);
                comboBoxCharsMagic17.EndUpdate();
                comboBoxCharsMagic18.BeginUpdate();
                comboBoxCharsMagic18.Items.Add(line);
                comboBoxCharsMagic18.EndUpdate();
                comboBoxCharsMagic19.BeginUpdate();
                comboBoxCharsMagic19.Items.Add(line);
                comboBoxCharsMagic19.EndUpdate();
                comboBoxCharsMagic20.BeginUpdate();
                comboBoxCharsMagic20.Items.Add(line);
                comboBoxCharsMagic20.EndUpdate();
                comboBoxCharsMagic21.BeginUpdate();
                comboBoxCharsMagic21.Items.Add(line);
                comboBoxCharsMagic21.EndUpdate();
                comboBoxCharsMagic22.BeginUpdate();
                comboBoxCharsMagic22.Items.Add(line);
                comboBoxCharsMagic22.EndUpdate();
                comboBoxCharsMagic23.BeginUpdate();
                comboBoxCharsMagic23.Items.Add(line);
                comboBoxCharsMagic23.EndUpdate();
                comboBoxCharsMagic24.BeginUpdate();
                comboBoxCharsMagic24.Items.Add(line);
                comboBoxCharsMagic24.EndUpdate();
                comboBoxCharsMagic25.BeginUpdate();
                comboBoxCharsMagic25.Items.Add(line);
                comboBoxCharsMagic25.EndUpdate();
                comboBoxCharsMagic26.BeginUpdate();
                comboBoxCharsMagic26.Items.Add(line);
                comboBoxCharsMagic26.EndUpdate();
                comboBoxCharsMagic27.BeginUpdate();
                comboBoxCharsMagic27.Items.Add(line);
                comboBoxCharsMagic27.EndUpdate();
                comboBoxCharsMagic28.BeginUpdate();
                comboBoxCharsMagic28.Items.Add(line);
                comboBoxCharsMagic28.EndUpdate();
                comboBoxCharsMagic29.BeginUpdate();
                comboBoxCharsMagic29.Items.Add(line);
                comboBoxCharsMagic29.EndUpdate();
                comboBoxCharsMagic30.BeginUpdate();
                comboBoxCharsMagic30.Items.Add(line);
                comboBoxCharsMagic30.EndUpdate();
                comboBoxCharsMagic31.BeginUpdate();
                comboBoxCharsMagic31.Items.Add(line);
                comboBoxCharsMagic31.EndUpdate();
                comboBoxCharsMagic32.BeginUpdate();
                comboBoxCharsMagic32.Items.Add(line);
                comboBoxCharsMagic32.EndUpdate();
            }

            #endregion

            #region Load Items List

            string[] itemList = Resources.List_Items.Split('\n');
            foreach (var line in itemList)
            {
                comboBoxItem1.BeginUpdate();
                comboBoxItem1.Items.Add(line);
                comboBoxItem1.EndUpdate();
                comboBoxItem2.BeginUpdate();
                comboBoxItem2.Items.Add(line);
                comboBoxItem2.EndUpdate();
                comboBoxItem3.BeginUpdate();
                comboBoxItem3.Items.Add(line);
                comboBoxItem3.EndUpdate();
                comboBoxItem4.BeginUpdate();
                comboBoxItem4.Items.Add(line);
                comboBoxItem4.EndUpdate();
                comboBoxItem5.BeginUpdate();
                comboBoxItem5.Items.Add(line);
                comboBoxItem5.EndUpdate();
                comboBoxItem6.BeginUpdate();
                comboBoxItem6.Items.Add(line);
                comboBoxItem6.EndUpdate();
                comboBoxItem7.BeginUpdate();
                comboBoxItem7.Items.Add(line);
                comboBoxItem7.EndUpdate();
                comboBoxItem8.BeginUpdate();
                comboBoxItem8.Items.Add(line);
                comboBoxItem8.EndUpdate();
                comboBoxItem9.BeginUpdate();
                comboBoxItem9.Items.Add(line);
                comboBoxItem9.EndUpdate();
                comboBoxItem10.BeginUpdate();
                comboBoxItem10.Items.Add(line);
                comboBoxItem10.EndUpdate();
                comboBoxItem11.BeginUpdate();
                comboBoxItem11.Items.Add(line);
                comboBoxItem11.EndUpdate();
                comboBoxItem12.BeginUpdate();
                comboBoxItem12.Items.Add(line);
                comboBoxItem12.EndUpdate();
                comboBoxItem13.BeginUpdate();
                comboBoxItem13.Items.Add(line);
                comboBoxItem13.EndUpdate();
                comboBoxItem14.BeginUpdate();
                comboBoxItem14.Items.Add(line);
                comboBoxItem14.EndUpdate();
                comboBoxItem15.BeginUpdate();
                comboBoxItem15.Items.Add(line);
                comboBoxItem15.EndUpdate();
                comboBoxItem16.BeginUpdate();
                comboBoxItem16.Items.Add(line);
                comboBoxItem16.EndUpdate();
                comboBoxItem17.BeginUpdate();
                comboBoxItem17.Items.Add(line);
                comboBoxItem17.EndUpdate();
                comboBoxItem18.BeginUpdate();
                comboBoxItem18.Items.Add(line);
                comboBoxItem18.EndUpdate();
                comboBoxItem19.BeginUpdate();
                comboBoxItem19.Items.Add(line);
                comboBoxItem19.EndUpdate();
                comboBoxItem20.BeginUpdate();
                comboBoxItem20.Items.Add(line);
                comboBoxItem20.EndUpdate();
                comboBoxItem21.BeginUpdate();
                comboBoxItem21.Items.Add(line);
                comboBoxItem21.EndUpdate();
                comboBoxItem22.BeginUpdate();
                comboBoxItem22.Items.Add(line);
                comboBoxItem22.EndUpdate();
                comboBoxItem23.BeginUpdate();
                comboBoxItem23.Items.Add(line);
                comboBoxItem23.EndUpdate();
                comboBoxItem24.BeginUpdate();
                comboBoxItem24.Items.Add(line);
                comboBoxItem24.EndUpdate();
                comboBoxItem25.BeginUpdate();
                comboBoxItem25.Items.Add(line);
                comboBoxItem25.EndUpdate();
                comboBoxItem26.BeginUpdate();
                comboBoxItem26.Items.Add(line);
                comboBoxItem26.EndUpdate();
                comboBoxItem27.BeginUpdate();
                comboBoxItem27.Items.Add(line);
                comboBoxItem27.EndUpdate();
                comboBoxItem28.BeginUpdate();
                comboBoxItem28.Items.Add(line);
                comboBoxItem28.EndUpdate();
                comboBoxItem29.BeginUpdate();
                comboBoxItem29.Items.Add(line);
                comboBoxItem29.EndUpdate();
                comboBoxItem30.BeginUpdate();
                comboBoxItem30.Items.Add(line);
                comboBoxItem30.EndUpdate();
                comboBoxItem31.BeginUpdate();
                comboBoxItem31.Items.Add(line);
                comboBoxItem31.EndUpdate();
                comboBoxItem32.BeginUpdate();
                comboBoxItem32.Items.Add(line);
                comboBoxItem32.EndUpdate();
                comboBoxItem33.BeginUpdate();
                comboBoxItem33.Items.Add(line);
                comboBoxItem33.EndUpdate();
                comboBoxItem34.BeginUpdate();
                comboBoxItem34.Items.Add(line);
                comboBoxItem34.EndUpdate();
                comboBoxItem35.BeginUpdate();
                comboBoxItem35.Items.Add(line);
                comboBoxItem35.EndUpdate();
                comboBoxItem36.BeginUpdate();
                comboBoxItem36.Items.Add(line);
                comboBoxItem36.EndUpdate();
                comboBoxItem37.BeginUpdate();
                comboBoxItem37.Items.Add(line);
                comboBoxItem37.EndUpdate();
                comboBoxItem38.BeginUpdate();
                comboBoxItem38.Items.Add(line);
                comboBoxItem38.EndUpdate();
                comboBoxItem39.BeginUpdate();
                comboBoxItem39.Items.Add(line);
                comboBoxItem39.EndUpdate();
                comboBoxItem40.BeginUpdate();
                comboBoxItem40.Items.Add(line);
                comboBoxItem40.EndUpdate();
                comboBoxItem41.BeginUpdate();
                comboBoxItem41.Items.Add(line);
                comboBoxItem41.EndUpdate();
                comboBoxItem42.BeginUpdate();
                comboBoxItem42.Items.Add(line);
                comboBoxItem42.EndUpdate();
                comboBoxItem43.BeginUpdate();
                comboBoxItem43.Items.Add(line);
                comboBoxItem43.EndUpdate();
                comboBoxItem44.BeginUpdate();
                comboBoxItem44.Items.Add(line);
                comboBoxItem44.EndUpdate();
                comboBoxItem45.BeginUpdate();
                comboBoxItem45.Items.Add(line);
                comboBoxItem45.EndUpdate();
                comboBoxItem46.BeginUpdate();
                comboBoxItem46.Items.Add(line);
                comboBoxItem46.EndUpdate();
                comboBoxItem47.BeginUpdate();
                comboBoxItem47.Items.Add(line);
                comboBoxItem47.EndUpdate();
                comboBoxItem48.BeginUpdate();
                comboBoxItem48.Items.Add(line);
                comboBoxItem48.EndUpdate();
                comboBoxItem49.BeginUpdate();
                comboBoxItem49.Items.Add(line);
                comboBoxItem49.EndUpdate();
                comboBoxItem50.BeginUpdate();
                comboBoxItem50.Items.Add(line);
                comboBoxItem50.EndUpdate();
                comboBoxItem51.BeginUpdate();
                comboBoxItem51.Items.Add(line);
                comboBoxItem51.EndUpdate();
                comboBoxItem52.BeginUpdate();
                comboBoxItem52.Items.Add(line);
                comboBoxItem52.EndUpdate();
                comboBoxItem53.BeginUpdate();
                comboBoxItem53.Items.Add(line);
                comboBoxItem53.EndUpdate();
                comboBoxItem54.BeginUpdate();
                comboBoxItem54.Items.Add(line);
                comboBoxItem54.EndUpdate();
                comboBoxItem55.BeginUpdate();
                comboBoxItem55.Items.Add(line);
                comboBoxItem55.EndUpdate();
                comboBoxItem56.BeginUpdate();
                comboBoxItem56.Items.Add(line);
                comboBoxItem56.EndUpdate();
                comboBoxItem57.BeginUpdate();
                comboBoxItem57.Items.Add(line);
                comboBoxItem57.EndUpdate();
                comboBoxItem58.BeginUpdate();
                comboBoxItem58.Items.Add(line);
                comboBoxItem58.EndUpdate();
                comboBoxItem59.BeginUpdate();
                comboBoxItem59.Items.Add(line);
                comboBoxItem59.EndUpdate();
                comboBoxItem60.BeginUpdate();
                comboBoxItem60.Items.Add(line);
                comboBoxItem60.EndUpdate();
                comboBoxItem61.BeginUpdate();
                comboBoxItem61.Items.Add(line);
                comboBoxItem61.EndUpdate();
                comboBoxItem62.BeginUpdate();
                comboBoxItem62.Items.Add(line);
                comboBoxItem62.EndUpdate();
                comboBoxItem63.BeginUpdate();
                comboBoxItem63.Items.Add(line);
                comboBoxItem63.EndUpdate();
                comboBoxItem64.BeginUpdate();
                comboBoxItem64.Items.Add(line);
                comboBoxItem64.EndUpdate();
                comboBoxItem65.BeginUpdate();
                comboBoxItem65.Items.Add(line);
                comboBoxItem65.EndUpdate();
                comboBoxItem66.BeginUpdate();
                comboBoxItem66.Items.Add(line);
                comboBoxItem66.EndUpdate();
                comboBoxItem67.BeginUpdate();
                comboBoxItem67.Items.Add(line);
                comboBoxItem67.EndUpdate();
                comboBoxItem68.BeginUpdate();
                comboBoxItem68.Items.Add(line);
                comboBoxItem68.EndUpdate();
                comboBoxItem69.BeginUpdate();
                comboBoxItem69.Items.Add(line);
                comboBoxItem69.EndUpdate();
                comboBoxItem70.BeginUpdate();
                comboBoxItem70.Items.Add(line);
                comboBoxItem70.EndUpdate();
                comboBoxItem71.BeginUpdate();
                comboBoxItem71.Items.Add(line);
                comboBoxItem71.EndUpdate();
                comboBoxItem72.BeginUpdate();
                comboBoxItem72.Items.Add(line);
                comboBoxItem72.EndUpdate();
                comboBoxItem73.BeginUpdate();
                comboBoxItem73.Items.Add(line);
                comboBoxItem73.EndUpdate();
                comboBoxItem74.BeginUpdate();
                comboBoxItem74.Items.Add(line);
                comboBoxItem74.EndUpdate();
                comboBoxItem75.BeginUpdate();
                comboBoxItem75.Items.Add(line);
                comboBoxItem75.EndUpdate();
                comboBoxItem76.BeginUpdate();
                comboBoxItem76.Items.Add(line);
                comboBoxItem76.EndUpdate();
                comboBoxItem77.BeginUpdate();
                comboBoxItem77.Items.Add(line);
                comboBoxItem77.EndUpdate();
                comboBoxItem78.BeginUpdate();
                comboBoxItem78.Items.Add(line);
                comboBoxItem78.EndUpdate();
                comboBoxItem79.BeginUpdate();
                comboBoxItem79.Items.Add(line);
                comboBoxItem79.EndUpdate();
                comboBoxItem80.BeginUpdate();
                comboBoxItem80.Items.Add(line);
                comboBoxItem80.EndUpdate();
                comboBoxItem81.BeginUpdate();
                comboBoxItem81.Items.Add(line);
                comboBoxItem81.EndUpdate();
                comboBoxItem82.BeginUpdate();
                comboBoxItem82.Items.Add(line);
                comboBoxItem82.EndUpdate();
                comboBoxItem83.BeginUpdate();
                comboBoxItem83.Items.Add(line);
                comboBoxItem83.EndUpdate();
                comboBoxItem84.BeginUpdate();
                comboBoxItem84.Items.Add(line);
                comboBoxItem84.EndUpdate();
                comboBoxItem85.BeginUpdate();
                comboBoxItem85.Items.Add(line);
                comboBoxItem85.EndUpdate();
                comboBoxItem86.BeginUpdate();
                comboBoxItem86.Items.Add(line);
                comboBoxItem86.EndUpdate();
                comboBoxItem87.BeginUpdate();
                comboBoxItem87.Items.Add(line);
                comboBoxItem87.EndUpdate();
                comboBoxItem88.BeginUpdate();
                comboBoxItem88.Items.Add(line);
                comboBoxItem88.EndUpdate();
                comboBoxItem89.BeginUpdate();
                comboBoxItem89.Items.Add(line);
                comboBoxItem89.EndUpdate();
                comboBoxItem90.BeginUpdate();
                comboBoxItem90.Items.Add(line);
                comboBoxItem90.EndUpdate();
                comboBoxItem91.BeginUpdate();
                comboBoxItem91.Items.Add(line);
                comboBoxItem91.EndUpdate();
                comboBoxItem92.BeginUpdate();
                comboBoxItem92.Items.Add(line);
                comboBoxItem92.EndUpdate();
                comboBoxItem93.BeginUpdate();
                comboBoxItem93.Items.Add(line);
                comboBoxItem93.EndUpdate();
                comboBoxItem94.BeginUpdate();
                comboBoxItem94.Items.Add(line);
                comboBoxItem94.EndUpdate();
                comboBoxItem95.BeginUpdate();
                comboBoxItem95.Items.Add(line);
                comboBoxItem95.EndUpdate();
                comboBoxItem96.BeginUpdate();
                comboBoxItem96.Items.Add(line);
                comboBoxItem96.EndUpdate();
                comboBoxItem97.BeginUpdate();
                comboBoxItem97.Items.Add(line);
                comboBoxItem97.EndUpdate();
                comboBoxItem98.BeginUpdate();
                comboBoxItem98.Items.Add(line);
                comboBoxItem98.EndUpdate();
                comboBoxItem99.BeginUpdate();
                comboBoxItem99.Items.Add(line);
                comboBoxItem99.EndUpdate();
                comboBoxItem100.BeginUpdate();
                comboBoxItem100.Items.Add(line);
                comboBoxItem100.EndUpdate();
                comboBoxItem101.BeginUpdate();
                comboBoxItem101.Items.Add(line);
                comboBoxItem101.EndUpdate();
                comboBoxItem102.BeginUpdate();
                comboBoxItem102.Items.Add(line);
                comboBoxItem102.EndUpdate();
                comboBoxItem103.BeginUpdate();
                comboBoxItem103.Items.Add(line);
                comboBoxItem103.EndUpdate();
                comboBoxItem104.BeginUpdate();
                comboBoxItem104.Items.Add(line);
                comboBoxItem104.EndUpdate();
                comboBoxItem105.BeginUpdate();
                comboBoxItem105.Items.Add(line);
                comboBoxItem105.EndUpdate();
                comboBoxItem106.BeginUpdate();
                comboBoxItem106.Items.Add(line);
                comboBoxItem106.EndUpdate();
                comboBoxItem107.BeginUpdate();
                comboBoxItem107.Items.Add(line);
                comboBoxItem107.EndUpdate();
                comboBoxItem108.BeginUpdate();
                comboBoxItem108.Items.Add(line);
                comboBoxItem108.EndUpdate();
                comboBoxItem109.BeginUpdate();
                comboBoxItem109.Items.Add(line);
                comboBoxItem109.EndUpdate();
                comboBoxItem110.BeginUpdate();
                comboBoxItem110.Items.Add(line);
                comboBoxItem110.EndUpdate();
                comboBoxItem111.BeginUpdate();
                comboBoxItem111.Items.Add(line);
                comboBoxItem111.EndUpdate();
                comboBoxItem112.BeginUpdate();
                comboBoxItem112.Items.Add(line);
                comboBoxItem112.EndUpdate();
                comboBoxItem113.BeginUpdate();
                comboBoxItem113.Items.Add(line);
                comboBoxItem113.EndUpdate();
                comboBoxItem114.BeginUpdate();
                comboBoxItem114.Items.Add(line);
                comboBoxItem114.EndUpdate();
                comboBoxItem115.BeginUpdate();
                comboBoxItem115.Items.Add(line);
                comboBoxItem115.EndUpdate();
                comboBoxItem116.BeginUpdate();
                comboBoxItem116.Items.Add(line);
                comboBoxItem116.EndUpdate();
                comboBoxItem117.BeginUpdate();
                comboBoxItem117.Items.Add(line);
                comboBoxItem117.EndUpdate();
                comboBoxItem118.BeginUpdate();
                comboBoxItem118.Items.Add(line);
                comboBoxItem118.EndUpdate();
                comboBoxItem119.BeginUpdate();
                comboBoxItem119.Items.Add(line);
                comboBoxItem119.EndUpdate();
                comboBoxItem120.BeginUpdate();
                comboBoxItem120.Items.Add(line);
                comboBoxItem120.EndUpdate();
                comboBoxItem121.BeginUpdate();
                comboBoxItem121.Items.Add(line);
                comboBoxItem121.EndUpdate();
                comboBoxItem122.BeginUpdate();
                comboBoxItem122.Items.Add(line);
                comboBoxItem122.EndUpdate();
                comboBoxItem123.BeginUpdate();
                comboBoxItem123.Items.Add(line);
                comboBoxItem123.EndUpdate();
                comboBoxItem124.BeginUpdate();
                comboBoxItem124.Items.Add(line);
                comboBoxItem124.EndUpdate();
                comboBoxItem125.BeginUpdate();
                comboBoxItem125.Items.Add(line);
                comboBoxItem125.EndUpdate();
                comboBoxItem126.BeginUpdate();
                comboBoxItem126.Items.Add(line);
                comboBoxItem126.EndUpdate();
                comboBoxItem127.BeginUpdate();
                comboBoxItem127.Items.Add(line);
                comboBoxItem127.EndUpdate();
                comboBoxItem128.BeginUpdate();
                comboBoxItem128.Items.Add(line);
                comboBoxItem128.EndUpdate();
                comboBoxItem129.BeginUpdate();
                comboBoxItem129.Items.Add(line);
                comboBoxItem129.EndUpdate();
                comboBoxItem130.BeginUpdate();
                comboBoxItem130.Items.Add(line);
                comboBoxItem130.EndUpdate();
                comboBoxItem131.BeginUpdate();
                comboBoxItem131.Items.Add(line);
                comboBoxItem131.EndUpdate();
                comboBoxItem132.BeginUpdate();
                comboBoxItem132.Items.Add(line);
                comboBoxItem132.EndUpdate();
                comboBoxItem133.BeginUpdate();
                comboBoxItem133.Items.Add(line);
                comboBoxItem133.EndUpdate();
                comboBoxItem134.BeginUpdate();
                comboBoxItem134.Items.Add(line);
                comboBoxItem134.EndUpdate();
                comboBoxItem135.BeginUpdate();
                comboBoxItem135.Items.Add(line);
                comboBoxItem135.EndUpdate();
                comboBoxItem136.BeginUpdate();
                comboBoxItem136.Items.Add(line);
                comboBoxItem136.EndUpdate();
                comboBoxItem137.BeginUpdate();
                comboBoxItem137.Items.Add(line);
                comboBoxItem137.EndUpdate();
                comboBoxItem138.BeginUpdate();
                comboBoxItem138.Items.Add(line);
                comboBoxItem138.EndUpdate();
                comboBoxItem139.BeginUpdate();
                comboBoxItem139.Items.Add(line);
                comboBoxItem139.EndUpdate();
                comboBoxItem140.BeginUpdate();
                comboBoxItem140.Items.Add(line);
                comboBoxItem140.EndUpdate();
                comboBoxItem141.BeginUpdate();
                comboBoxItem141.Items.Add(line);
                comboBoxItem141.EndUpdate();
                comboBoxItem142.BeginUpdate();
                comboBoxItem142.Items.Add(line);
                comboBoxItem142.EndUpdate();
                comboBoxItem143.BeginUpdate();
                comboBoxItem143.Items.Add(line);
                comboBoxItem143.EndUpdate();
                comboBoxItem144.BeginUpdate();
                comboBoxItem144.Items.Add(line);
                comboBoxItem144.EndUpdate();
                comboBoxItem145.BeginUpdate();
                comboBoxItem145.Items.Add(line);
                comboBoxItem145.EndUpdate();
                comboBoxItem146.BeginUpdate();
                comboBoxItem146.Items.Add(line);
                comboBoxItem146.EndUpdate();
                comboBoxItem147.BeginUpdate();
                comboBoxItem147.Items.Add(line);
                comboBoxItem147.EndUpdate();
                comboBoxItem148.BeginUpdate();
                comboBoxItem148.Items.Add(line);
                comboBoxItem148.EndUpdate();
                comboBoxItem149.BeginUpdate();
                comboBoxItem149.Items.Add(line);
                comboBoxItem149.EndUpdate();
                comboBoxItem150.BeginUpdate();
                comboBoxItem150.Items.Add(line);
                comboBoxItem150.EndUpdate();
                comboBoxItem151.BeginUpdate();
                comboBoxItem151.Items.Add(line);
                comboBoxItem151.EndUpdate();
                comboBoxItem152.BeginUpdate();
                comboBoxItem152.Items.Add(line);
                comboBoxItem152.EndUpdate();
                comboBoxItem153.BeginUpdate();
                comboBoxItem153.Items.Add(line);
                comboBoxItem153.EndUpdate();
                comboBoxItem154.BeginUpdate();
                comboBoxItem154.Items.Add(line);
                comboBoxItem154.EndUpdate();
                comboBoxItem155.BeginUpdate();
                comboBoxItem155.Items.Add(line);
                comboBoxItem155.EndUpdate();
                comboBoxItem156.BeginUpdate();
                comboBoxItem156.Items.Add(line);
                comboBoxItem156.EndUpdate();
                comboBoxItem157.BeginUpdate();
                comboBoxItem157.Items.Add(line);
                comboBoxItem157.EndUpdate();
                comboBoxItem158.BeginUpdate();
                comboBoxItem158.Items.Add(line);
                comboBoxItem158.EndUpdate();
                comboBoxItem159.BeginUpdate();
                comboBoxItem159.Items.Add(line);
                comboBoxItem159.EndUpdate();
                comboBoxItem160.BeginUpdate();
                comboBoxItem160.Items.Add(line);
                comboBoxItem160.EndUpdate();
                comboBoxItem161.BeginUpdate();
                comboBoxItem161.Items.Add(line);
                comboBoxItem161.EndUpdate();
                comboBoxItem162.BeginUpdate();
                comboBoxItem162.Items.Add(line);
                comboBoxItem162.EndUpdate();
                comboBoxItem163.BeginUpdate();
                comboBoxItem163.Items.Add(line);
                comboBoxItem163.EndUpdate();
                comboBoxItem164.BeginUpdate();
                comboBoxItem164.Items.Add(line);
                comboBoxItem164.EndUpdate();
                comboBoxItem165.BeginUpdate();
                comboBoxItem165.Items.Add(line);
                comboBoxItem165.EndUpdate();
                comboBoxItem166.BeginUpdate();
                comboBoxItem166.Items.Add(line);
                comboBoxItem166.EndUpdate();
                comboBoxItem167.BeginUpdate();
                comboBoxItem167.Items.Add(line);
                comboBoxItem167.EndUpdate();
                comboBoxItem168.BeginUpdate();
                comboBoxItem168.Items.Add(line);
                comboBoxItem168.EndUpdate();
                comboBoxItem169.BeginUpdate();
                comboBoxItem169.Items.Add(line);
                comboBoxItem169.EndUpdate();
                comboBoxItem170.BeginUpdate();
                comboBoxItem170.Items.Add(line);
                comboBoxItem170.EndUpdate();
                comboBoxItem171.BeginUpdate();
                comboBoxItem171.Items.Add(line);
                comboBoxItem171.EndUpdate();
                comboBoxItem172.BeginUpdate();
                comboBoxItem172.Items.Add(line);
                comboBoxItem172.EndUpdate();
                comboBoxItem173.BeginUpdate();
                comboBoxItem173.Items.Add(line);
                comboBoxItem173.EndUpdate();
                comboBoxItem174.BeginUpdate();
                comboBoxItem174.Items.Add(line);
                comboBoxItem174.EndUpdate();
                comboBoxItem175.BeginUpdate();
                comboBoxItem175.Items.Add(line);
                comboBoxItem175.EndUpdate();
                comboBoxItem176.BeginUpdate();
                comboBoxItem176.Items.Add(line);
                comboBoxItem176.EndUpdate();
                comboBoxItem177.BeginUpdate();
                comboBoxItem177.Items.Add(line);
                comboBoxItem177.EndUpdate();
                comboBoxItem178.BeginUpdate();
                comboBoxItem178.Items.Add(line);
                comboBoxItem178.EndUpdate();
                comboBoxItem179.BeginUpdate();
                comboBoxItem179.Items.Add(line);
                comboBoxItem179.EndUpdate();
                comboBoxItem180.BeginUpdate();
                comboBoxItem180.Items.Add(line);
                comboBoxItem180.EndUpdate();
                comboBoxItem181.BeginUpdate();
                comboBoxItem181.Items.Add(line);
                comboBoxItem181.EndUpdate();
                comboBoxItem182.BeginUpdate();
                comboBoxItem182.Items.Add(line);
                comboBoxItem182.EndUpdate();
                comboBoxItem183.BeginUpdate();
                comboBoxItem183.Items.Add(line);
                comboBoxItem183.EndUpdate();
                comboBoxItem184.BeginUpdate();
                comboBoxItem184.Items.Add(line);
                comboBoxItem184.EndUpdate();
                comboBoxItem185.BeginUpdate();
                comboBoxItem185.Items.Add(line);
                comboBoxItem185.EndUpdate();
                comboBoxItem186.BeginUpdate();
                comboBoxItem186.Items.Add(line);
                comboBoxItem186.EndUpdate();
                comboBoxItem187.BeginUpdate();
                comboBoxItem187.Items.Add(line);
                comboBoxItem187.EndUpdate();
                comboBoxItem188.BeginUpdate();
                comboBoxItem188.Items.Add(line);
                comboBoxItem188.EndUpdate();
                comboBoxItem189.BeginUpdate();
                comboBoxItem189.Items.Add(line);
                comboBoxItem189.EndUpdate();
                comboBoxItem190.BeginUpdate();
                comboBoxItem190.Items.Add(line);
                comboBoxItem190.EndUpdate();
                comboBoxItem191.BeginUpdate();
                comboBoxItem191.Items.Add(line);
                comboBoxItem191.EndUpdate();
                comboBoxItem192.BeginUpdate();
                comboBoxItem192.Items.Add(line);
                comboBoxItem192.EndUpdate();
                comboBoxItem193.BeginUpdate();
                comboBoxItem193.Items.Add(line);
                comboBoxItem193.EndUpdate();
                comboBoxItem194.BeginUpdate();
                comboBoxItem194.Items.Add(line);
                comboBoxItem194.EndUpdate();
                comboBoxItem195.BeginUpdate();
                comboBoxItem195.Items.Add(line);
                comboBoxItem195.EndUpdate();
                comboBoxItem196.BeginUpdate();
                comboBoxItem196.Items.Add(line);
                comboBoxItem196.EndUpdate();
                comboBoxItem197.BeginUpdate();
                comboBoxItem197.Items.Add(line);
                comboBoxItem197.EndUpdate();
                comboBoxItem198.BeginUpdate();
                comboBoxItem198.Items.Add(line);
                comboBoxItem198.EndUpdate();
            }

            #endregion

            ListViewLoadImages();

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
            checkBoxGfAb018.CheckedChanged += (sender, args) => InitWorker.UpdateVariable_GF(7, 0x02);
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

            #region Items event handlers

            comboBoxItem1.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(0, comboBoxItem1.SelectedIndex);
            comboBoxItem2.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(2, comboBoxItem2.SelectedIndex);
            comboBoxItem3.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(4, comboBoxItem3.SelectedIndex);
            comboBoxItem4.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(6, comboBoxItem4.SelectedIndex);
            comboBoxItem5.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(8, comboBoxItem5.SelectedIndex);
            comboBoxItem6.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(10, comboBoxItem6.SelectedIndex);
            comboBoxItem7.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(12, comboBoxItem7.SelectedIndex);
            comboBoxItem8.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(14, comboBoxItem8.SelectedIndex);
            comboBoxItem9.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(16, comboBoxItem9.SelectedIndex);
            comboBoxItem10.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(18, comboBoxItem10.SelectedIndex);
            comboBoxItem11.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(20, comboBoxItem11.SelectedIndex);
            comboBoxItem12.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(22, comboBoxItem12.SelectedIndex);
            comboBoxItem13.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(24, comboBoxItem13.SelectedIndex);
            comboBoxItem14.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(26, comboBoxItem14.SelectedIndex);
            comboBoxItem15.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(28, comboBoxItem15.SelectedIndex);
            comboBoxItem16.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(30, comboBoxItem16.SelectedIndex);
            comboBoxItem17.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(32, comboBoxItem17.SelectedIndex);
            comboBoxItem18.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(34, comboBoxItem18.SelectedIndex);
            comboBoxItem19.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(36, comboBoxItem19.SelectedIndex);
            comboBoxItem20.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(38, comboBoxItem20.SelectedIndex);
            comboBoxItem21.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(40, comboBoxItem21.SelectedIndex);
            comboBoxItem22.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(42, comboBoxItem22.SelectedIndex);
            comboBoxItem23.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(44, comboBoxItem23.SelectedIndex);
            comboBoxItem24.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(46, comboBoxItem24.SelectedIndex);
            comboBoxItem25.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(48, comboBoxItem25.SelectedIndex);
            comboBoxItem26.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(50, comboBoxItem26.SelectedIndex);
            comboBoxItem27.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(52, comboBoxItem27.SelectedIndex);
            comboBoxItem28.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(54, comboBoxItem28.SelectedIndex);
            comboBoxItem29.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(56, comboBoxItem29.SelectedIndex);
            comboBoxItem30.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(58, comboBoxItem30.SelectedIndex);
            comboBoxItem31.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(60, comboBoxItem31.SelectedIndex);
            comboBoxItem32.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(62, comboBoxItem32.SelectedIndex);
            comboBoxItem33.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(64, comboBoxItem33.SelectedIndex);
            comboBoxItem34.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(66, comboBoxItem34.SelectedIndex);
            comboBoxItem35.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(68, comboBoxItem35.SelectedIndex);
            comboBoxItem36.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(70, comboBoxItem36.SelectedIndex);
            comboBoxItem37.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(72, comboBoxItem37.SelectedIndex);
            comboBoxItem38.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(74, comboBoxItem38.SelectedIndex);
            comboBoxItem39.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(76, comboBoxItem39.SelectedIndex);
            comboBoxItem40.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(78, comboBoxItem40.SelectedIndex);
            comboBoxItem41.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(80, comboBoxItem41.SelectedIndex);
            comboBoxItem42.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(82, comboBoxItem42.SelectedIndex);
            comboBoxItem43.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(84, comboBoxItem43.SelectedIndex);
            comboBoxItem44.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(86, comboBoxItem44.SelectedIndex);
            comboBoxItem45.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(88, comboBoxItem45.SelectedIndex);
            comboBoxItem46.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(90, comboBoxItem46.SelectedIndex);
            comboBoxItem47.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(92, comboBoxItem47.SelectedIndex);
            comboBoxItem48.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(94, comboBoxItem48.SelectedIndex);
            comboBoxItem49.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(96, comboBoxItem49.SelectedIndex);
            comboBoxItem50.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(98, comboBoxItem50.SelectedIndex);
            comboBoxItem51.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(100, comboBoxItem51.SelectedIndex);
            comboBoxItem52.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(102, comboBoxItem52.SelectedIndex);
            comboBoxItem53.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(104, comboBoxItem53.SelectedIndex);
            comboBoxItem54.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(106, comboBoxItem54.SelectedIndex);
            comboBoxItem55.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(108, comboBoxItem55.SelectedIndex);
            comboBoxItem56.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(110, comboBoxItem56.SelectedIndex);
            comboBoxItem57.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(112, comboBoxItem57.SelectedIndex);
            comboBoxItem58.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(114, comboBoxItem58.SelectedIndex);
            comboBoxItem59.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(116, comboBoxItem59.SelectedIndex);
            comboBoxItem60.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(118, comboBoxItem60.SelectedIndex);
            comboBoxItem61.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(120, comboBoxItem61.SelectedIndex);
            comboBoxItem62.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(122, comboBoxItem62.SelectedIndex);
            comboBoxItem63.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(124, comboBoxItem63.SelectedIndex);
            comboBoxItem64.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(126, comboBoxItem64.SelectedIndex);
            comboBoxItem65.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(128, comboBoxItem65.SelectedIndex);
            comboBoxItem66.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(130, comboBoxItem66.SelectedIndex);
            comboBoxItem67.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(132, comboBoxItem67.SelectedIndex);
            comboBoxItem68.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(134, comboBoxItem68.SelectedIndex);
            comboBoxItem69.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(136, comboBoxItem69.SelectedIndex);
            comboBoxItem70.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(138, comboBoxItem70.SelectedIndex);
            comboBoxItem71.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(140, comboBoxItem71.SelectedIndex);
            comboBoxItem72.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(142, comboBoxItem72.SelectedIndex);
            comboBoxItem73.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(144, comboBoxItem73.SelectedIndex);
            comboBoxItem74.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(146, comboBoxItem74.SelectedIndex);
            comboBoxItem75.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(148, comboBoxItem75.SelectedIndex);
            comboBoxItem76.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(150, comboBoxItem76.SelectedIndex);
            comboBoxItem77.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(152, comboBoxItem77.SelectedIndex);
            comboBoxItem78.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(154, comboBoxItem78.SelectedIndex);
            comboBoxItem79.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(156, comboBoxItem79.SelectedIndex);
            comboBoxItem80.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(158, comboBoxItem80.SelectedIndex);
            comboBoxItem81.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(160, comboBoxItem81.SelectedIndex);
            comboBoxItem82.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(162, comboBoxItem82.SelectedIndex);
            comboBoxItem83.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(164, comboBoxItem83.SelectedIndex);
            comboBoxItem84.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(166, comboBoxItem84.SelectedIndex);
            comboBoxItem85.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(168, comboBoxItem85.SelectedIndex);
            comboBoxItem86.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(170, comboBoxItem86.SelectedIndex);
            comboBoxItem87.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(172, comboBoxItem87.SelectedIndex);
            comboBoxItem88.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(174, comboBoxItem88.SelectedIndex);
            comboBoxItem89.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(176, comboBoxItem89.SelectedIndex);
            comboBoxItem90.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(178, comboBoxItem90.SelectedIndex);
            comboBoxItem91.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(180, comboBoxItem91.SelectedIndex);
            comboBoxItem92.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(182, comboBoxItem92.SelectedIndex);
            comboBoxItem93.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(184, comboBoxItem93.SelectedIndex);
            comboBoxItem94.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(186, comboBoxItem94.SelectedIndex);
            comboBoxItem95.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(188, comboBoxItem95.SelectedIndex);
            comboBoxItem96.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(190, comboBoxItem96.SelectedIndex);
            comboBoxItem97.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(192, comboBoxItem97.SelectedIndex);
            comboBoxItem98.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(194, comboBoxItem98.SelectedIndex);
            comboBoxItem99.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(196, comboBoxItem99.SelectedIndex);
            comboBoxItem100.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(198, comboBoxItem100.SelectedIndex);
            comboBoxItem101.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(200, comboBoxItem101.SelectedIndex);
            comboBoxItem102.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(202, comboBoxItem102.SelectedIndex);
            comboBoxItem103.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(204, comboBoxItem103.SelectedIndex);
            comboBoxItem104.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(206, comboBoxItem104.SelectedIndex);
            comboBoxItem105.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(208, comboBoxItem105.SelectedIndex);
            comboBoxItem106.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(210, comboBoxItem106.SelectedIndex);
            comboBoxItem107.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(212, comboBoxItem107.SelectedIndex);
            comboBoxItem108.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(214, comboBoxItem108.SelectedIndex);
            comboBoxItem109.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(216, comboBoxItem109.SelectedIndex);
            comboBoxItem110.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(218, comboBoxItem110.SelectedIndex);
            comboBoxItem111.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(220, comboBoxItem111.SelectedIndex);
            comboBoxItem112.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(222, comboBoxItem112.SelectedIndex);
            comboBoxItem113.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(224, comboBoxItem113.SelectedIndex);
            comboBoxItem114.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(226, comboBoxItem114.SelectedIndex);
            comboBoxItem115.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(228, comboBoxItem115.SelectedIndex);
            comboBoxItem116.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(230, comboBoxItem116.SelectedIndex);
            comboBoxItem117.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(232, comboBoxItem117.SelectedIndex);
            comboBoxItem118.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(234, comboBoxItem118.SelectedIndex);
            comboBoxItem119.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(236, comboBoxItem119.SelectedIndex);
            comboBoxItem120.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(238, comboBoxItem120.SelectedIndex);
            comboBoxItem121.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(240, comboBoxItem121.SelectedIndex);
            comboBoxItem122.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(242, comboBoxItem122.SelectedIndex);
            comboBoxItem123.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(244, comboBoxItem123.SelectedIndex);
            comboBoxItem124.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(246, comboBoxItem124.SelectedIndex);
            comboBoxItem125.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(248, comboBoxItem125.SelectedIndex);
            comboBoxItem126.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(250, comboBoxItem126.SelectedIndex);
            comboBoxItem127.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(252, comboBoxItem127.SelectedIndex);
            comboBoxItem128.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(254, comboBoxItem128.SelectedIndex);
            comboBoxItem129.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(256, comboBoxItem129.SelectedIndex);
            comboBoxItem130.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(258, comboBoxItem130.SelectedIndex);
            comboBoxItem131.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(260, comboBoxItem131.SelectedIndex);
            comboBoxItem132.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(262, comboBoxItem132.SelectedIndex);
            comboBoxItem133.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(264, comboBoxItem133.SelectedIndex);
            comboBoxItem134.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(266, comboBoxItem134.SelectedIndex);
            comboBoxItem135.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(268, comboBoxItem135.SelectedIndex);
            comboBoxItem136.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(270, comboBoxItem136.SelectedIndex);
            comboBoxItem137.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(272, comboBoxItem137.SelectedIndex);
            comboBoxItem138.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(274, comboBoxItem138.SelectedIndex);
            comboBoxItem139.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(276, comboBoxItem139.SelectedIndex);
            comboBoxItem140.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(278, comboBoxItem140.SelectedIndex);
            comboBoxItem141.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(280, comboBoxItem141.SelectedIndex);
            comboBoxItem142.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(282, comboBoxItem142.SelectedIndex);
            comboBoxItem143.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(284, comboBoxItem143.SelectedIndex);
            comboBoxItem144.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(286, comboBoxItem144.SelectedIndex);
            comboBoxItem145.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(288, comboBoxItem145.SelectedIndex);
            comboBoxItem146.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(290, comboBoxItem146.SelectedIndex);
            comboBoxItem147.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(292, comboBoxItem147.SelectedIndex);
            comboBoxItem148.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(294, comboBoxItem148.SelectedIndex);
            comboBoxItem149.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(296, comboBoxItem149.SelectedIndex);
            comboBoxItem150.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(298, comboBoxItem150.SelectedIndex);
            comboBoxItem151.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(300, comboBoxItem151.SelectedIndex);
            comboBoxItem152.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(302, comboBoxItem152.SelectedIndex);
            comboBoxItem153.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(304, comboBoxItem153.SelectedIndex);
            comboBoxItem154.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(306, comboBoxItem154.SelectedIndex);
            comboBoxItem155.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(308, comboBoxItem155.SelectedIndex);
            comboBoxItem156.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(310, comboBoxItem156.SelectedIndex);
            comboBoxItem157.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(312, comboBoxItem157.SelectedIndex);
            comboBoxItem158.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(314, comboBoxItem158.SelectedIndex);
            comboBoxItem159.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(316, comboBoxItem159.SelectedIndex);
            comboBoxItem160.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(318, comboBoxItem160.SelectedIndex);
            comboBoxItem161.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(320, comboBoxItem161.SelectedIndex);
            comboBoxItem162.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(322, comboBoxItem162.SelectedIndex);
            comboBoxItem163.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(324, comboBoxItem163.SelectedIndex);
            comboBoxItem164.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(326, comboBoxItem164.SelectedIndex);
            comboBoxItem165.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(328, comboBoxItem165.SelectedIndex);
            comboBoxItem166.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(330, comboBoxItem166.SelectedIndex);
            comboBoxItem167.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(332, comboBoxItem167.SelectedIndex);
            comboBoxItem168.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(334, comboBoxItem168.SelectedIndex);
            comboBoxItem169.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(336, comboBoxItem169.SelectedIndex);
            comboBoxItem170.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(338, comboBoxItem170.SelectedIndex);
            comboBoxItem171.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(340, comboBoxItem171.SelectedIndex);
            comboBoxItem172.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(342, comboBoxItem172.SelectedIndex);
            comboBoxItem173.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(344, comboBoxItem173.SelectedIndex);
            comboBoxItem174.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(346, comboBoxItem174.SelectedIndex);
            comboBoxItem175.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(348, comboBoxItem175.SelectedIndex);
            comboBoxItem176.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(350, comboBoxItem176.SelectedIndex);
            comboBoxItem177.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(352, comboBoxItem177.SelectedIndex);
            comboBoxItem178.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(354, comboBoxItem178.SelectedIndex);
            comboBoxItem179.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(356, comboBoxItem179.SelectedIndex);
            comboBoxItem180.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(358, comboBoxItem180.SelectedIndex);
            comboBoxItem181.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(360, comboBoxItem181.SelectedIndex);
            comboBoxItem182.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(362, comboBoxItem182.SelectedIndex);
            comboBoxItem183.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(364, comboBoxItem183.SelectedIndex);
            comboBoxItem184.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(366, comboBoxItem184.SelectedIndex);
            comboBoxItem185.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(368, comboBoxItem185.SelectedIndex);
            comboBoxItem186.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(370, comboBoxItem186.SelectedIndex);
            comboBoxItem187.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(372, comboBoxItem187.SelectedIndex);
            comboBoxItem188.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(374, comboBoxItem188.SelectedIndex);
            comboBoxItem189.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(376, comboBoxItem189.SelectedIndex);
            comboBoxItem190.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(378, comboBoxItem190.SelectedIndex);
            comboBoxItem191.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(380, comboBoxItem191.SelectedIndex);
            comboBoxItem192.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(382, comboBoxItem192.SelectedIndex);
            comboBoxItem193.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(384, comboBoxItem193.SelectedIndex);
            comboBoxItem194.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(386, comboBoxItem194.SelectedIndex);
            comboBoxItem195.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(388, comboBoxItem195.SelectedIndex);
            comboBoxItem196.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(390, comboBoxItem196.SelectedIndex);
            comboBoxItem197.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(392, comboBoxItem197.SelectedIndex);
            comboBoxItem198.SelectedIndexChanged += (sender, args) => InitWorker.UpdateVariable_Items(394, comboBoxItem198.SelectedIndex);

            numericUpDownItemQ1.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(1, numericUpDownItemQ1.Value);
            numericUpDownItemQ2.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(3, numericUpDownItemQ2.Value);
            numericUpDownItemQ3.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(5, numericUpDownItemQ3.Value);
            numericUpDownItemQ4.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(7, numericUpDownItemQ4.Value);
            numericUpDownItemQ5.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(9, numericUpDownItemQ5.Value);
            numericUpDownItemQ6.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(11, numericUpDownItemQ6.Value);
            numericUpDownItemQ7.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(13, numericUpDownItemQ7.Value);
            numericUpDownItemQ8.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(15, numericUpDownItemQ8.Value);
            numericUpDownItemQ9.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(17, numericUpDownItemQ9.Value);
            numericUpDownItemQ10.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(19, numericUpDownItemQ10.Value);
            numericUpDownItemQ11.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(21, numericUpDownItemQ11.Value);
            numericUpDownItemQ12.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(23, numericUpDownItemQ12.Value);
            numericUpDownItemQ13.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(25, numericUpDownItemQ13.Value);
            numericUpDownItemQ14.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(27, numericUpDownItemQ14.Value);
            numericUpDownItemQ15.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(29, numericUpDownItemQ15.Value);
            numericUpDownItemQ16.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(31, numericUpDownItemQ16.Value);
            numericUpDownItemQ17.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(33, numericUpDownItemQ17.Value);
            numericUpDownItemQ18.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(35, numericUpDownItemQ18.Value);
            numericUpDownItemQ19.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(37, numericUpDownItemQ19.Value);
            numericUpDownItemQ20.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(39, numericUpDownItemQ20.Value);
            numericUpDownItemQ21.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(41, numericUpDownItemQ21.Value);
            numericUpDownItemQ22.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(43, numericUpDownItemQ22.Value);
            numericUpDownItemQ23.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(45, numericUpDownItemQ23.Value);
            numericUpDownItemQ24.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(47, numericUpDownItemQ24.Value);
            numericUpDownItemQ25.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(49, numericUpDownItemQ25.Value);
            numericUpDownItemQ26.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(51, numericUpDownItemQ26.Value);
            numericUpDownItemQ27.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(53, numericUpDownItemQ27.Value);
            numericUpDownItemQ28.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(55, numericUpDownItemQ28.Value);
            numericUpDownItemQ29.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(57, numericUpDownItemQ29.Value);
            numericUpDownItemQ30.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(59, numericUpDownItemQ30.Value);
            numericUpDownItemQ31.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(61, numericUpDownItemQ31.Value);
            numericUpDownItemQ32.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(63, numericUpDownItemQ32.Value);
            numericUpDownItemQ33.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(65, numericUpDownItemQ33.Value);
            numericUpDownItemQ34.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(67, numericUpDownItemQ34.Value);
            numericUpDownItemQ35.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(69, numericUpDownItemQ35.Value);
            numericUpDownItemQ36.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(71, numericUpDownItemQ36.Value);
            numericUpDownItemQ37.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(73, numericUpDownItemQ37.Value);
            numericUpDownItemQ38.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(75, numericUpDownItemQ38.Value);
            numericUpDownItemQ39.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(77, numericUpDownItemQ39.Value);
            numericUpDownItemQ40.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(79, numericUpDownItemQ40.Value);
            numericUpDownItemQ41.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(81, numericUpDownItemQ41.Value);
            numericUpDownItemQ42.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(83, numericUpDownItemQ42.Value);
            numericUpDownItemQ43.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(85, numericUpDownItemQ43.Value);
            numericUpDownItemQ44.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(87, numericUpDownItemQ44.Value);
            numericUpDownItemQ45.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(89, numericUpDownItemQ45.Value);
            numericUpDownItemQ46.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(91, numericUpDownItemQ46.Value);
            numericUpDownItemQ47.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(93, numericUpDownItemQ47.Value);
            numericUpDownItemQ48.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(95, numericUpDownItemQ48.Value);
            numericUpDownItemQ49.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(97, numericUpDownItemQ49.Value);
            numericUpDownItemQ50.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(99, numericUpDownItemQ50.Value);
            numericUpDownItemQ51.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(101, numericUpDownItemQ51.Value);
            numericUpDownItemQ52.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(103, numericUpDownItemQ52.Value);
            numericUpDownItemQ53.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(105, numericUpDownItemQ53.Value);
            numericUpDownItemQ54.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(107, numericUpDownItemQ54.Value);
            numericUpDownItemQ55.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(109, numericUpDownItemQ55.Value);
            numericUpDownItemQ56.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(111, numericUpDownItemQ56.Value);
            numericUpDownItemQ57.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(113, numericUpDownItemQ57.Value);
            numericUpDownItemQ58.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(115, numericUpDownItemQ58.Value);
            numericUpDownItemQ59.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(117, numericUpDownItemQ59.Value);
            numericUpDownItemQ60.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(119, numericUpDownItemQ60.Value);
            numericUpDownItemQ61.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(121, numericUpDownItemQ61.Value);
            numericUpDownItemQ62.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(123, numericUpDownItemQ62.Value);
            numericUpDownItemQ63.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(125, numericUpDownItemQ63.Value);
            numericUpDownItemQ64.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(127, numericUpDownItemQ64.Value);
            numericUpDownItemQ65.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(129, numericUpDownItemQ65.Value);
            numericUpDownItemQ66.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(131, numericUpDownItemQ66.Value);
            numericUpDownItemQ67.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(133, numericUpDownItemQ67.Value);
            numericUpDownItemQ68.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(135, numericUpDownItemQ68.Value);
            numericUpDownItemQ69.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(137, numericUpDownItemQ69.Value);
            numericUpDownItemQ70.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(139, numericUpDownItemQ70.Value);
            numericUpDownItemQ71.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(141, numericUpDownItemQ71.Value);
            numericUpDownItemQ72.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(143, numericUpDownItemQ72.Value);
            numericUpDownItemQ73.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(145, numericUpDownItemQ73.Value);
            numericUpDownItemQ74.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(147, numericUpDownItemQ74.Value);
            numericUpDownItemQ75.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(149, numericUpDownItemQ75.Value);
            numericUpDownItemQ76.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(151, numericUpDownItemQ76.Value);
            numericUpDownItemQ77.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(153, numericUpDownItemQ77.Value);
            numericUpDownItemQ78.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(155, numericUpDownItemQ78.Value);
            numericUpDownItemQ79.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(157, numericUpDownItemQ79.Value);
            numericUpDownItemQ80.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(159, numericUpDownItemQ80.Value);
            numericUpDownItemQ81.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(161, numericUpDownItemQ81.Value);
            numericUpDownItemQ82.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(163, numericUpDownItemQ82.Value);
            numericUpDownItemQ83.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(165, numericUpDownItemQ83.Value);
            numericUpDownItemQ84.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(167, numericUpDownItemQ84.Value);
            numericUpDownItemQ85.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(169, numericUpDownItemQ85.Value);
            numericUpDownItemQ86.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(171, numericUpDownItemQ86.Value);
            numericUpDownItemQ87.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(173, numericUpDownItemQ87.Value);
            numericUpDownItemQ88.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(175, numericUpDownItemQ88.Value);
            numericUpDownItemQ89.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(177, numericUpDownItemQ89.Value);
            numericUpDownItemQ90.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(179, numericUpDownItemQ90.Value);
            numericUpDownItemQ91.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(181, numericUpDownItemQ91.Value);
            numericUpDownItemQ92.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(183, numericUpDownItemQ92.Value);
            numericUpDownItemQ93.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(185, numericUpDownItemQ93.Value);
            numericUpDownItemQ94.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(187, numericUpDownItemQ94.Value);
            numericUpDownItemQ95.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(189, numericUpDownItemQ95.Value);
            numericUpDownItemQ96.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(191, numericUpDownItemQ96.Value);
            numericUpDownItemQ97.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(193, numericUpDownItemQ97.Value);
            numericUpDownItemQ98.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(195, numericUpDownItemQ98.Value);
            numericUpDownItemQ99.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(197, numericUpDownItemQ99.Value);
            numericUpDownItemQ100.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(199, numericUpDownItemQ100.Value);
            numericUpDownItemQ101.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(201, numericUpDownItemQ101.Value);
            numericUpDownItemQ102.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(203, numericUpDownItemQ102.Value);
            numericUpDownItemQ103.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(205, numericUpDownItemQ103.Value);
            numericUpDownItemQ104.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(207, numericUpDownItemQ104.Value);
            numericUpDownItemQ105.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(209, numericUpDownItemQ105.Value);
            numericUpDownItemQ106.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(211, numericUpDownItemQ106.Value);
            numericUpDownItemQ107.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(213, numericUpDownItemQ107.Value);
            numericUpDownItemQ108.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(215, numericUpDownItemQ108.Value);
            numericUpDownItemQ109.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(217, numericUpDownItemQ109.Value);
            numericUpDownItemQ110.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(219, numericUpDownItemQ110.Value);
            numericUpDownItemQ111.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(221, numericUpDownItemQ111.Value);
            numericUpDownItemQ112.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(223, numericUpDownItemQ112.Value);
            numericUpDownItemQ113.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(225, numericUpDownItemQ113.Value);
            numericUpDownItemQ114.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(227, numericUpDownItemQ114.Value);
            numericUpDownItemQ115.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(229, numericUpDownItemQ115.Value);
            numericUpDownItemQ116.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(231, numericUpDownItemQ116.Value);
            numericUpDownItemQ117.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(233, numericUpDownItemQ117.Value);
            numericUpDownItemQ118.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(235, numericUpDownItemQ118.Value);
            numericUpDownItemQ119.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(237, numericUpDownItemQ119.Value);
            numericUpDownItemQ120.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(239, numericUpDownItemQ120.Value);
            numericUpDownItemQ121.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(241, numericUpDownItemQ121.Value);
            numericUpDownItemQ122.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(243, numericUpDownItemQ122.Value);
            numericUpDownItemQ123.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(245, numericUpDownItemQ123.Value);
            numericUpDownItemQ124.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(247, numericUpDownItemQ124.Value);
            numericUpDownItemQ125.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(249, numericUpDownItemQ125.Value);
            numericUpDownItemQ126.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(251, numericUpDownItemQ126.Value);
            numericUpDownItemQ127.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(253, numericUpDownItemQ127.Value);
            numericUpDownItemQ128.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(255, numericUpDownItemQ128.Value);
            numericUpDownItemQ129.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(257, numericUpDownItemQ129.Value);
            numericUpDownItemQ130.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(259, numericUpDownItemQ130.Value);
            numericUpDownItemQ131.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(261, numericUpDownItemQ131.Value);
            numericUpDownItemQ132.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(263, numericUpDownItemQ132.Value);
            numericUpDownItemQ133.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(265, numericUpDownItemQ133.Value);
            numericUpDownItemQ134.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(267, numericUpDownItemQ134.Value);
            numericUpDownItemQ135.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(269, numericUpDownItemQ135.Value);
            numericUpDownItemQ136.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(271, numericUpDownItemQ136.Value);
            numericUpDownItemQ137.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(273, numericUpDownItemQ137.Value);
            numericUpDownItemQ138.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(275, numericUpDownItemQ138.Value);
            numericUpDownItemQ139.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(277, numericUpDownItemQ139.Value);
            numericUpDownItemQ140.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(279, numericUpDownItemQ140.Value);
            numericUpDownItemQ141.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(281, numericUpDownItemQ141.Value);
            numericUpDownItemQ142.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(283, numericUpDownItemQ142.Value);
            numericUpDownItemQ143.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(285, numericUpDownItemQ143.Value);
            numericUpDownItemQ144.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(287, numericUpDownItemQ144.Value);
            numericUpDownItemQ145.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(289, numericUpDownItemQ145.Value);
            numericUpDownItemQ146.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(291, numericUpDownItemQ146.Value);
            numericUpDownItemQ147.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(293, numericUpDownItemQ147.Value);
            numericUpDownItemQ148.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(295, numericUpDownItemQ148.Value);
            numericUpDownItemQ149.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(297, numericUpDownItemQ149.Value);
            numericUpDownItemQ150.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(299, numericUpDownItemQ150.Value);
            numericUpDownItemQ151.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(301, numericUpDownItemQ151.Value);
            numericUpDownItemQ152.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(303, numericUpDownItemQ152.Value);
            numericUpDownItemQ153.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(305, numericUpDownItemQ153.Value);
            numericUpDownItemQ154.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(307, numericUpDownItemQ154.Value);
            numericUpDownItemQ155.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(309, numericUpDownItemQ155.Value);
            numericUpDownItemQ156.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(311, numericUpDownItemQ156.Value);
            numericUpDownItemQ157.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(313, numericUpDownItemQ157.Value);
            numericUpDownItemQ158.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(315, numericUpDownItemQ158.Value);
            numericUpDownItemQ159.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(317, numericUpDownItemQ159.Value);
            numericUpDownItemQ160.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(319, numericUpDownItemQ160.Value);
            numericUpDownItemQ161.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(321, numericUpDownItemQ161.Value);
            numericUpDownItemQ162.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(323, numericUpDownItemQ162.Value);
            numericUpDownItemQ163.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(325, numericUpDownItemQ163.Value);
            numericUpDownItemQ164.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(327, numericUpDownItemQ164.Value);
            numericUpDownItemQ165.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(329, numericUpDownItemQ165.Value);
            numericUpDownItemQ166.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(331, numericUpDownItemQ166.Value);
            numericUpDownItemQ167.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(333, numericUpDownItemQ167.Value);
            numericUpDownItemQ168.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(335, numericUpDownItemQ168.Value);
            numericUpDownItemQ169.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(337, numericUpDownItemQ169.Value);
            numericUpDownItemQ170.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(339, numericUpDownItemQ170.Value);
            numericUpDownItemQ171.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(341, numericUpDownItemQ171.Value);
            numericUpDownItemQ172.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(343, numericUpDownItemQ172.Value);
            numericUpDownItemQ173.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(345, numericUpDownItemQ173.Value);
            numericUpDownItemQ174.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(347, numericUpDownItemQ174.Value);
            numericUpDownItemQ175.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(349, numericUpDownItemQ175.Value);
            numericUpDownItemQ176.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(351, numericUpDownItemQ176.Value);
            numericUpDownItemQ177.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(353, numericUpDownItemQ177.Value);
            numericUpDownItemQ178.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(355, numericUpDownItemQ178.Value);
            numericUpDownItemQ179.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(357, numericUpDownItemQ179.Value);
            numericUpDownItemQ180.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(359, numericUpDownItemQ180.Value);
            numericUpDownItemQ181.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(361, numericUpDownItemQ181.Value);
            numericUpDownItemQ182.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(363, numericUpDownItemQ182.Value);
            numericUpDownItemQ183.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(365, numericUpDownItemQ183.Value);
            numericUpDownItemQ184.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(367, numericUpDownItemQ184.Value);
            numericUpDownItemQ185.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(369, numericUpDownItemQ185.Value);
            numericUpDownItemQ186.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(371, numericUpDownItemQ186.Value);
            numericUpDownItemQ187.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(373, numericUpDownItemQ187.Value);
            numericUpDownItemQ188.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(375, numericUpDownItemQ188.Value);
            numericUpDownItemQ189.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(377, numericUpDownItemQ189.Value);
            numericUpDownItemQ190.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(379, numericUpDownItemQ190.Value);
            numericUpDownItemQ191.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(381, numericUpDownItemQ191.Value);
            numericUpDownItemQ192.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(383, numericUpDownItemQ192.Value);
            numericUpDownItemQ193.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(385, numericUpDownItemQ193.Value);
            numericUpDownItemQ194.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(387, numericUpDownItemQ194.Value);
            numericUpDownItemQ195.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(389, numericUpDownItemQ195.Value);
            numericUpDownItemQ196.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(391, numericUpDownItemQ196.Value);
            numericUpDownItemQ197.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(393, numericUpDownItemQ197.Value);
            numericUpDownItemQ198.ValueChanged += (sender, args) => InitWorker.UpdateVariable_Items(395, numericUpDownItemQ198.Value);

            #endregion
        }

        #region Listviews selection style

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(listViewExCharactersList.Handle, "explorer", null);
            SetWindowTheme(listViewExGfList.Handle, "explorer", null);
        }

        #endregion        

        #region Listviews load images

        private void ListViewLoadImages()
        {
            //Characters
            imageListChar.ImageSize = new Size(32, 48);
            imageListChar.Images.Add(Resources.char0);
            imageListChar.Images.SetKeyName(0, "Squall");
            imageListChar.Images.Add(Resources.char1);
            imageListChar.Images.SetKeyName(1, "Zell");
            imageListChar.Images.Add(Resources.char2);
            imageListChar.Images.SetKeyName(2, "Irvine");
            imageListChar.Images.Add(Resources.char3);
            imageListChar.Images.SetKeyName(3, "Quistis");
            imageListChar.Images.Add(Resources.char4);
            imageListChar.Images.SetKeyName(4, "Rinoa");
            imageListChar.Images.Add(Resources.char5);
            imageListChar.Images.SetKeyName(5, "Selphie");
            imageListChar.Images.Add(Resources.char6);
            imageListChar.Images.SetKeyName(6, "Seifer");
            imageListChar.Images.Add(Resources.char7);
            imageListChar.Images.SetKeyName(7, "Edea");
            listViewExCharactersList.Items[0].ImageKey = "Squall";
            listViewExCharactersList.Items[1].ImageKey = "Zell";
            listViewExCharactersList.Items[2].ImageKey = "Irvine";
            listViewExCharactersList.Items[3].ImageKey = "Quistis";
            listViewExCharactersList.Items[4].ImageKey = "Rinoa";
            listViewExCharactersList.Items[5].ImageKey = "Selphie";
            listViewExCharactersList.Items[6].ImageKey = "Seifer";
            listViewExCharactersList.Items[7].ImageKey = "Edea";

            //GF Big
            imageListGfBig.ImageSize = new Size(32, 48);
            imageListGfBig.Images.Add(Resources.gf0);
            imageListGfBig.Images.SetKeyName(0, "Quezacotl");
            imageListGfBig.Images.Add(Resources.gf1);
            imageListGfBig.Images.SetKeyName(1, "Shiva");
            imageListGfBig.Images.Add(Resources.gf2);
            imageListGfBig.Images.SetKeyName(2, "Ifrit");
            imageListGfBig.Images.Add(Resources.gf3);
            imageListGfBig.Images.SetKeyName(3, "Siren");
            imageListGfBig.Images.Add(Resources.gf4);
            imageListGfBig.Images.SetKeyName(4, "Brothers");
            imageListGfBig.Images.Add(Resources.gf5);
            imageListGfBig.Images.SetKeyName(5, "Diablos");
            imageListGfBig.Images.Add(Resources.gf6);
            imageListGfBig.Images.SetKeyName(6, "Carbuncle");
            imageListGfBig.Images.Add(Resources.gf7);
            imageListGfBig.Images.SetKeyName(7, "Leviathan");
            imageListGfBig.Images.Add(Resources.gf8);
            imageListGfBig.Images.SetKeyName(8, "Pandemona");
            imageListGfBig.Images.Add(Resources.gf9);
            imageListGfBig.Images.SetKeyName(9, "Cerberus");
            imageListGfBig.Images.Add(Resources.gf10);
            imageListGfBig.Images.SetKeyName(10, "Alexander");
            imageListGfBig.Images.Add(Resources.gf11);
            imageListGfBig.Images.SetKeyName(11, "Doomtrain");
            imageListGfBig.Images.Add(Resources.gf12);
            imageListGfBig.Images.SetKeyName(12, "Bahamuth");
            imageListGfBig.Images.Add(Resources.gf13);
            imageListGfBig.Images.SetKeyName(13, "Cactuar");
            imageListGfBig.Images.Add(Resources.gf14);
            imageListGfBig.Images.SetKeyName(14, "Tonberry");
            imageListGfBig.Images.Add(Resources.gf15);
            imageListGfBig.Images.SetKeyName(15, "Eden");
            listViewExGfList.Items[0].ImageKey = "Quezacotl";
            listViewExGfList.Items[1].ImageKey = "Shiva";
            listViewExGfList.Items[2].ImageKey = "Ifrit";
            listViewExGfList.Items[3].ImageKey = "Siren";
            listViewExGfList.Items[4].ImageKey = "Brothers";
            listViewExGfList.Items[5].ImageKey = "Diablos";
            listViewExGfList.Items[6].ImageKey = "Carbuncle";
            listViewExGfList.Items[7].ImageKey = "Leviathan";
            listViewExGfList.Items[8].ImageKey = "Pandemona";
            listViewExGfList.Items[9].ImageKey = "Cerberus";
            listViewExGfList.Items[10].ImageKey = "Alexander";
            listViewExGfList.Items[11].ImageKey = "Doomtrain";
            listViewExGfList.Items[12].ImageKey = "Bahamuth";
            listViewExGfList.Items[13].ImageKey = "Cactuar";
            listViewExGfList.Items[14].ImageKey = "Tonberry";
            listViewExGfList.Items[15].ImageKey = "Eden";

            //GF Small
            imageListGfSmall.ImageSize = new Size(24, 36);
            imageListGfSmall.Images.Add(Resources.gf0);
            imageListGfSmall.Images.SetKeyName(0, "Quezacotl");
            imageListGfSmall.Images.Add(Resources.gf1);
            imageListGfSmall.Images.SetKeyName(1, "Shiva");
            imageListGfSmall.Images.Add(Resources.gf2);
            imageListGfSmall.Images.SetKeyName(2, "Ifrit");
            imageListGfSmall.Images.Add(Resources.gf3);
            imageListGfSmall.Images.SetKeyName(3, "Siren");
            imageListGfSmall.Images.Add(Resources.gf4);
            imageListGfSmall.Images.SetKeyName(4, "Brothers");
            imageListGfSmall.Images.Add(Resources.gf5);
            imageListGfSmall.Images.SetKeyName(5, "Diablos");
            imageListGfSmall.Images.Add(Resources.gf6);
            imageListGfSmall.Images.SetKeyName(6, "Carbuncle");
            imageListGfSmall.Images.Add(Resources.gf7);
            imageListGfSmall.Images.SetKeyName(7, "Leviathan");
            imageListGfSmall.Images.Add(Resources.gf8);
            imageListGfSmall.Images.SetKeyName(8, "Pandemona");
            imageListGfSmall.Images.Add(Resources.gf9);
            imageListGfSmall.Images.SetKeyName(9, "Cerberus");
            imageListGfSmall.Images.Add(Resources.gf10);
            imageListGfSmall.Images.SetKeyName(10, "Alexander");
            imageListGfSmall.Images.Add(Resources.gf11);
            imageListGfSmall.Images.SetKeyName(11, "Doomtrain");
            imageListGfSmall.Images.Add(Resources.gf12);
            imageListGfSmall.Images.SetKeyName(12, "Bahamuth");
            imageListGfSmall.Images.Add(Resources.gf13);
            imageListGfSmall.Images.SetKeyName(13, "Cactuar");
            imageListGfSmall.Images.Add(Resources.gf14);
            imageListGfSmall.Images.SetKeyName(14, "Tonberry");
            imageListGfSmall.Images.Add(Resources.gf15);
            imageListGfSmall.Images.SetKeyName(15, "Eden");
            checkBoxCharsGf1.ImageKey = "Quezacotl";
            checkBoxCharsGf2.ImageKey = "Shiva";
            checkBoxCharsGf3.ImageKey = "Ifrit";
            checkBoxCharsGf4.ImageKey = "Siren";
            checkBoxCharsGf5.ImageKey = "Brothers";
            checkBoxCharsGf6.ImageKey = "Diablos";
            checkBoxCharsGf7.ImageKey = "Carbuncle";
            checkBoxCharsGf8.ImageKey = "Leviathan";
            checkBoxCharsGf9.ImageKey = "Pandemona";
            checkBoxCharsGf10.ImageKey = "Cerberus";
            checkBoxCharsGf11.ImageKey = "Alexander";
            checkBoxCharsGf12.ImageKey = "Doomtrain";
            checkBoxCharsGf13.ImageKey = "Bahamuth";
            checkBoxCharsGf14.ImageKey = "Cactuar";
            checkBoxCharsGf15.ImageKey = "Tonberry";
            checkBoxCharsGf16.ImageKey = "Eden";
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
                    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.ReadWrite))
                    {
                        using (var BR = new BinaryReader(fileStream))
                        {
                            InitWorker.ReadInit(BR.ReadBytes((int)fileStream.Length));

                            if (fileStream.Length <= 2812)
                            {
                                var emptyBytes = new byte[388];
                                fileStream.Seek(0, SeekOrigin.End);
                                fileStream.Write(emptyBytes, 0, emptyBytes.Length);
                            }
                        }
                        CreateTooltipsFile();
                        InitItems();
                    }
                    _existingFilename = openFileDialog.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot open the file {0}, maybe it's locked by another software?", Path.GetFileName(openFileDialog.FileName)), "Error Opening File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    _opensaveException = true;
                }

                if (!_opensaveException)
                {
                    labelCharsLevelValue.Enabled = true;
                    panelCharsLevel.Enabled = true;
                    numericUpDownCharsExpLvUp.Enabled = true;                    
                    labelGfLevelValue.Enabled = true;
                    panelGfLevel.Enabled = true;
                    numericUpDownGfExpLvUp.Enabled = true;                    
                    buttonSave.Enabled = true;
                    buttonSaveAs.Enabled = true;

                    numericUpDownCharsExpLvUp.Value = 1000;
                    numericUpDownGfExpLvUp.Value = 1000;

                    toolTip1.SetToolTip(numericUpDownCharsExpLvUp, "The Exp required to level up is in kernel.bin.\n" +
                        "This is here only to help you calculate the current level, it does nothing to init.out.");
                    toolTip1.SetToolTip(numericUpDownGfExpLvUp, "The Exp required to level up is in kernel.bin.\n" +
                        "This is here only to help you calculate the current level, it does nothing to init.out.");

                    listViewExCharactersList.Items[0].Selected = true;
                    listViewExGfList.Items[0].Selected = true;

                    CheckIfAllGfsAreChecked();

                    toolStripStatusLabelStatus.Text = Path.GetFileName(_existingFilename) + " loaded successfully";
                    toolStripStatusLabelInit.Text = Path.GetFileName(_existingFilename) + " loaded";
                    statusStrip1.BackColor = Color.FromArgb(255, 25, 170, 30);
                    toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 25, 170, 30);
                    await Task.Delay(3000);
                    statusStrip1.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.Text = "Ready";
                }
                _opensaveException = false;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(_existingFilename)) && InitWorker.Init != null)
            {
                try
                {
                    File.WriteAllBytes(_existingFilename, InitWorker.Init);

                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot save the file {0}, maybe it's locked by another software?", Path.GetFileName(_existingFilename)), "Error Saving File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    _opensaveException = true;
                }

                if (!_opensaveException)
                {
                    statusStrip1.BackColor = Color.FromArgb(255, 25, 170, 30);
                    toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 25, 170, 30);
                    toolStripStatusLabelStatus.Text = Path.GetFileName(_existingFilename) + " saved successfully";
                    await Task.Delay(3000);
                    statusStrip1.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.Text = "Ready";
                }
                _opensaveException = false;
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
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show
                        (String.Format("I cannot save the file {0}, maybe it's locked by another software?", Path.GetFileName(saveAsDialog.FileName)), "Error Saving File",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    _opensaveException = true;
                }
                if (!_opensaveException)
                {
                    statusStrip1.BackColor = Color.FromArgb(255, 25, 170, 30);
                    toolStripStatusLabelStatus.BackColor = Color.FromArgb(255, 25, 170, 30);
                    toolStripStatusLabelStatus.Text = Path.GetFileName(_existingFilename) + " saved successfully";
                    await Task.Delay(3000);
                    statusStrip1.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.BackColor = Color.Gray;
                    toolStripStatusLabelStatus.Text = "Ready";
                }
                _opensaveException = false;
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

        private void buttonDeleteTooltips_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will delete the tooltips.bin file. " +
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
                        buttonDeleteTooltips.Enabled = false;
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
                case _bp_hex:
                    {
                        toolTip1.SetToolTip(control, $"Default: 0x{Convert.ToSByte(value).ToString("X2")}");
                        break;
                    }
                default:
                    goto case _bp_numerical;
            }
        }


        #endregion

        #region Characters level calculator 

        private void CharacterLevel()
        {
            if (InitWorker.Init == null || InitWorker.BackupInit == null)
                return;

            uint charLevel = ((uint)numericUpDownCharsExp.Value / (uint)numericUpDownCharsExpLvUp.Value) + 1;
            if (charLevel > 100)
                charLevel = 100;

            labelCharsLevelValue.Text = charLevel.ToString();
        }

        private void numericUpDownCharExp_ValueChanged(object sender, EventArgs e)
        {
            CharacterLevel();
        }

        private void numericUpDownCharExpLvUp_ValueChanged(object sender, EventArgs e)
        {
            CharacterLevel();
        }

        #endregion

        #region GFs level calculator 

        private void GfLevel()
        {
            if (InitWorker.Init == null || InitWorker.BackupInit == null)
                return;

            uint gfLevel = ((uint)numericUpDownGfExp.Value / (uint)numericUpDownGfExpLvUp.Value) + 1;
            if (gfLevel > 100)
                gfLevel = 100;

            labelGfLevelValue.Text = gfLevel.ToString();
        }

        private void numericUpDownGfExp_ValueChanged(object sender, EventArgs e)
        {
            GfLevel();
        }

        private void numericUpDownGfExpLvUp_ValueChanged(object sender, EventArgs e)
        {
            GfLevel();
        }

        #endregion

        #region Characters Gf edit all together

        private void CheckBoxCharsGfAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCharsGfAll.Checked == true)
            {
                checkBoxCharsGf1.Checked = true;
                checkBoxCharsGf2.Checked = true;
                checkBoxCharsGf3.Checked = true;
                checkBoxCharsGf4.Checked = true;
                checkBoxCharsGf5.Checked = true;
                checkBoxCharsGf6.Checked = true;
                checkBoxCharsGf7.Checked = true;
                checkBoxCharsGf8.Checked = true;
                checkBoxCharsGf9.Checked = true;
                checkBoxCharsGf10.Checked = true;
                checkBoxCharsGf11.Checked = true;
                checkBoxCharsGf12.Checked = true;
                checkBoxCharsGf13.Checked = true;
                checkBoxCharsGf14.Checked = true;
                checkBoxCharsGf15.Checked = true;
                checkBoxCharsGf16.Checked = true;
            }
            else if (checkBoxCharsGfAll.Checked == false)
            {
                checkBoxCharsGf1.Checked = false;
                checkBoxCharsGf2.Checked = false;
                checkBoxCharsGf3.Checked = false;
                checkBoxCharsGf4.Checked = false;
                checkBoxCharsGf5.Checked = false;
                checkBoxCharsGf6.Checked = false;
                checkBoxCharsGf7.Checked = false;
                checkBoxCharsGf8.Checked = false;
                checkBoxCharsGf9.Checked = false;
                checkBoxCharsGf10.Checked = false;
                checkBoxCharsGf11.Checked = false;
                checkBoxCharsGf12.Checked = false;
                checkBoxCharsGf13.Checked = false;
                checkBoxCharsGf14.Checked = false;
                checkBoxCharsGf15.Checked = false;
                checkBoxCharsGf16.Checked = false;
            }
        }

        private void CheckIfAllGfsAreChecked()
        {
            if (checkBoxCharsGf1.Checked == true && checkBoxCharsGf2.Checked == true &&
                checkBoxCharsGf3.Checked == true && checkBoxCharsGf4.Checked == true &&
                checkBoxCharsGf5.Checked == true && checkBoxCharsGf6.Checked == true &&
                checkBoxCharsGf7.Checked == true && checkBoxCharsGf8.Checked == true &&
                checkBoxCharsGf9.Checked == true && checkBoxCharsGf10.Checked == true &&
                checkBoxCharsGf11.Checked == true && checkBoxCharsGf12.Checked == true &&
                checkBoxCharsGf13.Checked == true && checkBoxCharsGf14.Checked == true &&
                checkBoxCharsGf15.Checked == true && checkBoxCharsGf16.Checked == true)

                checkBoxCharsGfAll.Checked = true;

            else
                checkBoxCharsGfAll.Checked = false;
        }

        private void ButtonCharsGfApplyCompAll_Click(object sender, EventArgs e)
        {
            numericUpDownGfComp1.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp2.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp3.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp4.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp5.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp6.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp7.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp8.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp9.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp10.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp11.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp12.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp13.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp14.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp15.Value = numericUpDownCharsAllGfComp.Value;
            numericUpDownGfComp16.Value = numericUpDownCharsAllGfComp.Value;
        }

        #endregion

        #region Listbox show/hide panels

        private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMain.SelectedIndex == 0)
            {
                panelCharacters.Visible = true;
                panelGf.Visible = false;
                panelItems.Visible = false;
                panelMisc.Visible = false;
            }
            else if (listBoxMain.SelectedIndex == 1)
            {
                panelCharacters.Visible = false;
                panelGf.Visible = true;
                panelItems.Visible = false;
                panelMisc.Visible = false;
            }
            else if (listBoxMain.SelectedIndex == 2)
            {
                panelCharacters.Visible = false;
                panelGf.Visible = false;
                panelItems.Visible = true;
                panelMisc.Visible = false;
            }
            else if (listBoxMain.SelectedIndex == 3)
            {
                panelCharacters.Visible = false;
                panelGf.Visible = false;
                panelItems.Visible = false;
                panelMisc.Visible = true;
            }
        }

        #endregion

        #region Loader loops + give focus after load

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxMain.Items.Count; i++)
                listBoxMain.SelectedIndex = i;
            listBoxMain.SelectedIndex = 0;

            for (int i = 0; i < tabControlCharacters.TabPages.Count; i++)
                tabControlCharacters.SelectedIndex = i;
            tabControlCharacters.SelectedIndex = 0;

            for (int i = 0; i < tabControlGf.TabPages.Count; i++)
                tabControlGf.SelectedIndex = i;
            tabControlGf.SelectedIndex = 0;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Focus();
        }

        #endregion


        #region Init data to gui

        private void listViewExCharactersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewExCharactersList.Items[0].Selected || listViewExCharactersList.Items[6].Selected || listViewExCharactersList.Items[7].Selected)
            {
                tabPageChars6.Enabled = false;
                tabPageChars6.Visible = false;
            }
            else
                tabPageChars6.Enabled = true;

            _loaded = false;
            if (InitWorker.Init == null || InitWorker.BackupInit == null)
                return;

            int CharList = 0;
            if (listViewExCharactersList.SelectedItems.Count > 0)
                CharList = listViewExCharactersList.SelectedIndices[0];

            InitWorker.ReadCharacters(CharList, InitWorker.BackupInit);
            try
            {
                ToolTip(numericUpDownCharsCurrentHp, 0, InitWorker.GetSelectedCharactersData.CurrentHp);
                ToolTip(numericUpDownCharsHpBonus, 0, InitWorker.GetSelectedCharactersData.HpBonus);
                ToolTip(numericUpDownCharsExp, 0, InitWorker.GetSelectedCharactersData.Exp);
                ToolTip(comboBoxCharsBody, 2, comboBoxCharsBody.Items[InitWorker.GetSelectedCharactersData.ModelId]);
                ToolTip(comboBoxCharsWeapon, 2, comboBoxCharsWeapon.Items[InitWorker.GetSelectedCharactersData.WeaponId]);
                ToolTip(numericUpDownCharsStrBonus, 0, InitWorker.GetSelectedCharactersData.Str);
                ToolTip(numericUpDownCharsVitBonus, 0, InitWorker.GetSelectedCharactersData.Vit);
                ToolTip(numericUpDownCharsMagBonus, 0, InitWorker.GetSelectedCharactersData.Mag);
                ToolTip(numericUpDownCharsSprBonus, 0, InitWorker.GetSelectedCharactersData.Spr);
                ToolTip(numericUpDownCharsSpdBonus, 0, InitWorker.GetSelectedCharactersData.Spd);
                ToolTip(numericUpDownCharsLuckBonus, 0, InitWorker.GetSelectedCharactersData.Luck);
                ToolTip(comboBoxCharsMagic1, 2, comboBoxCharsMagic1.Items[InitWorker.GetSelectedCharactersData.Magic1]);
                ToolTip(numericUpDownCharsMagicQ1, 0, InitWorker.GetSelectedCharactersData.Magic1Quantity);
                ToolTip(comboBoxCharsMagic2, 2, comboBoxCharsMagic2.Items[InitWorker.GetSelectedCharactersData.Magic2]);
                ToolTip(numericUpDownCharsMagicQ2, 0, InitWorker.GetSelectedCharactersData.Magic2Quantity);
                ToolTip(comboBoxCharsMagic3, 2, comboBoxCharsMagic3.Items[InitWorker.GetSelectedCharactersData.Magic3]);
                ToolTip(numericUpDownCharsMagicQ3, 0, InitWorker.GetSelectedCharactersData.Magic3Quantity);
                ToolTip(comboBoxCharsMagic4, 2, comboBoxCharsMagic4.Items[InitWorker.GetSelectedCharactersData.Magic4]);
                ToolTip(numericUpDownCharsMagicQ4, 0, InitWorker.GetSelectedCharactersData.Magic4Quantity);
                ToolTip(comboBoxCharsMagic5, 2, comboBoxCharsMagic5.Items[InitWorker.GetSelectedCharactersData.Magic5]);
                ToolTip(numericUpDownCharsMagicQ5, 0, InitWorker.GetSelectedCharactersData.Magic5Quantity);
                ToolTip(comboBoxCharsMagic6, 2, comboBoxCharsMagic6.Items[InitWorker.GetSelectedCharactersData.Magic6]);
                ToolTip(numericUpDownCharsMagicQ6, 0, InitWorker.GetSelectedCharactersData.Magic6Quantity);
                ToolTip(comboBoxCharsMagic7, 2, comboBoxCharsMagic7.Items[InitWorker.GetSelectedCharactersData.Magic7]);
                ToolTip(numericUpDownCharsMagicQ7, 0, InitWorker.GetSelectedCharactersData.Magic7Quantity);
                ToolTip(comboBoxCharsMagic8, 2, comboBoxCharsMagic8.Items[InitWorker.GetSelectedCharactersData.Magic8]);
                ToolTip(numericUpDownCharsMagicQ8, 0, InitWorker.GetSelectedCharactersData.Magic8Quantity);
                ToolTip(comboBoxCharsMagic9, 2, comboBoxCharsMagic9.Items[InitWorker.GetSelectedCharactersData.Magic9]);
                ToolTip(numericUpDownCharsMagicQ9, 0, InitWorker.GetSelectedCharactersData.Magic9Quantity);
                ToolTip(comboBoxCharsMagic10, 2, comboBoxCharsMagic10.Items[InitWorker.GetSelectedCharactersData.Magic10]);
                ToolTip(numericUpDownCharsMagicQ10, 0, InitWorker.GetSelectedCharactersData.Magic10Quantity);
                ToolTip(comboBoxCharsMagic11, 2, comboBoxCharsMagic11.Items[InitWorker.GetSelectedCharactersData.Magic11]);
                ToolTip(numericUpDownCharsMagicQ11, 0, InitWorker.GetSelectedCharactersData.Magic11Quantity);
                ToolTip(comboBoxCharsMagic12, 2, comboBoxCharsMagic12.Items[InitWorker.GetSelectedCharactersData.Magic12]);
                ToolTip(numericUpDownCharsMagicQ12, 0, InitWorker.GetSelectedCharactersData.Magic12Quantity);
                ToolTip(comboBoxCharsMagic13, 2, comboBoxCharsMagic13.Items[InitWorker.GetSelectedCharactersData.Magic13]);
                ToolTip(numericUpDownCharsMagicQ13, 0, InitWorker.GetSelectedCharactersData.Magic13Quantity);
                ToolTip(comboBoxCharsMagic14, 2, comboBoxCharsMagic14.Items[InitWorker.GetSelectedCharactersData.Magic14]);
                ToolTip(numericUpDownCharsMagicQ14, 0, InitWorker.GetSelectedCharactersData.Magic14Quantity);
                ToolTip(comboBoxCharsMagic15, 2, comboBoxCharsMagic15.Items[InitWorker.GetSelectedCharactersData.Magic15]);
                ToolTip(numericUpDownCharsMagicQ15, 0, InitWorker.GetSelectedCharactersData.Magic15Quantity);
                ToolTip(comboBoxCharsMagic16, 2, comboBoxCharsMagic16.Items[InitWorker.GetSelectedCharactersData.Magic16]);
                ToolTip(numericUpDownCharsMagicQ16, 0, InitWorker.GetSelectedCharactersData.Magic16Quantity);
                ToolTip(comboBoxCharsMagic17, 2, comboBoxCharsMagic17.Items[InitWorker.GetSelectedCharactersData.Magic17]);
                ToolTip(numericUpDownCharsMagicQ17, 0, InitWorker.GetSelectedCharactersData.Magic17Quantity);
                ToolTip(comboBoxCharsMagic18, 2, comboBoxCharsMagic18.Items[InitWorker.GetSelectedCharactersData.Magic18]);
                ToolTip(numericUpDownCharsMagicQ18, 0, InitWorker.GetSelectedCharactersData.Magic18Quantity);
                ToolTip(comboBoxCharsMagic19, 2, comboBoxCharsMagic19.Items[InitWorker.GetSelectedCharactersData.Magic19]);
                ToolTip(numericUpDownCharsMagicQ19, 0, InitWorker.GetSelectedCharactersData.Magic19Quantity);
                ToolTip(comboBoxCharsMagic20, 2, comboBoxCharsMagic20.Items[InitWorker.GetSelectedCharactersData.Magic20]);
                ToolTip(numericUpDownCharsMagicQ20, 0, InitWorker.GetSelectedCharactersData.Magic20Quantity);
                ToolTip(comboBoxCharsMagic21, 2, comboBoxCharsMagic21.Items[InitWorker.GetSelectedCharactersData.Magic21]);
                ToolTip(numericUpDownCharsMagicQ21, 0, InitWorker.GetSelectedCharactersData.Magic21Quantity);
                ToolTip(comboBoxCharsMagic22, 2, comboBoxCharsMagic22.Items[InitWorker.GetSelectedCharactersData.Magic22]);
                ToolTip(numericUpDownCharsMagicQ22, 0, InitWorker.GetSelectedCharactersData.Magic22Quantity);
                ToolTip(comboBoxCharsMagic23, 2, comboBoxCharsMagic23.Items[InitWorker.GetSelectedCharactersData.Magic23]);
                ToolTip(numericUpDownCharsMagicQ23, 0, InitWorker.GetSelectedCharactersData.Magic23Quantity);
                ToolTip(comboBoxCharsMagic24, 2, comboBoxCharsMagic24.Items[InitWorker.GetSelectedCharactersData.Magic24]);
                ToolTip(numericUpDownCharsMagicQ24, 0, InitWorker.GetSelectedCharactersData.Magic24Quantity);
                ToolTip(comboBoxCharsMagic25, 2, comboBoxCharsMagic25.Items[InitWorker.GetSelectedCharactersData.Magic25]);
                ToolTip(numericUpDownCharsMagicQ25, 0, InitWorker.GetSelectedCharactersData.Magic25Quantity);
                ToolTip(comboBoxCharsMagic26, 2, comboBoxCharsMagic26.Items[InitWorker.GetSelectedCharactersData.Magic26]);
                ToolTip(numericUpDownCharsMagicQ26, 0, InitWorker.GetSelectedCharactersData.Magic26Quantity);
                ToolTip(comboBoxCharsMagic27, 2, comboBoxCharsMagic27.Items[InitWorker.GetSelectedCharactersData.Magic27]);
                ToolTip(numericUpDownCharsMagicQ27, 0, InitWorker.GetSelectedCharactersData.Magic27Quantity);
                ToolTip(comboBoxCharsMagic28, 2, comboBoxCharsMagic28.Items[InitWorker.GetSelectedCharactersData.Magic28]);
                ToolTip(numericUpDownCharsMagicQ28, 0, InitWorker.GetSelectedCharactersData.Magic28Quantity);
                ToolTip(comboBoxCharsMagic29, 2, comboBoxCharsMagic29.Items[InitWorker.GetSelectedCharactersData.Magic29]);
                ToolTip(numericUpDownCharsMagicQ29, 0, InitWorker.GetSelectedCharactersData.Magic29Quantity);
                ToolTip(comboBoxCharsMagic30, 2, comboBoxCharsMagic30.Items[InitWorker.GetSelectedCharactersData.Magic30]);
                ToolTip(numericUpDownCharsMagicQ30, 0, InitWorker.GetSelectedCharactersData.Magic30Quantity);
                ToolTip(comboBoxCharsMagic31, 2, comboBoxCharsMagic31.Items[InitWorker.GetSelectedCharactersData.Magic31]);
                ToolTip(numericUpDownCharsMagicQ31, 0, InitWorker.GetSelectedCharactersData.Magic31Quantity);
                ToolTip(comboBoxCharsMagic32, 2, comboBoxCharsMagic32.Items[InitWorker.GetSelectedCharactersData.Magic32]);
                ToolTip(numericUpDownCharsMagicQ32, 0, InitWorker.GetSelectedCharactersData.Magic32Quantity);
                ToolTip(comboBoxCharsComm1, 2, comboBoxCharsComm1.Items[InitWorker.GetSelectedCharactersData.Command1]);
                ToolTip(comboBoxCharsComm2, 2, comboBoxCharsComm2.Items[InitWorker.GetSelectedCharactersData.Command2]);
                ToolTip(comboBoxCharsComm3, 2, comboBoxCharsComm3.Items[InitWorker.GetSelectedCharactersData.Command3]);
                ToolTip(hexUpDownCharUnk1, 3, InitWorker.GetSelectedCharactersData.Unknown1);
                ToolTip(comboBoxCharsAb1, 2, comboBoxCharsAb1.Items[InitWorker.GetSelectedCharactersData.Ability1]);
                ToolTip(comboBoxCharsAb2, 2, comboBoxCharsAb2.Items[InitWorker.GetSelectedCharactersData.Ability2]);
                ToolTip(comboBoxCharsAb3, 2, comboBoxCharsAb3.Items[InitWorker.GetSelectedCharactersData.Ability3]);
                ToolTip(comboBoxCharsAb4, 2, comboBoxCharsAb4.Items[InitWorker.GetSelectedCharactersData.Ability4]);
                ToolTip(checkBoxCharsGf1, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf2, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf3, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf4, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf5, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf6, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf7, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf8, 1, (InitWorker.GetSelectedCharactersData.JunGf1 & 0x80) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf9, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf10, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf11, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf12, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf13, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf14, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf15, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxCharsGf16, 1, (InitWorker.GetSelectedCharactersData.JunGf2 & 0x80) >= 1 ? true : false);
                ToolTip(hexUpDownCharUnk2, 3, InitWorker.GetSelectedCharactersData.Unknown2);
                ToolTip(checkBoxCharsAltMod, 1, (InitWorker.GetSelectedCharactersData.AltModel & 0x01) >= 1 ? true : false);
                ToolTip(comboBoxCharsJunHp, 2, comboBoxCharsJunHp.Items[InitWorker.GetSelectedCharactersData.JunHP]);
                ToolTip(comboBoxCharsJunStr, 2, comboBoxCharsJunStr.Items[InitWorker.GetSelectedCharactersData.JunStr]);
                ToolTip(comboBoxCharsJunVit, 2, comboBoxCharsJunVit.Items[InitWorker.GetSelectedCharactersData.JunVit]);
                ToolTip(comboBoxCharsJunMag, 2, comboBoxCharsJunMag.Items[InitWorker.GetSelectedCharactersData.JunMag]);
                ToolTip(comboBoxCharsJunSpr, 2, comboBoxCharsJunSpr.Items[InitWorker.GetSelectedCharactersData.JunSpr]);
                ToolTip(comboBoxCharsJunSpd, 2, comboBoxCharsJunSpd.Items[InitWorker.GetSelectedCharactersData.JunSpd]);
                ToolTip(comboBoxCharsJunEva, 2, comboBoxCharsJunEva.Items[InitWorker.GetSelectedCharactersData.JunEva]);
                ToolTip(comboBoxCharsJunHit, 2, comboBoxCharsJunHit.Items[InitWorker.GetSelectedCharactersData.JunHit]);
                ToolTip(comboBoxCharsJunLuck, 2, comboBoxCharsJunLuck.Items[InitWorker.GetSelectedCharactersData.JunLuck]);
                ToolTip(comboBoxCharsElemAtk, 2, comboBoxCharsElemAtk.Items[InitWorker.GetSelectedCharactersData.JunEleAtk]);
                ToolTip(comboBoxCharsStatusAtk, 2, comboBoxCharsStatusAtk.Items[InitWorker.GetSelectedCharactersData.JunStatusAtk]);
                ToolTip(comboBoxCharsElemDef1, 2, comboBoxCharsElemDef1.Items[InitWorker.GetSelectedCharactersData.JunEleDef1]);
                ToolTip(comboBoxCharsElemDef2, 2, comboBoxCharsElemDef2.Items[InitWorker.GetSelectedCharactersData.JunEleDef2]);
                ToolTip(comboBoxCharsElemDef3, 2, comboBoxCharsElemDef3.Items[InitWorker.GetSelectedCharactersData.JunEleDef3]);
                ToolTip(comboBoxCharsElemDef4, 2, comboBoxCharsElemDef4.Items[InitWorker.GetSelectedCharactersData.JunEleDef4]);
                ToolTip(comboBoxCharsStatusDef1, 2, comboBoxCharsStatusDef1.Items[InitWorker.GetSelectedCharactersData.JunStatusDef1]);
                ToolTip(comboBoxCharsStatusDef2, 2, comboBoxCharsStatusDef2.Items[InitWorker.GetSelectedCharactersData.JunStatusDef2]);
                ToolTip(comboBoxCharsStatusDef3, 2, comboBoxCharsStatusDef3.Items[InitWorker.GetSelectedCharactersData.JunStatusDef3]);
                ToolTip(comboBoxCharsStatusDef4, 2, comboBoxCharsStatusDef4.Items[InitWorker.GetSelectedCharactersData.JunStatusDef4]);
                ToolTip(hexUpDownCharUnk3, 3, InitWorker.GetSelectedCharactersData.Unknown3);
                ToolTip(numericUpDownGfComp1, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp1) / 5);
                ToolTip(numericUpDownGfComp2, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp2) / 5);
                ToolTip(numericUpDownGfComp3, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp3) / 5);
                ToolTip(numericUpDownGfComp4, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp4) / 5);
                ToolTip(numericUpDownGfComp5, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp5) / 5);
                ToolTip(numericUpDownGfComp6, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp6) / 5);
                ToolTip(numericUpDownGfComp7, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp7) / 5);
                ToolTip(numericUpDownGfComp8, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp8) / 5);
                ToolTip(numericUpDownGfComp9, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp9) / 5);
                ToolTip(numericUpDownGfComp10, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp10) / 5);
                ToolTip(numericUpDownGfComp11, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp11) / 5);
                ToolTip(numericUpDownGfComp12, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp12) / 5);
                ToolTip(numericUpDownGfComp13, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp13) / 5);
                ToolTip(numericUpDownGfComp14, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp14) / 5);
                ToolTip(numericUpDownGfComp15, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp15) / 5);
                ToolTip(numericUpDownGfComp16, 0, (6000 - InitWorker.GetSelectedCharactersData.GfComp16) / 5);
                ToolTip(numericUpDownCharsKills, 0, InitWorker.GetSelectedCharactersData.Kills);
                ToolTip(numericUpDownCharsKOs, 0, InitWorker.GetSelectedCharactersData.KOs);
                ToolTip(checkBoxCharsAvailable, 1, (InitWorker.GetSelectedCharactersData.Exist & 0x01) >= 1 ? true : false);
                ToolTip(hexUpDownCharUnk4, 3, InitWorker.GetSelectedCharactersData.Unknown4);
                ToolTip(checkBoxCharStatus1, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x01) >= 1 ? true : false);
                ToolTip(checkBoxCharStatus2, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x02) >= 1 ? true : false);
                ToolTip(checkBoxCharStatus3, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x04) >= 1 ? true : false);
                ToolTip(checkBoxCharStatus4, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x08) >= 1 ? true : false);
                ToolTip(checkBoxCharStatus5, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x10) >= 1 ? true : false);
                ToolTip(checkBoxCharStatus6, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x20) >= 1 ? true : false);
                ToolTip(checkBoxCharStatus7, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x40) >= 1 ? true : false);
                ToolTip(checkBoxCharStatus8, 1, (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x80) >= 1 ? true : false);
                ToolTip(hexUpDownCharUnk5, 3, InitWorker.GetSelectedCharactersData.Unknown5);
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
                numericUpDownCharsStrBonus.Value = InitWorker.GetSelectedCharactersData.Str;
                numericUpDownCharsVitBonus.Value = InitWorker.GetSelectedCharactersData.Vit;
                numericUpDownCharsMagBonus.Value = InitWorker.GetSelectedCharactersData.Mag;
                numericUpDownCharsSprBonus.Value = InitWorker.GetSelectedCharactersData.Spr;
                numericUpDownCharsSpdBonus.Value = InitWorker.GetSelectedCharactersData.Spd;
                numericUpDownCharsLuckBonus.Value = InitWorker.GetSelectedCharactersData.Luck;
                comboBoxCharsMagic1.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic1;
                numericUpDownCharsMagicQ1.Value = InitWorker.GetSelectedCharactersData.Magic1Quantity;
                comboBoxCharsMagic2.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic2;
                numericUpDownCharsMagicQ2.Value = InitWorker.GetSelectedCharactersData.Magic2Quantity;
                comboBoxCharsMagic3.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic3;
                numericUpDownCharsMagicQ3.Value = InitWorker.GetSelectedCharactersData.Magic3Quantity;
                comboBoxCharsMagic4.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic4;
                numericUpDownCharsMagicQ4.Value = InitWorker.GetSelectedCharactersData.Magic4Quantity;
                comboBoxCharsMagic5.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic5;
                numericUpDownCharsMagicQ5.Value = InitWorker.GetSelectedCharactersData.Magic5Quantity;
                comboBoxCharsMagic6.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic6;
                numericUpDownCharsMagicQ6.Value = InitWorker.GetSelectedCharactersData.Magic6Quantity;
                comboBoxCharsMagic7.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic7;
                numericUpDownCharsMagicQ7.Value = InitWorker.GetSelectedCharactersData.Magic7Quantity;
                comboBoxCharsMagic8.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic8;
                numericUpDownCharsMagicQ8.Value = InitWorker.GetSelectedCharactersData.Magic8Quantity;
                comboBoxCharsMagic9.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic9;
                numericUpDownCharsMagicQ9.Value = InitWorker.GetSelectedCharactersData.Magic9Quantity;
                comboBoxCharsMagic10.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic10;
                numericUpDownCharsMagicQ10.Value = InitWorker.GetSelectedCharactersData.Magic10Quantity;
                comboBoxCharsMagic11.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic11;
                numericUpDownCharsMagicQ11.Value = InitWorker.GetSelectedCharactersData.Magic11Quantity;
                comboBoxCharsMagic12.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic12;
                numericUpDownCharsMagicQ12.Value = InitWorker.GetSelectedCharactersData.Magic12Quantity;
                comboBoxCharsMagic13.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic13;
                numericUpDownCharsMagicQ13.Value = InitWorker.GetSelectedCharactersData.Magic13Quantity;
                comboBoxCharsMagic14.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic14;
                numericUpDownCharsMagicQ14.Value = InitWorker.GetSelectedCharactersData.Magic14Quantity;
                comboBoxCharsMagic15.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic15;
                numericUpDownCharsMagicQ15.Value = InitWorker.GetSelectedCharactersData.Magic15Quantity;
                comboBoxCharsMagic16.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic16;
                numericUpDownCharsMagicQ16.Value = InitWorker.GetSelectedCharactersData.Magic16Quantity;
                comboBoxCharsMagic17.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic17;
                numericUpDownCharsMagicQ17.Value = InitWorker.GetSelectedCharactersData.Magic17Quantity;
                comboBoxCharsMagic18.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic18;
                numericUpDownCharsMagicQ18.Value = InitWorker.GetSelectedCharactersData.Magic18Quantity;
                comboBoxCharsMagic19.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic19;
                numericUpDownCharsMagicQ19.Value = InitWorker.GetSelectedCharactersData.Magic19Quantity;
                comboBoxCharsMagic20.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic20;
                numericUpDownCharsMagicQ20.Value = InitWorker.GetSelectedCharactersData.Magic20Quantity;
                comboBoxCharsMagic21.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic21;
                numericUpDownCharsMagicQ21.Value = InitWorker.GetSelectedCharactersData.Magic21Quantity;
                comboBoxCharsMagic22.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic22;
                numericUpDownCharsMagicQ22.Value = InitWorker.GetSelectedCharactersData.Magic22Quantity;
                comboBoxCharsMagic23.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic23;
                numericUpDownCharsMagicQ23.Value = InitWorker.GetSelectedCharactersData.Magic23Quantity;
                comboBoxCharsMagic24.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic24;
                numericUpDownCharsMagicQ24.Value = InitWorker.GetSelectedCharactersData.Magic24Quantity;
                comboBoxCharsMagic25.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic25;
                numericUpDownCharsMagicQ25.Value = InitWorker.GetSelectedCharactersData.Magic25Quantity;
                comboBoxCharsMagic26.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic26;
                numericUpDownCharsMagicQ26.Value = InitWorker.GetSelectedCharactersData.Magic26Quantity;
                comboBoxCharsMagic27.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic27;
                numericUpDownCharsMagicQ27.Value = InitWorker.GetSelectedCharactersData.Magic27Quantity;
                comboBoxCharsMagic28.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic28;
                numericUpDownCharsMagicQ28.Value = InitWorker.GetSelectedCharactersData.Magic28Quantity;
                comboBoxCharsMagic29.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic29;
                numericUpDownCharsMagicQ29.Value = InitWorker.GetSelectedCharactersData.Magic29Quantity;
                comboBoxCharsMagic30.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic30;
                numericUpDownCharsMagicQ30.Value = InitWorker.GetSelectedCharactersData.Magic30Quantity;
                comboBoxCharsMagic31.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic31;
                numericUpDownCharsMagicQ31.Value = InitWorker.GetSelectedCharactersData.Magic31Quantity;
                comboBoxCharsMagic32.SelectedIndex = InitWorker.GetSelectedCharactersData.Magic32;
                numericUpDownCharsMagicQ32.Value = InitWorker.GetSelectedCharactersData.Magic32Quantity;
                comboBoxCharsComm1.SelectedIndex = InitWorker.GetSelectedCharactersData.Command1;
                comboBoxCharsComm2.SelectedIndex = InitWorker.GetSelectedCharactersData.Command2;
                comboBoxCharsComm3.SelectedIndex = InitWorker.GetSelectedCharactersData.Command3;
                hexUpDownCharUnk1.Value = InitWorker.GetSelectedCharactersData.Unknown1;
                comboBoxCharsAb1.SelectedIndex = InitWorker.GetSelectedCharactersData.Ability1;
                comboBoxCharsAb2.SelectedIndex = InitWorker.GetSelectedCharactersData.Ability2;
                comboBoxCharsAb3.SelectedIndex = InitWorker.GetSelectedCharactersData.Ability3;
                comboBoxCharsAb4.SelectedIndex = InitWorker.GetSelectedCharactersData.Ability4;
                checkBoxCharsGf1.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x01) >= 1 ? true : false;
                checkBoxCharsGf2.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x02) >= 1 ? true : false;
                checkBoxCharsGf3.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x04) >= 1 ? true : false;
                checkBoxCharsGf4.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x08) >= 1 ? true : false;
                checkBoxCharsGf5.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x10) >= 1 ? true : false;
                checkBoxCharsGf6.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x20) >= 1 ? true : false;
                checkBoxCharsGf7.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x40) >= 1 ? true : false;
                checkBoxCharsGf8.Checked = (InitWorker.GetSelectedCharactersData.JunGf1 & 0x80) >= 1 ? true : false;
                checkBoxCharsGf9.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x01) >= 1 ? true : false;
                checkBoxCharsGf10.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x02) >= 1 ? true : false;
                checkBoxCharsGf11.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x04) >= 1 ? true : false;
                checkBoxCharsGf12.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x08) >= 1 ? true : false;
                checkBoxCharsGf13.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x10) >= 1 ? true : false;
                checkBoxCharsGf14.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x20) >= 1 ? true : false;
                checkBoxCharsGf15.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x40) >= 1 ? true : false;
                checkBoxCharsGf16.Checked = (InitWorker.GetSelectedCharactersData.JunGf2 & 0x80) >= 1 ? true : false;
                hexUpDownCharUnk2.Value = InitWorker.GetSelectedCharactersData.Unknown2;
                checkBoxCharsAltMod.Checked = (InitWorker.GetSelectedCharactersData.AltModel & 0x01) >= 1 ? true : false;
                comboBoxCharsJunHp.SelectedIndex = InitWorker.GetSelectedCharactersData.JunHP;
                comboBoxCharsJunStr.SelectedIndex = InitWorker.GetSelectedCharactersData.JunStr;
                comboBoxCharsJunVit.SelectedIndex = InitWorker.GetSelectedCharactersData.JunVit;
                comboBoxCharsJunMag.SelectedIndex = InitWorker.GetSelectedCharactersData.JunMag;
                comboBoxCharsJunSpr.SelectedIndex = InitWorker.GetSelectedCharactersData.JunSpr;
                comboBoxCharsJunSpd.SelectedIndex = InitWorker.GetSelectedCharactersData.JunSpd;
                comboBoxCharsJunEva.SelectedIndex = InitWorker.GetSelectedCharactersData.JunEva;
                comboBoxCharsJunHit.SelectedIndex = InitWorker.GetSelectedCharactersData.JunHit;
                comboBoxCharsJunLuck.SelectedIndex = InitWorker.GetSelectedCharactersData.JunLuck;
                comboBoxCharsElemAtk.SelectedIndex = InitWorker.GetSelectedCharactersData.JunEleAtk;
                comboBoxCharsStatusAtk.SelectedIndex = InitWorker.GetSelectedCharactersData.JunStatusAtk;
                comboBoxCharsElemDef1.SelectedIndex = InitWorker.GetSelectedCharactersData.JunEleDef1;
                comboBoxCharsElemDef2.SelectedIndex = InitWorker.GetSelectedCharactersData.JunEleDef2;
                comboBoxCharsElemDef3.SelectedIndex = InitWorker.GetSelectedCharactersData.JunEleDef3;
                comboBoxCharsElemDef4.SelectedIndex = InitWorker.GetSelectedCharactersData.JunEleDef4;
                comboBoxCharsStatusDef1.SelectedIndex = InitWorker.GetSelectedCharactersData.JunStatusDef1;
                comboBoxCharsStatusDef2.SelectedIndex = InitWorker.GetSelectedCharactersData.JunStatusDef2;
                comboBoxCharsStatusDef3.SelectedIndex = InitWorker.GetSelectedCharactersData.JunStatusDef3;
                comboBoxCharsStatusDef4.SelectedIndex = InitWorker.GetSelectedCharactersData.JunStatusDef4;
                hexUpDownCharUnk3.Value = InitWorker.GetSelectedCharactersData.Unknown3;
                numericUpDownGfComp1.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp1) / 5;
                numericUpDownGfComp2.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp2) / 5;
                numericUpDownGfComp3.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp3) / 5;
                numericUpDownGfComp4.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp4) / 5;
                numericUpDownGfComp5.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp5) / 5;
                numericUpDownGfComp6.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp6) / 5;
                numericUpDownGfComp7.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp7) / 5;
                numericUpDownGfComp8.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp8) / 5;
                numericUpDownGfComp9.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp9) / 5;
                numericUpDownGfComp10.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp10) / 5;
                numericUpDownGfComp11.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp11) / 5;
                numericUpDownGfComp12.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp12) / 5;
                numericUpDownGfComp13.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp13) / 5;
                numericUpDownGfComp14.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp14) / 5;
                numericUpDownGfComp15.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp15) / 5;
                numericUpDownGfComp16.Value = (6000 - InitWorker.GetSelectedCharactersData.GfComp16) / 5;
                numericUpDownCharsKills.Value = InitWorker.GetSelectedCharactersData.Kills;
                numericUpDownCharsKOs.Value = InitWorker.GetSelectedCharactersData.KOs;
                checkBoxCharsAvailable.Checked = (InitWorker.GetSelectedCharactersData.Exist & 0x01) >= 1 ? true : false;
                hexUpDownCharUnk4.Value = InitWorker.GetSelectedCharactersData.Unknown4;
                checkBoxCharStatus1.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x01) >= 1 ? true : false;
                checkBoxCharStatus2.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x02) >= 1 ? true : false;
                checkBoxCharStatus3.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x04) >= 1 ? true : false;
                checkBoxCharStatus4.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x08) >= 1 ? true : false;
                checkBoxCharStatus5.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x10) >= 1 ? true : false;
                checkBoxCharStatus6.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x20) >= 1 ? true : false;
                checkBoxCharStatus7.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x40) >= 1 ? true : false;
                checkBoxCharStatus8.Checked = (InitWorker.GetSelectedCharactersData.CurrentStatus & 0x80) >= 1 ? true : false;
                hexUpDownCharUnk5.Value = InitWorker.GetSelectedCharactersData.Unknown5;
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }
            _loaded = true;
        }


        private void listViewExGfList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _loaded = false;
            if (InitWorker.Init == null || InitWorker.BackupInit == null)
                return;

            int GfList = 0;
            if (listViewExGfList.SelectedItems.Count > 0)
                GfList = listViewExGfList.SelectedIndices[0];

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
                numericUpDownGfAp1.Value = InitWorker.GetSelectedGfData.ApAbility1;
                numericUpDownGfAp2.Value = InitWorker.GetSelectedGfData.ApAbility2;
                numericUpDownGfAp3.Value = InitWorker.GetSelectedGfData.ApAbility3;
                numericUpDownGfAp4.Value = InitWorker.GetSelectedGfData.ApAbility4;
                numericUpDownGfAp5.Value = InitWorker.GetSelectedGfData.ApAbility5;
                numericUpDownGfAp6.Value = InitWorker.GetSelectedGfData.ApAbility6;
                numericUpDownGfAp7.Value = InitWorker.GetSelectedGfData.ApAbility7;
                numericUpDownGfAp8.Value = InitWorker.GetSelectedGfData.ApAbility8;
                numericUpDownGfAp9.Value = InitWorker.GetSelectedGfData.ApAbility9;
                numericUpDownGfAp10.Value = InitWorker.GetSelectedGfData.ApAbility10;
                numericUpDownGfAp11.Value = InitWorker.GetSelectedGfData.ApAbility11;
                numericUpDownGfAp12.Value = InitWorker.GetSelectedGfData.ApAbility12;
                numericUpDownGfAp13.Value = InitWorker.GetSelectedGfData.ApAbility13;
                numericUpDownGfAp14.Value = InitWorker.GetSelectedGfData.ApAbility14;
                numericUpDownGfAp15.Value = InitWorker.GetSelectedGfData.ApAbility15;
                numericUpDownGfAp16.Value = InitWorker.GetSelectedGfData.ApAbility16;
                numericUpDownGfAp17.Value = InitWorker.GetSelectedGfData.ApAbility17;
                numericUpDownGfAp18.Value = InitWorker.GetSelectedGfData.ApAbility18;
                numericUpDownGfAp19.Value = InitWorker.GetSelectedGfData.ApAbility19;
                numericUpDownGfAp20.Value = InitWorker.GetSelectedGfData.ApAbility20;
                numericUpDownGfAp21.Value = InitWorker.GetSelectedGfData.ApAbility21;
                numericUpDownGfAp22.Value = InitWorker.GetSelectedGfData.ApAbility22;
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


        private void InitItems()
        {
            _loaded = false;
            if (InitWorker.Init == null || InitWorker.BackupInit == null)
                return;

            InitWorker.ReadItems(InitWorker.BackupInit);
            try
            {
                ToolTip(comboBoxItem1, 2, comboBoxItem1.Items[InitWorker.GetSelectedItemsData.Item1]);
                ToolTip(comboBoxItem2, 2, comboBoxItem2.Items[InitWorker.GetSelectedItemsData.Item2]);
                ToolTip(comboBoxItem3, 2, comboBoxItem3.Items[InitWorker.GetSelectedItemsData.Item3]);
                ToolTip(comboBoxItem4, 2, comboBoxItem4.Items[InitWorker.GetSelectedItemsData.Item4]);
                ToolTip(comboBoxItem5, 2, comboBoxItem5.Items[InitWorker.GetSelectedItemsData.Item5]);
                ToolTip(comboBoxItem6, 2, comboBoxItem6.Items[InitWorker.GetSelectedItemsData.Item6]);
                ToolTip(comboBoxItem7, 2, comboBoxItem7.Items[InitWorker.GetSelectedItemsData.Item7]);
                ToolTip(comboBoxItem8, 2, comboBoxItem8.Items[InitWorker.GetSelectedItemsData.Item8]);
                ToolTip(comboBoxItem9, 2, comboBoxItem9.Items[InitWorker.GetSelectedItemsData.Item9]);
                ToolTip(comboBoxItem10, 2, comboBoxItem10.Items[InitWorker.GetSelectedItemsData.Item10]);
                ToolTip(comboBoxItem11, 2, comboBoxItem11.Items[InitWorker.GetSelectedItemsData.Item11]);
                ToolTip(comboBoxItem12, 2, comboBoxItem12.Items[InitWorker.GetSelectedItemsData.Item12]);
                ToolTip(comboBoxItem13, 2, comboBoxItem13.Items[InitWorker.GetSelectedItemsData.Item13]);
                ToolTip(comboBoxItem14, 2, comboBoxItem14.Items[InitWorker.GetSelectedItemsData.Item14]);
                ToolTip(comboBoxItem15, 2, comboBoxItem15.Items[InitWorker.GetSelectedItemsData.Item15]);
                ToolTip(comboBoxItem16, 2, comboBoxItem16.Items[InitWorker.GetSelectedItemsData.Item16]);
                ToolTip(comboBoxItem17, 2, comboBoxItem17.Items[InitWorker.GetSelectedItemsData.Item17]);
                ToolTip(comboBoxItem18, 2, comboBoxItem18.Items[InitWorker.GetSelectedItemsData.Item18]);
                ToolTip(comboBoxItem19, 2, comboBoxItem19.Items[InitWorker.GetSelectedItemsData.Item19]);
                ToolTip(comboBoxItem20, 2, comboBoxItem20.Items[InitWorker.GetSelectedItemsData.Item20]);
                ToolTip(comboBoxItem21, 2, comboBoxItem21.Items[InitWorker.GetSelectedItemsData.Item21]);
                ToolTip(comboBoxItem22, 2, comboBoxItem22.Items[InitWorker.GetSelectedItemsData.Item22]);
                ToolTip(comboBoxItem23, 2, comboBoxItem23.Items[InitWorker.GetSelectedItemsData.Item23]);
                ToolTip(comboBoxItem24, 2, comboBoxItem24.Items[InitWorker.GetSelectedItemsData.Item24]);
                ToolTip(comboBoxItem25, 2, comboBoxItem25.Items[InitWorker.GetSelectedItemsData.Item25]);
                ToolTip(comboBoxItem26, 2, comboBoxItem26.Items[InitWorker.GetSelectedItemsData.Item26]);
                ToolTip(comboBoxItem27, 2, comboBoxItem27.Items[InitWorker.GetSelectedItemsData.Item27]);
                ToolTip(comboBoxItem28, 2, comboBoxItem28.Items[InitWorker.GetSelectedItemsData.Item28]);
                ToolTip(comboBoxItem29, 2, comboBoxItem29.Items[InitWorker.GetSelectedItemsData.Item29]);
                ToolTip(comboBoxItem30, 2, comboBoxItem30.Items[InitWorker.GetSelectedItemsData.Item30]);
                ToolTip(comboBoxItem31, 2, comboBoxItem31.Items[InitWorker.GetSelectedItemsData.Item31]);
                ToolTip(comboBoxItem32, 2, comboBoxItem32.Items[InitWorker.GetSelectedItemsData.Item32]);
                ToolTip(comboBoxItem33, 2, comboBoxItem33.Items[InitWorker.GetSelectedItemsData.Item33]);
                ToolTip(comboBoxItem34, 2, comboBoxItem34.Items[InitWorker.GetSelectedItemsData.Item34]);
                ToolTip(comboBoxItem35, 2, comboBoxItem35.Items[InitWorker.GetSelectedItemsData.Item35]);
                ToolTip(comboBoxItem36, 2, comboBoxItem36.Items[InitWorker.GetSelectedItemsData.Item36]);
                ToolTip(comboBoxItem37, 2, comboBoxItem37.Items[InitWorker.GetSelectedItemsData.Item37]);
                ToolTip(comboBoxItem38, 2, comboBoxItem38.Items[InitWorker.GetSelectedItemsData.Item38]);
                ToolTip(comboBoxItem39, 2, comboBoxItem39.Items[InitWorker.GetSelectedItemsData.Item39]);
                ToolTip(comboBoxItem40, 2, comboBoxItem40.Items[InitWorker.GetSelectedItemsData.Item40]);
                ToolTip(comboBoxItem41, 2, comboBoxItem41.Items[InitWorker.GetSelectedItemsData.Item41]);
                ToolTip(comboBoxItem42, 2, comboBoxItem42.Items[InitWorker.GetSelectedItemsData.Item42]);
                ToolTip(comboBoxItem43, 2, comboBoxItem43.Items[InitWorker.GetSelectedItemsData.Item43]);
                ToolTip(comboBoxItem44, 2, comboBoxItem44.Items[InitWorker.GetSelectedItemsData.Item44]);
                ToolTip(comboBoxItem45, 2, comboBoxItem45.Items[InitWorker.GetSelectedItemsData.Item45]);
                ToolTip(comboBoxItem46, 2, comboBoxItem46.Items[InitWorker.GetSelectedItemsData.Item46]);
                ToolTip(comboBoxItem47, 2, comboBoxItem47.Items[InitWorker.GetSelectedItemsData.Item47]);
                ToolTip(comboBoxItem48, 2, comboBoxItem48.Items[InitWorker.GetSelectedItemsData.Item48]);
                ToolTip(comboBoxItem49, 2, comboBoxItem49.Items[InitWorker.GetSelectedItemsData.Item49]);
                ToolTip(comboBoxItem50, 2, comboBoxItem50.Items[InitWorker.GetSelectedItemsData.Item50]);
                ToolTip(comboBoxItem51, 2, comboBoxItem51.Items[InitWorker.GetSelectedItemsData.Item51]);
                ToolTip(comboBoxItem52, 2, comboBoxItem52.Items[InitWorker.GetSelectedItemsData.Item52]);
                ToolTip(comboBoxItem53, 2, comboBoxItem53.Items[InitWorker.GetSelectedItemsData.Item53]);
                ToolTip(comboBoxItem54, 2, comboBoxItem54.Items[InitWorker.GetSelectedItemsData.Item54]);
                ToolTip(comboBoxItem55, 2, comboBoxItem55.Items[InitWorker.GetSelectedItemsData.Item55]);
                ToolTip(comboBoxItem56, 2, comboBoxItem56.Items[InitWorker.GetSelectedItemsData.Item56]);
                ToolTip(comboBoxItem57, 2, comboBoxItem57.Items[InitWorker.GetSelectedItemsData.Item57]);
                ToolTip(comboBoxItem58, 2, comboBoxItem58.Items[InitWorker.GetSelectedItemsData.Item58]);
                ToolTip(comboBoxItem59, 2, comboBoxItem59.Items[InitWorker.GetSelectedItemsData.Item59]);
                ToolTip(comboBoxItem60, 2, comboBoxItem60.Items[InitWorker.GetSelectedItemsData.Item60]);
                ToolTip(comboBoxItem61, 2, comboBoxItem61.Items[InitWorker.GetSelectedItemsData.Item61]);
                ToolTip(comboBoxItem62, 2, comboBoxItem62.Items[InitWorker.GetSelectedItemsData.Item62]);
                ToolTip(comboBoxItem63, 2, comboBoxItem63.Items[InitWorker.GetSelectedItemsData.Item63]);
                ToolTip(comboBoxItem64, 2, comboBoxItem64.Items[InitWorker.GetSelectedItemsData.Item64]);
                ToolTip(comboBoxItem65, 2, comboBoxItem65.Items[InitWorker.GetSelectedItemsData.Item65]);
                ToolTip(comboBoxItem66, 2, comboBoxItem66.Items[InitWorker.GetSelectedItemsData.Item66]);
                ToolTip(comboBoxItem67, 2, comboBoxItem67.Items[InitWorker.GetSelectedItemsData.Item67]);
                ToolTip(comboBoxItem68, 2, comboBoxItem68.Items[InitWorker.GetSelectedItemsData.Item68]);
                ToolTip(comboBoxItem69, 2, comboBoxItem69.Items[InitWorker.GetSelectedItemsData.Item69]);
                ToolTip(comboBoxItem70, 2, comboBoxItem70.Items[InitWorker.GetSelectedItemsData.Item70]);
                ToolTip(comboBoxItem71, 2, comboBoxItem71.Items[InitWorker.GetSelectedItemsData.Item71]);
                ToolTip(comboBoxItem72, 2, comboBoxItem72.Items[InitWorker.GetSelectedItemsData.Item72]);
                ToolTip(comboBoxItem73, 2, comboBoxItem73.Items[InitWorker.GetSelectedItemsData.Item73]);
                ToolTip(comboBoxItem74, 2, comboBoxItem74.Items[InitWorker.GetSelectedItemsData.Item74]);
                ToolTip(comboBoxItem75, 2, comboBoxItem75.Items[InitWorker.GetSelectedItemsData.Item75]);
                ToolTip(comboBoxItem76, 2, comboBoxItem76.Items[InitWorker.GetSelectedItemsData.Item76]);
                ToolTip(comboBoxItem77, 2, comboBoxItem77.Items[InitWorker.GetSelectedItemsData.Item77]);
                ToolTip(comboBoxItem78, 2, comboBoxItem78.Items[InitWorker.GetSelectedItemsData.Item78]);
                ToolTip(comboBoxItem79, 2, comboBoxItem79.Items[InitWorker.GetSelectedItemsData.Item79]);
                ToolTip(comboBoxItem80, 2, comboBoxItem80.Items[InitWorker.GetSelectedItemsData.Item80]);
                ToolTip(comboBoxItem81, 2, comboBoxItem81.Items[InitWorker.GetSelectedItemsData.Item81]);
                ToolTip(comboBoxItem82, 2, comboBoxItem82.Items[InitWorker.GetSelectedItemsData.Item82]);
                ToolTip(comboBoxItem83, 2, comboBoxItem83.Items[InitWorker.GetSelectedItemsData.Item83]);
                ToolTip(comboBoxItem84, 2, comboBoxItem84.Items[InitWorker.GetSelectedItemsData.Item84]);
                ToolTip(comboBoxItem85, 2, comboBoxItem85.Items[InitWorker.GetSelectedItemsData.Item85]);
                ToolTip(comboBoxItem86, 2, comboBoxItem86.Items[InitWorker.GetSelectedItemsData.Item86]);
                ToolTip(comboBoxItem87, 2, comboBoxItem87.Items[InitWorker.GetSelectedItemsData.Item87]);
                ToolTip(comboBoxItem88, 2, comboBoxItem88.Items[InitWorker.GetSelectedItemsData.Item88]);
                ToolTip(comboBoxItem89, 2, comboBoxItem89.Items[InitWorker.GetSelectedItemsData.Item89]);
                ToolTip(comboBoxItem90, 2, comboBoxItem90.Items[InitWorker.GetSelectedItemsData.Item90]);
                ToolTip(comboBoxItem91, 2, comboBoxItem91.Items[InitWorker.GetSelectedItemsData.Item91]);
                ToolTip(comboBoxItem92, 2, comboBoxItem92.Items[InitWorker.GetSelectedItemsData.Item92]);
                ToolTip(comboBoxItem93, 2, comboBoxItem93.Items[InitWorker.GetSelectedItemsData.Item93]);
                ToolTip(comboBoxItem94, 2, comboBoxItem94.Items[InitWorker.GetSelectedItemsData.Item94]);
                ToolTip(comboBoxItem95, 2, comboBoxItem95.Items[InitWorker.GetSelectedItemsData.Item95]);
                ToolTip(comboBoxItem96, 2, comboBoxItem96.Items[InitWorker.GetSelectedItemsData.Item96]);
                ToolTip(comboBoxItem97, 2, comboBoxItem97.Items[InitWorker.GetSelectedItemsData.Item97]);
                ToolTip(comboBoxItem98, 2, comboBoxItem98.Items[InitWorker.GetSelectedItemsData.Item98]);
                ToolTip(comboBoxItem99, 2, comboBoxItem99.Items[InitWorker.GetSelectedItemsData.Item99]);
                ToolTip(comboBoxItem100, 2, comboBoxItem100.Items[InitWorker.GetSelectedItemsData.Item100]);
                ToolTip(comboBoxItem101, 2, comboBoxItem101.Items[InitWorker.GetSelectedItemsData.Item101]);
                ToolTip(comboBoxItem102, 2, comboBoxItem102.Items[InitWorker.GetSelectedItemsData.Item102]);
                ToolTip(comboBoxItem103, 2, comboBoxItem103.Items[InitWorker.GetSelectedItemsData.Item103]);
                ToolTip(comboBoxItem104, 2, comboBoxItem104.Items[InitWorker.GetSelectedItemsData.Item104]);
                ToolTip(comboBoxItem105, 2, comboBoxItem105.Items[InitWorker.GetSelectedItemsData.Item105]);
                ToolTip(comboBoxItem106, 2, comboBoxItem106.Items[InitWorker.GetSelectedItemsData.Item106]);
                ToolTip(comboBoxItem107, 2, comboBoxItem107.Items[InitWorker.GetSelectedItemsData.Item107]);
                ToolTip(comboBoxItem108, 2, comboBoxItem108.Items[InitWorker.GetSelectedItemsData.Item108]);
                ToolTip(comboBoxItem109, 2, comboBoxItem109.Items[InitWorker.GetSelectedItemsData.Item109]);
                ToolTip(comboBoxItem110, 2, comboBoxItem110.Items[InitWorker.GetSelectedItemsData.Item110]);
                ToolTip(comboBoxItem111, 2, comboBoxItem111.Items[InitWorker.GetSelectedItemsData.Item111]);
                ToolTip(comboBoxItem112, 2, comboBoxItem112.Items[InitWorker.GetSelectedItemsData.Item112]);
                ToolTip(comboBoxItem113, 2, comboBoxItem113.Items[InitWorker.GetSelectedItemsData.Item113]);
                ToolTip(comboBoxItem114, 2, comboBoxItem114.Items[InitWorker.GetSelectedItemsData.Item114]);
                ToolTip(comboBoxItem115, 2, comboBoxItem115.Items[InitWorker.GetSelectedItemsData.Item115]);
                ToolTip(comboBoxItem116, 2, comboBoxItem116.Items[InitWorker.GetSelectedItemsData.Item116]);
                ToolTip(comboBoxItem117, 2, comboBoxItem117.Items[InitWorker.GetSelectedItemsData.Item117]);
                ToolTip(comboBoxItem118, 2, comboBoxItem118.Items[InitWorker.GetSelectedItemsData.Item118]);
                ToolTip(comboBoxItem119, 2, comboBoxItem119.Items[InitWorker.GetSelectedItemsData.Item119]);
                ToolTip(comboBoxItem120, 2, comboBoxItem120.Items[InitWorker.GetSelectedItemsData.Item120]);
                ToolTip(comboBoxItem121, 2, comboBoxItem121.Items[InitWorker.GetSelectedItemsData.Item121]);
                ToolTip(comboBoxItem122, 2, comboBoxItem122.Items[InitWorker.GetSelectedItemsData.Item122]);
                ToolTip(comboBoxItem123, 2, comboBoxItem123.Items[InitWorker.GetSelectedItemsData.Item123]);
                ToolTip(comboBoxItem124, 2, comboBoxItem124.Items[InitWorker.GetSelectedItemsData.Item124]);
                ToolTip(comboBoxItem125, 2, comboBoxItem125.Items[InitWorker.GetSelectedItemsData.Item125]);
                ToolTip(comboBoxItem126, 2, comboBoxItem126.Items[InitWorker.GetSelectedItemsData.Item126]);
                ToolTip(comboBoxItem127, 2, comboBoxItem127.Items[InitWorker.GetSelectedItemsData.Item127]);
                ToolTip(comboBoxItem128, 2, comboBoxItem128.Items[InitWorker.GetSelectedItemsData.Item128]);
                ToolTip(comboBoxItem129, 2, comboBoxItem129.Items[InitWorker.GetSelectedItemsData.Item129]);
                ToolTip(comboBoxItem130, 2, comboBoxItem130.Items[InitWorker.GetSelectedItemsData.Item130]);
                ToolTip(comboBoxItem131, 2, comboBoxItem131.Items[InitWorker.GetSelectedItemsData.Item131]);
                ToolTip(comboBoxItem132, 2, comboBoxItem132.Items[InitWorker.GetSelectedItemsData.Item132]);
                ToolTip(comboBoxItem133, 2, comboBoxItem133.Items[InitWorker.GetSelectedItemsData.Item133]);
                ToolTip(comboBoxItem134, 2, comboBoxItem134.Items[InitWorker.GetSelectedItemsData.Item134]);
                ToolTip(comboBoxItem135, 2, comboBoxItem135.Items[InitWorker.GetSelectedItemsData.Item135]);
                ToolTip(comboBoxItem136, 2, comboBoxItem136.Items[InitWorker.GetSelectedItemsData.Item136]);
                ToolTip(comboBoxItem137, 2, comboBoxItem137.Items[InitWorker.GetSelectedItemsData.Item137]);
                ToolTip(comboBoxItem138, 2, comboBoxItem138.Items[InitWorker.GetSelectedItemsData.Item138]);
                ToolTip(comboBoxItem139, 2, comboBoxItem139.Items[InitWorker.GetSelectedItemsData.Item139]);
                ToolTip(comboBoxItem140, 2, comboBoxItem140.Items[InitWorker.GetSelectedItemsData.Item140]);
                ToolTip(comboBoxItem141, 2, comboBoxItem141.Items[InitWorker.GetSelectedItemsData.Item141]);
                ToolTip(comboBoxItem142, 2, comboBoxItem142.Items[InitWorker.GetSelectedItemsData.Item142]);
                ToolTip(comboBoxItem143, 2, comboBoxItem143.Items[InitWorker.GetSelectedItemsData.Item143]);
                ToolTip(comboBoxItem144, 2, comboBoxItem144.Items[InitWorker.GetSelectedItemsData.Item144]);
                ToolTip(comboBoxItem145, 2, comboBoxItem145.Items[InitWorker.GetSelectedItemsData.Item145]);
                ToolTip(comboBoxItem146, 2, comboBoxItem146.Items[InitWorker.GetSelectedItemsData.Item146]);
                ToolTip(comboBoxItem147, 2, comboBoxItem147.Items[InitWorker.GetSelectedItemsData.Item147]);
                ToolTip(comboBoxItem148, 2, comboBoxItem148.Items[InitWorker.GetSelectedItemsData.Item148]);
                ToolTip(comboBoxItem149, 2, comboBoxItem149.Items[InitWorker.GetSelectedItemsData.Item149]);
                ToolTip(comboBoxItem150, 2, comboBoxItem150.Items[InitWorker.GetSelectedItemsData.Item150]);
                ToolTip(comboBoxItem151, 2, comboBoxItem151.Items[InitWorker.GetSelectedItemsData.Item151]);
                ToolTip(comboBoxItem152, 2, comboBoxItem152.Items[InitWorker.GetSelectedItemsData.Item152]);
                ToolTip(comboBoxItem153, 2, comboBoxItem153.Items[InitWorker.GetSelectedItemsData.Item153]);
                ToolTip(comboBoxItem154, 2, comboBoxItem154.Items[InitWorker.GetSelectedItemsData.Item154]);
                ToolTip(comboBoxItem155, 2, comboBoxItem155.Items[InitWorker.GetSelectedItemsData.Item155]);
                ToolTip(comboBoxItem156, 2, comboBoxItem156.Items[InitWorker.GetSelectedItemsData.Item156]);
                ToolTip(comboBoxItem157, 2, comboBoxItem157.Items[InitWorker.GetSelectedItemsData.Item157]);
                ToolTip(comboBoxItem158, 2, comboBoxItem158.Items[InitWorker.GetSelectedItemsData.Item158]);
                ToolTip(comboBoxItem159, 2, comboBoxItem159.Items[InitWorker.GetSelectedItemsData.Item159]);
                ToolTip(comboBoxItem160, 2, comboBoxItem160.Items[InitWorker.GetSelectedItemsData.Item160]);
                ToolTip(comboBoxItem161, 2, comboBoxItem161.Items[InitWorker.GetSelectedItemsData.Item161]);
                ToolTip(comboBoxItem162, 2, comboBoxItem162.Items[InitWorker.GetSelectedItemsData.Item162]);
                ToolTip(comboBoxItem163, 2, comboBoxItem163.Items[InitWorker.GetSelectedItemsData.Item163]);
                ToolTip(comboBoxItem164, 2, comboBoxItem164.Items[InitWorker.GetSelectedItemsData.Item164]);
                ToolTip(comboBoxItem165, 2, comboBoxItem165.Items[InitWorker.GetSelectedItemsData.Item165]);
                ToolTip(comboBoxItem166, 2, comboBoxItem166.Items[InitWorker.GetSelectedItemsData.Item166]);
                ToolTip(comboBoxItem167, 2, comboBoxItem167.Items[InitWorker.GetSelectedItemsData.Item167]);
                ToolTip(comboBoxItem168, 2, comboBoxItem168.Items[InitWorker.GetSelectedItemsData.Item168]);
                ToolTip(comboBoxItem169, 2, comboBoxItem169.Items[InitWorker.GetSelectedItemsData.Item169]);
                ToolTip(comboBoxItem170, 2, comboBoxItem170.Items[InitWorker.GetSelectedItemsData.Item170]);
                ToolTip(comboBoxItem171, 2, comboBoxItem171.Items[InitWorker.GetSelectedItemsData.Item171]);
                ToolTip(comboBoxItem172, 2, comboBoxItem172.Items[InitWorker.GetSelectedItemsData.Item172]);
                ToolTip(comboBoxItem173, 2, comboBoxItem173.Items[InitWorker.GetSelectedItemsData.Item173]);
                ToolTip(comboBoxItem174, 2, comboBoxItem174.Items[InitWorker.GetSelectedItemsData.Item174]);
                ToolTip(comboBoxItem175, 2, comboBoxItem175.Items[InitWorker.GetSelectedItemsData.Item175]);
                ToolTip(comboBoxItem176, 2, comboBoxItem176.Items[InitWorker.GetSelectedItemsData.Item176]);
                ToolTip(comboBoxItem177, 2, comboBoxItem177.Items[InitWorker.GetSelectedItemsData.Item177]);
                ToolTip(comboBoxItem178, 2, comboBoxItem178.Items[InitWorker.GetSelectedItemsData.Item178]);
                ToolTip(comboBoxItem179, 2, comboBoxItem179.Items[InitWorker.GetSelectedItemsData.Item179]);
                ToolTip(comboBoxItem180, 2, comboBoxItem180.Items[InitWorker.GetSelectedItemsData.Item180]);
                ToolTip(comboBoxItem181, 2, comboBoxItem181.Items[InitWorker.GetSelectedItemsData.Item181]);
                ToolTip(comboBoxItem182, 2, comboBoxItem182.Items[InitWorker.GetSelectedItemsData.Item182]);
                ToolTip(comboBoxItem183, 2, comboBoxItem183.Items[InitWorker.GetSelectedItemsData.Item183]);
                ToolTip(comboBoxItem184, 2, comboBoxItem184.Items[InitWorker.GetSelectedItemsData.Item184]);
                ToolTip(comboBoxItem185, 2, comboBoxItem185.Items[InitWorker.GetSelectedItemsData.Item185]);
                ToolTip(comboBoxItem186, 2, comboBoxItem186.Items[InitWorker.GetSelectedItemsData.Item186]);
                ToolTip(comboBoxItem187, 2, comboBoxItem187.Items[InitWorker.GetSelectedItemsData.Item187]);
                ToolTip(comboBoxItem188, 2, comboBoxItem188.Items[InitWorker.GetSelectedItemsData.Item188]);
                ToolTip(comboBoxItem189, 2, comboBoxItem189.Items[InitWorker.GetSelectedItemsData.Item189]);
                ToolTip(comboBoxItem190, 2, comboBoxItem190.Items[InitWorker.GetSelectedItemsData.Item190]);
                ToolTip(comboBoxItem191, 2, comboBoxItem191.Items[InitWorker.GetSelectedItemsData.Item191]);
                ToolTip(comboBoxItem192, 2, comboBoxItem192.Items[InitWorker.GetSelectedItemsData.Item192]);
                ToolTip(comboBoxItem193, 2, comboBoxItem193.Items[InitWorker.GetSelectedItemsData.Item193]);
                ToolTip(comboBoxItem194, 2, comboBoxItem194.Items[InitWorker.GetSelectedItemsData.Item194]);
                ToolTip(comboBoxItem195, 2, comboBoxItem195.Items[InitWorker.GetSelectedItemsData.Item195]);
                ToolTip(comboBoxItem196, 2, comboBoxItem196.Items[InitWorker.GetSelectedItemsData.Item196]);
                ToolTip(comboBoxItem197, 2, comboBoxItem197.Items[InitWorker.GetSelectedItemsData.Item197]);
                ToolTip(comboBoxItem198, 2, comboBoxItem198.Items[InitWorker.GetSelectedItemsData.Item198]);
                ToolTip(numericUpDownItemQ1, 0, InitWorker.GetSelectedItemsData.Item1Quantity);
                ToolTip(numericUpDownItemQ2, 0, InitWorker.GetSelectedItemsData.Item2Quantity);
                ToolTip(numericUpDownItemQ3, 0, InitWorker.GetSelectedItemsData.Item3Quantity);
                ToolTip(numericUpDownItemQ4, 0, InitWorker.GetSelectedItemsData.Item4Quantity);
                ToolTip(numericUpDownItemQ5, 0, InitWorker.GetSelectedItemsData.Item5Quantity);
                ToolTip(numericUpDownItemQ6, 0, InitWorker.GetSelectedItemsData.Item6Quantity);
                ToolTip(numericUpDownItemQ7, 0, InitWorker.GetSelectedItemsData.Item7Quantity);
                ToolTip(numericUpDownItemQ8, 0, InitWorker.GetSelectedItemsData.Item8Quantity);
                ToolTip(numericUpDownItemQ9, 0, InitWorker.GetSelectedItemsData.Item9Quantity);
                ToolTip(numericUpDownItemQ10, 0, InitWorker.GetSelectedItemsData.Item10Quantity);
                ToolTip(numericUpDownItemQ11, 0, InitWorker.GetSelectedItemsData.Item11Quantity);
                ToolTip(numericUpDownItemQ12, 0, InitWorker.GetSelectedItemsData.Item12Quantity);
                ToolTip(numericUpDownItemQ13, 0, InitWorker.GetSelectedItemsData.Item13Quantity);
                ToolTip(numericUpDownItemQ14, 0, InitWorker.GetSelectedItemsData.Item14Quantity);
                ToolTip(numericUpDownItemQ15, 0, InitWorker.GetSelectedItemsData.Item15Quantity);
                ToolTip(numericUpDownItemQ16, 0, InitWorker.GetSelectedItemsData.Item16Quantity);
                ToolTip(numericUpDownItemQ17, 0, InitWorker.GetSelectedItemsData.Item17Quantity);
                ToolTip(numericUpDownItemQ18, 0, InitWorker.GetSelectedItemsData.Item18Quantity);
                ToolTip(numericUpDownItemQ19, 0, InitWorker.GetSelectedItemsData.Item19Quantity);
                ToolTip(numericUpDownItemQ20, 0, InitWorker.GetSelectedItemsData.Item20Quantity);
                ToolTip(numericUpDownItemQ21, 0, InitWorker.GetSelectedItemsData.Item21Quantity);
                ToolTip(numericUpDownItemQ22, 0, InitWorker.GetSelectedItemsData.Item22Quantity);
                ToolTip(numericUpDownItemQ23, 0, InitWorker.GetSelectedItemsData.Item23Quantity);
                ToolTip(numericUpDownItemQ24, 0, InitWorker.GetSelectedItemsData.Item24Quantity);
                ToolTip(numericUpDownItemQ25, 0, InitWorker.GetSelectedItemsData.Item25Quantity);
                ToolTip(numericUpDownItemQ26, 0, InitWorker.GetSelectedItemsData.Item26Quantity);
                ToolTip(numericUpDownItemQ27, 0, InitWorker.GetSelectedItemsData.Item27Quantity);
                ToolTip(numericUpDownItemQ28, 0, InitWorker.GetSelectedItemsData.Item28Quantity);
                ToolTip(numericUpDownItemQ29, 0, InitWorker.GetSelectedItemsData.Item29Quantity);
                ToolTip(numericUpDownItemQ30, 0, InitWorker.GetSelectedItemsData.Item30Quantity);
                ToolTip(numericUpDownItemQ31, 0, InitWorker.GetSelectedItemsData.Item31Quantity);
                ToolTip(numericUpDownItemQ32, 0, InitWorker.GetSelectedItemsData.Item32Quantity);
                ToolTip(numericUpDownItemQ33, 0, InitWorker.GetSelectedItemsData.Item33Quantity);
                ToolTip(numericUpDownItemQ34, 0, InitWorker.GetSelectedItemsData.Item34Quantity);
                ToolTip(numericUpDownItemQ35, 0, InitWorker.GetSelectedItemsData.Item35Quantity);
                ToolTip(numericUpDownItemQ36, 0, InitWorker.GetSelectedItemsData.Item36Quantity);
                ToolTip(numericUpDownItemQ37, 0, InitWorker.GetSelectedItemsData.Item37Quantity);
                ToolTip(numericUpDownItemQ38, 0, InitWorker.GetSelectedItemsData.Item38Quantity);
                ToolTip(numericUpDownItemQ39, 0, InitWorker.GetSelectedItemsData.Item39Quantity);
                ToolTip(numericUpDownItemQ40, 0, InitWorker.GetSelectedItemsData.Item40Quantity);
                ToolTip(numericUpDownItemQ41, 0, InitWorker.GetSelectedItemsData.Item41Quantity);
                ToolTip(numericUpDownItemQ42, 0, InitWorker.GetSelectedItemsData.Item42Quantity);
                ToolTip(numericUpDownItemQ43, 0, InitWorker.GetSelectedItemsData.Item43Quantity);
                ToolTip(numericUpDownItemQ44, 0, InitWorker.GetSelectedItemsData.Item44Quantity);
                ToolTip(numericUpDownItemQ45, 0, InitWorker.GetSelectedItemsData.Item45Quantity);
                ToolTip(numericUpDownItemQ46, 0, InitWorker.GetSelectedItemsData.Item46Quantity);
                ToolTip(numericUpDownItemQ47, 0, InitWorker.GetSelectedItemsData.Item47Quantity);
                ToolTip(numericUpDownItemQ48, 0, InitWorker.GetSelectedItemsData.Item48Quantity);
                ToolTip(numericUpDownItemQ49, 0, InitWorker.GetSelectedItemsData.Item49Quantity);
                ToolTip(numericUpDownItemQ50, 0, InitWorker.GetSelectedItemsData.Item50Quantity);
                ToolTip(numericUpDownItemQ51, 0, InitWorker.GetSelectedItemsData.Item51Quantity);
                ToolTip(numericUpDownItemQ52, 0, InitWorker.GetSelectedItemsData.Item52Quantity);
                ToolTip(numericUpDownItemQ53, 0, InitWorker.GetSelectedItemsData.Item53Quantity);
                ToolTip(numericUpDownItemQ54, 0, InitWorker.GetSelectedItemsData.Item54Quantity);
                ToolTip(numericUpDownItemQ55, 0, InitWorker.GetSelectedItemsData.Item55Quantity);
                ToolTip(numericUpDownItemQ56, 0, InitWorker.GetSelectedItemsData.Item56Quantity);
                ToolTip(numericUpDownItemQ57, 0, InitWorker.GetSelectedItemsData.Item57Quantity);
                ToolTip(numericUpDownItemQ58, 0, InitWorker.GetSelectedItemsData.Item58Quantity);
                ToolTip(numericUpDownItemQ59, 0, InitWorker.GetSelectedItemsData.Item59Quantity);
                ToolTip(numericUpDownItemQ60, 0, InitWorker.GetSelectedItemsData.Item60Quantity);
                ToolTip(numericUpDownItemQ61, 0, InitWorker.GetSelectedItemsData.Item61Quantity);
                ToolTip(numericUpDownItemQ62, 0, InitWorker.GetSelectedItemsData.Item62Quantity);
                ToolTip(numericUpDownItemQ63, 0, InitWorker.GetSelectedItemsData.Item63Quantity);
                ToolTip(numericUpDownItemQ64, 0, InitWorker.GetSelectedItemsData.Item64Quantity);
                ToolTip(numericUpDownItemQ65, 0, InitWorker.GetSelectedItemsData.Item65Quantity);
                ToolTip(numericUpDownItemQ66, 0, InitWorker.GetSelectedItemsData.Item66Quantity);
                ToolTip(numericUpDownItemQ67, 0, InitWorker.GetSelectedItemsData.Item67Quantity);
                ToolTip(numericUpDownItemQ68, 0, InitWorker.GetSelectedItemsData.Item68Quantity);
                ToolTip(numericUpDownItemQ69, 0, InitWorker.GetSelectedItemsData.Item69Quantity);
                ToolTip(numericUpDownItemQ70, 0, InitWorker.GetSelectedItemsData.Item70Quantity);
                ToolTip(numericUpDownItemQ71, 0, InitWorker.GetSelectedItemsData.Item71Quantity);
                ToolTip(numericUpDownItemQ72, 0, InitWorker.GetSelectedItemsData.Item72Quantity);
                ToolTip(numericUpDownItemQ73, 0, InitWorker.GetSelectedItemsData.Item73Quantity);
                ToolTip(numericUpDownItemQ74, 0, InitWorker.GetSelectedItemsData.Item74Quantity);
                ToolTip(numericUpDownItemQ75, 0, InitWorker.GetSelectedItemsData.Item75Quantity);
                ToolTip(numericUpDownItemQ76, 0, InitWorker.GetSelectedItemsData.Item76Quantity);
                ToolTip(numericUpDownItemQ77, 0, InitWorker.GetSelectedItemsData.Item77Quantity);
                ToolTip(numericUpDownItemQ78, 0, InitWorker.GetSelectedItemsData.Item78Quantity);
                ToolTip(numericUpDownItemQ79, 0, InitWorker.GetSelectedItemsData.Item79Quantity);
                ToolTip(numericUpDownItemQ80, 0, InitWorker.GetSelectedItemsData.Item80Quantity);
                ToolTip(numericUpDownItemQ81, 0, InitWorker.GetSelectedItemsData.Item81Quantity);
                ToolTip(numericUpDownItemQ82, 0, InitWorker.GetSelectedItemsData.Item82Quantity);
                ToolTip(numericUpDownItemQ83, 0, InitWorker.GetSelectedItemsData.Item83Quantity);
                ToolTip(numericUpDownItemQ84, 0, InitWorker.GetSelectedItemsData.Item84Quantity);
                ToolTip(numericUpDownItemQ85, 0, InitWorker.GetSelectedItemsData.Item85Quantity);
                ToolTip(numericUpDownItemQ86, 0, InitWorker.GetSelectedItemsData.Item86Quantity);
                ToolTip(numericUpDownItemQ87, 0, InitWorker.GetSelectedItemsData.Item87Quantity);
                ToolTip(numericUpDownItemQ88, 0, InitWorker.GetSelectedItemsData.Item88Quantity);
                ToolTip(numericUpDownItemQ89, 0, InitWorker.GetSelectedItemsData.Item89Quantity);
                ToolTip(numericUpDownItemQ90, 0, InitWorker.GetSelectedItemsData.Item90Quantity);
                ToolTip(numericUpDownItemQ91, 0, InitWorker.GetSelectedItemsData.Item91Quantity);
                ToolTip(numericUpDownItemQ92, 0, InitWorker.GetSelectedItemsData.Item92Quantity);
                ToolTip(numericUpDownItemQ93, 0, InitWorker.GetSelectedItemsData.Item93Quantity);
                ToolTip(numericUpDownItemQ94, 0, InitWorker.GetSelectedItemsData.Item94Quantity);
                ToolTip(numericUpDownItemQ95, 0, InitWorker.GetSelectedItemsData.Item95Quantity);
                ToolTip(numericUpDownItemQ96, 0, InitWorker.GetSelectedItemsData.Item96Quantity);
                ToolTip(numericUpDownItemQ97, 0, InitWorker.GetSelectedItemsData.Item97Quantity);
                ToolTip(numericUpDownItemQ98, 0, InitWorker.GetSelectedItemsData.Item98Quantity);
                ToolTip(numericUpDownItemQ99, 0, InitWorker.GetSelectedItemsData.Item99Quantity);
                ToolTip(numericUpDownItemQ100, 0, InitWorker.GetSelectedItemsData.Item100Quantity);
                ToolTip(numericUpDownItemQ101, 0, InitWorker.GetSelectedItemsData.Item101Quantity);
                ToolTip(numericUpDownItemQ102, 0, InitWorker.GetSelectedItemsData.Item102Quantity);
                ToolTip(numericUpDownItemQ103, 0, InitWorker.GetSelectedItemsData.Item103Quantity);
                ToolTip(numericUpDownItemQ104, 0, InitWorker.GetSelectedItemsData.Item104Quantity);
                ToolTip(numericUpDownItemQ105, 0, InitWorker.GetSelectedItemsData.Item105Quantity);
                ToolTip(numericUpDownItemQ106, 0, InitWorker.GetSelectedItemsData.Item106Quantity);
                ToolTip(numericUpDownItemQ107, 0, InitWorker.GetSelectedItemsData.Item107Quantity);
                ToolTip(numericUpDownItemQ108, 0, InitWorker.GetSelectedItemsData.Item108Quantity);
                ToolTip(numericUpDownItemQ109, 0, InitWorker.GetSelectedItemsData.Item109Quantity);
                ToolTip(numericUpDownItemQ110, 0, InitWorker.GetSelectedItemsData.Item110Quantity);
                ToolTip(numericUpDownItemQ111, 0, InitWorker.GetSelectedItemsData.Item111Quantity);
                ToolTip(numericUpDownItemQ112, 0, InitWorker.GetSelectedItemsData.Item112Quantity);
                ToolTip(numericUpDownItemQ113, 0, InitWorker.GetSelectedItemsData.Item113Quantity);
                ToolTip(numericUpDownItemQ114, 0, InitWorker.GetSelectedItemsData.Item114Quantity);
                ToolTip(numericUpDownItemQ115, 0, InitWorker.GetSelectedItemsData.Item115Quantity);
                ToolTip(numericUpDownItemQ116, 0, InitWorker.GetSelectedItemsData.Item116Quantity);
                ToolTip(numericUpDownItemQ117, 0, InitWorker.GetSelectedItemsData.Item117Quantity);
                ToolTip(numericUpDownItemQ118, 0, InitWorker.GetSelectedItemsData.Item118Quantity);
                ToolTip(numericUpDownItemQ119, 0, InitWorker.GetSelectedItemsData.Item119Quantity);
                ToolTip(numericUpDownItemQ120, 0, InitWorker.GetSelectedItemsData.Item120Quantity);
                ToolTip(numericUpDownItemQ121, 0, InitWorker.GetSelectedItemsData.Item121Quantity);
                ToolTip(numericUpDownItemQ122, 0, InitWorker.GetSelectedItemsData.Item122Quantity);
                ToolTip(numericUpDownItemQ123, 0, InitWorker.GetSelectedItemsData.Item123Quantity);
                ToolTip(numericUpDownItemQ124, 0, InitWorker.GetSelectedItemsData.Item124Quantity);
                ToolTip(numericUpDownItemQ125, 0, InitWorker.GetSelectedItemsData.Item125Quantity);
                ToolTip(numericUpDownItemQ126, 0, InitWorker.GetSelectedItemsData.Item126Quantity);
                ToolTip(numericUpDownItemQ127, 0, InitWorker.GetSelectedItemsData.Item127Quantity);
                ToolTip(numericUpDownItemQ128, 0, InitWorker.GetSelectedItemsData.Item128Quantity);
                ToolTip(numericUpDownItemQ129, 0, InitWorker.GetSelectedItemsData.Item129Quantity);
                ToolTip(numericUpDownItemQ130, 0, InitWorker.GetSelectedItemsData.Item130Quantity);
                ToolTip(numericUpDownItemQ131, 0, InitWorker.GetSelectedItemsData.Item131Quantity);
                ToolTip(numericUpDownItemQ132, 0, InitWorker.GetSelectedItemsData.Item132Quantity);
                ToolTip(numericUpDownItemQ133, 0, InitWorker.GetSelectedItemsData.Item133Quantity);
                ToolTip(numericUpDownItemQ134, 0, InitWorker.GetSelectedItemsData.Item134Quantity);
                ToolTip(numericUpDownItemQ135, 0, InitWorker.GetSelectedItemsData.Item135Quantity);
                ToolTip(numericUpDownItemQ136, 0, InitWorker.GetSelectedItemsData.Item136Quantity);
                ToolTip(numericUpDownItemQ137, 0, InitWorker.GetSelectedItemsData.Item137Quantity);
                ToolTip(numericUpDownItemQ138, 0, InitWorker.GetSelectedItemsData.Item138Quantity);
                ToolTip(numericUpDownItemQ139, 0, InitWorker.GetSelectedItemsData.Item139Quantity);
                ToolTip(numericUpDownItemQ140, 0, InitWorker.GetSelectedItemsData.Item140Quantity);
                ToolTip(numericUpDownItemQ141, 0, InitWorker.GetSelectedItemsData.Item141Quantity);
                ToolTip(numericUpDownItemQ142, 0, InitWorker.GetSelectedItemsData.Item142Quantity);
                ToolTip(numericUpDownItemQ143, 0, InitWorker.GetSelectedItemsData.Item143Quantity);
                ToolTip(numericUpDownItemQ144, 0, InitWorker.GetSelectedItemsData.Item144Quantity);
                ToolTip(numericUpDownItemQ145, 0, InitWorker.GetSelectedItemsData.Item145Quantity);
                ToolTip(numericUpDownItemQ146, 0, InitWorker.GetSelectedItemsData.Item146Quantity);
                ToolTip(numericUpDownItemQ147, 0, InitWorker.GetSelectedItemsData.Item147Quantity);
                ToolTip(numericUpDownItemQ148, 0, InitWorker.GetSelectedItemsData.Item148Quantity);
                ToolTip(numericUpDownItemQ149, 0, InitWorker.GetSelectedItemsData.Item149Quantity);
                ToolTip(numericUpDownItemQ150, 0, InitWorker.GetSelectedItemsData.Item150Quantity);
                ToolTip(numericUpDownItemQ151, 0, InitWorker.GetSelectedItemsData.Item151Quantity);
                ToolTip(numericUpDownItemQ152, 0, InitWorker.GetSelectedItemsData.Item152Quantity);
                ToolTip(numericUpDownItemQ153, 0, InitWorker.GetSelectedItemsData.Item153Quantity);
                ToolTip(numericUpDownItemQ154, 0, InitWorker.GetSelectedItemsData.Item154Quantity);
                ToolTip(numericUpDownItemQ155, 0, InitWorker.GetSelectedItemsData.Item155Quantity);
                ToolTip(numericUpDownItemQ156, 0, InitWorker.GetSelectedItemsData.Item156Quantity);
                ToolTip(numericUpDownItemQ157, 0, InitWorker.GetSelectedItemsData.Item157Quantity);
                ToolTip(numericUpDownItemQ158, 0, InitWorker.GetSelectedItemsData.Item158Quantity);
                ToolTip(numericUpDownItemQ159, 0, InitWorker.GetSelectedItemsData.Item159Quantity);
                ToolTip(numericUpDownItemQ160, 0, InitWorker.GetSelectedItemsData.Item160Quantity);
                ToolTip(numericUpDownItemQ161, 0, InitWorker.GetSelectedItemsData.Item161Quantity);
                ToolTip(numericUpDownItemQ162, 0, InitWorker.GetSelectedItemsData.Item162Quantity);
                ToolTip(numericUpDownItemQ163, 0, InitWorker.GetSelectedItemsData.Item163Quantity);
                ToolTip(numericUpDownItemQ164, 0, InitWorker.GetSelectedItemsData.Item164Quantity);
                ToolTip(numericUpDownItemQ165, 0, InitWorker.GetSelectedItemsData.Item165Quantity);
                ToolTip(numericUpDownItemQ166, 0, InitWorker.GetSelectedItemsData.Item166Quantity);
                ToolTip(numericUpDownItemQ167, 0, InitWorker.GetSelectedItemsData.Item167Quantity);
                ToolTip(numericUpDownItemQ168, 0, InitWorker.GetSelectedItemsData.Item168Quantity);
                ToolTip(numericUpDownItemQ169, 0, InitWorker.GetSelectedItemsData.Item169Quantity);
                ToolTip(numericUpDownItemQ170, 0, InitWorker.GetSelectedItemsData.Item170Quantity);
                ToolTip(numericUpDownItemQ171, 0, InitWorker.GetSelectedItemsData.Item171Quantity);
                ToolTip(numericUpDownItemQ172, 0, InitWorker.GetSelectedItemsData.Item172Quantity);
                ToolTip(numericUpDownItemQ173, 0, InitWorker.GetSelectedItemsData.Item173Quantity);
                ToolTip(numericUpDownItemQ174, 0, InitWorker.GetSelectedItemsData.Item174Quantity);
                ToolTip(numericUpDownItemQ175, 0, InitWorker.GetSelectedItemsData.Item175Quantity);
                ToolTip(numericUpDownItemQ176, 0, InitWorker.GetSelectedItemsData.Item176Quantity);
                ToolTip(numericUpDownItemQ177, 0, InitWorker.GetSelectedItemsData.Item177Quantity);
                ToolTip(numericUpDownItemQ178, 0, InitWorker.GetSelectedItemsData.Item178Quantity);
                ToolTip(numericUpDownItemQ179, 0, InitWorker.GetSelectedItemsData.Item179Quantity);
                ToolTip(numericUpDownItemQ180, 0, InitWorker.GetSelectedItemsData.Item180Quantity);
                ToolTip(numericUpDownItemQ181, 0, InitWorker.GetSelectedItemsData.Item181Quantity);
                ToolTip(numericUpDownItemQ182, 0, InitWorker.GetSelectedItemsData.Item182Quantity);
                ToolTip(numericUpDownItemQ183, 0, InitWorker.GetSelectedItemsData.Item183Quantity);
                ToolTip(numericUpDownItemQ184, 0, InitWorker.GetSelectedItemsData.Item184Quantity);
                ToolTip(numericUpDownItemQ185, 0, InitWorker.GetSelectedItemsData.Item185Quantity);
                ToolTip(numericUpDownItemQ186, 0, InitWorker.GetSelectedItemsData.Item186Quantity);
                ToolTip(numericUpDownItemQ187, 0, InitWorker.GetSelectedItemsData.Item187Quantity);
                ToolTip(numericUpDownItemQ188, 0, InitWorker.GetSelectedItemsData.Item188Quantity);
                ToolTip(numericUpDownItemQ189, 0, InitWorker.GetSelectedItemsData.Item189Quantity);
                ToolTip(numericUpDownItemQ190, 0, InitWorker.GetSelectedItemsData.Item190Quantity);
                ToolTip(numericUpDownItemQ191, 0, InitWorker.GetSelectedItemsData.Item191Quantity);
                ToolTip(numericUpDownItemQ192, 0, InitWorker.GetSelectedItemsData.Item192Quantity);
                ToolTip(numericUpDownItemQ193, 0, InitWorker.GetSelectedItemsData.Item193Quantity);
                ToolTip(numericUpDownItemQ194, 0, InitWorker.GetSelectedItemsData.Item194Quantity);
                ToolTip(numericUpDownItemQ195, 0, InitWorker.GetSelectedItemsData.Item195Quantity);
                ToolTip(numericUpDownItemQ196, 0, InitWorker.GetSelectedItemsData.Item196Quantity);
                ToolTip(numericUpDownItemQ197, 0, InitWorker.GetSelectedItemsData.Item197Quantity);
                ToolTip(numericUpDownItemQ198, 0, InitWorker.GetSelectedItemsData.Item198Quantity);
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }

            InitWorker.ReadItems(InitWorker.Init);
            try
            {
                comboBoxItem1.SelectedIndex = InitWorker.GetSelectedItemsData.Item1;
                comboBoxItem2.SelectedIndex = InitWorker.GetSelectedItemsData.Item2;
                comboBoxItem3.SelectedIndex = InitWorker.GetSelectedItemsData.Item3;
                comboBoxItem4.SelectedIndex = InitWorker.GetSelectedItemsData.Item4;
                comboBoxItem5.SelectedIndex = InitWorker.GetSelectedItemsData.Item5;
                comboBoxItem6.SelectedIndex = InitWorker.GetSelectedItemsData.Item6;
                comboBoxItem7.SelectedIndex = InitWorker.GetSelectedItemsData.Item7;
                comboBoxItem8.SelectedIndex = InitWorker.GetSelectedItemsData.Item8;
                comboBoxItem9.SelectedIndex = InitWorker.GetSelectedItemsData.Item9;
                comboBoxItem10.SelectedIndex = InitWorker.GetSelectedItemsData.Item10;
                comboBoxItem11.SelectedIndex = InitWorker.GetSelectedItemsData.Item11;
                comboBoxItem12.SelectedIndex = InitWorker.GetSelectedItemsData.Item12;
                comboBoxItem13.SelectedIndex = InitWorker.GetSelectedItemsData.Item13;
                comboBoxItem14.SelectedIndex = InitWorker.GetSelectedItemsData.Item14;
                comboBoxItem15.SelectedIndex = InitWorker.GetSelectedItemsData.Item15;
                comboBoxItem16.SelectedIndex = InitWorker.GetSelectedItemsData.Item16;
                comboBoxItem17.SelectedIndex = InitWorker.GetSelectedItemsData.Item17;
                comboBoxItem18.SelectedIndex = InitWorker.GetSelectedItemsData.Item18;
                comboBoxItem19.SelectedIndex = InitWorker.GetSelectedItemsData.Item19;
                comboBoxItem20.SelectedIndex = InitWorker.GetSelectedItemsData.Item20;
                comboBoxItem21.SelectedIndex = InitWorker.GetSelectedItemsData.Item21;
                comboBoxItem22.SelectedIndex = InitWorker.GetSelectedItemsData.Item22;
                comboBoxItem23.SelectedIndex = InitWorker.GetSelectedItemsData.Item23;
                comboBoxItem24.SelectedIndex = InitWorker.GetSelectedItemsData.Item24;
                comboBoxItem25.SelectedIndex = InitWorker.GetSelectedItemsData.Item25;
                comboBoxItem26.SelectedIndex = InitWorker.GetSelectedItemsData.Item26;
                comboBoxItem27.SelectedIndex = InitWorker.GetSelectedItemsData.Item27;
                comboBoxItem28.SelectedIndex = InitWorker.GetSelectedItemsData.Item28;
                comboBoxItem29.SelectedIndex = InitWorker.GetSelectedItemsData.Item29;
                comboBoxItem30.SelectedIndex = InitWorker.GetSelectedItemsData.Item30;
                comboBoxItem31.SelectedIndex = InitWorker.GetSelectedItemsData.Item31;
                comboBoxItem32.SelectedIndex = InitWorker.GetSelectedItemsData.Item32;
                comboBoxItem33.SelectedIndex = InitWorker.GetSelectedItemsData.Item33;
                comboBoxItem34.SelectedIndex = InitWorker.GetSelectedItemsData.Item34;
                comboBoxItem35.SelectedIndex = InitWorker.GetSelectedItemsData.Item35;
                comboBoxItem36.SelectedIndex = InitWorker.GetSelectedItemsData.Item36;
                comboBoxItem37.SelectedIndex = InitWorker.GetSelectedItemsData.Item37;
                comboBoxItem38.SelectedIndex = InitWorker.GetSelectedItemsData.Item38;
                comboBoxItem39.SelectedIndex = InitWorker.GetSelectedItemsData.Item39;
                comboBoxItem40.SelectedIndex = InitWorker.GetSelectedItemsData.Item40;
                comboBoxItem41.SelectedIndex = InitWorker.GetSelectedItemsData.Item41;
                comboBoxItem42.SelectedIndex = InitWorker.GetSelectedItemsData.Item42;
                comboBoxItem43.SelectedIndex = InitWorker.GetSelectedItemsData.Item43;
                comboBoxItem44.SelectedIndex = InitWorker.GetSelectedItemsData.Item44;
                comboBoxItem45.SelectedIndex = InitWorker.GetSelectedItemsData.Item45;
                comboBoxItem46.SelectedIndex = InitWorker.GetSelectedItemsData.Item46;
                comboBoxItem47.SelectedIndex = InitWorker.GetSelectedItemsData.Item47;
                comboBoxItem48.SelectedIndex = InitWorker.GetSelectedItemsData.Item48;
                comboBoxItem49.SelectedIndex = InitWorker.GetSelectedItemsData.Item49;
                comboBoxItem50.SelectedIndex = InitWorker.GetSelectedItemsData.Item50;
                comboBoxItem51.SelectedIndex = InitWorker.GetSelectedItemsData.Item51;
                comboBoxItem52.SelectedIndex = InitWorker.GetSelectedItemsData.Item52;
                comboBoxItem53.SelectedIndex = InitWorker.GetSelectedItemsData.Item53;
                comboBoxItem54.SelectedIndex = InitWorker.GetSelectedItemsData.Item54;
                comboBoxItem55.SelectedIndex = InitWorker.GetSelectedItemsData.Item55;
                comboBoxItem56.SelectedIndex = InitWorker.GetSelectedItemsData.Item56;
                comboBoxItem57.SelectedIndex = InitWorker.GetSelectedItemsData.Item57;
                comboBoxItem58.SelectedIndex = InitWorker.GetSelectedItemsData.Item58;
                comboBoxItem59.SelectedIndex = InitWorker.GetSelectedItemsData.Item59;
                comboBoxItem60.SelectedIndex = InitWorker.GetSelectedItemsData.Item60;
                comboBoxItem61.SelectedIndex = InitWorker.GetSelectedItemsData.Item61;
                comboBoxItem62.SelectedIndex = InitWorker.GetSelectedItemsData.Item62;
                comboBoxItem63.SelectedIndex = InitWorker.GetSelectedItemsData.Item63;
                comboBoxItem64.SelectedIndex = InitWorker.GetSelectedItemsData.Item64;
                comboBoxItem65.SelectedIndex = InitWorker.GetSelectedItemsData.Item65;
                comboBoxItem66.SelectedIndex = InitWorker.GetSelectedItemsData.Item66;
                comboBoxItem67.SelectedIndex = InitWorker.GetSelectedItemsData.Item67;
                comboBoxItem68.SelectedIndex = InitWorker.GetSelectedItemsData.Item68;
                comboBoxItem69.SelectedIndex = InitWorker.GetSelectedItemsData.Item69;
                comboBoxItem70.SelectedIndex = InitWorker.GetSelectedItemsData.Item70;
                comboBoxItem71.SelectedIndex = InitWorker.GetSelectedItemsData.Item71;
                comboBoxItem72.SelectedIndex = InitWorker.GetSelectedItemsData.Item72;
                comboBoxItem73.SelectedIndex = InitWorker.GetSelectedItemsData.Item73;
                comboBoxItem74.SelectedIndex = InitWorker.GetSelectedItemsData.Item74;
                comboBoxItem75.SelectedIndex = InitWorker.GetSelectedItemsData.Item75;
                comboBoxItem76.SelectedIndex = InitWorker.GetSelectedItemsData.Item76;
                comboBoxItem77.SelectedIndex = InitWorker.GetSelectedItemsData.Item77;
                comboBoxItem78.SelectedIndex = InitWorker.GetSelectedItemsData.Item78;
                comboBoxItem79.SelectedIndex = InitWorker.GetSelectedItemsData.Item79;
                comboBoxItem80.SelectedIndex = InitWorker.GetSelectedItemsData.Item80;
                comboBoxItem81.SelectedIndex = InitWorker.GetSelectedItemsData.Item81;
                comboBoxItem82.SelectedIndex = InitWorker.GetSelectedItemsData.Item82;
                comboBoxItem83.SelectedIndex = InitWorker.GetSelectedItemsData.Item83;
                comboBoxItem84.SelectedIndex = InitWorker.GetSelectedItemsData.Item84;
                comboBoxItem85.SelectedIndex = InitWorker.GetSelectedItemsData.Item85;
                comboBoxItem86.SelectedIndex = InitWorker.GetSelectedItemsData.Item86;
                comboBoxItem87.SelectedIndex = InitWorker.GetSelectedItemsData.Item87;
                comboBoxItem88.SelectedIndex = InitWorker.GetSelectedItemsData.Item88;
                comboBoxItem89.SelectedIndex = InitWorker.GetSelectedItemsData.Item89;
                comboBoxItem90.SelectedIndex = InitWorker.GetSelectedItemsData.Item90;
                comboBoxItem91.SelectedIndex = InitWorker.GetSelectedItemsData.Item91;
                comboBoxItem92.SelectedIndex = InitWorker.GetSelectedItemsData.Item92;
                comboBoxItem93.SelectedIndex = InitWorker.GetSelectedItemsData.Item93;
                comboBoxItem94.SelectedIndex = InitWorker.GetSelectedItemsData.Item94;
                comboBoxItem95.SelectedIndex = InitWorker.GetSelectedItemsData.Item95;
                comboBoxItem96.SelectedIndex = InitWorker.GetSelectedItemsData.Item96;
                comboBoxItem97.SelectedIndex = InitWorker.GetSelectedItemsData.Item97;
                comboBoxItem98.SelectedIndex = InitWorker.GetSelectedItemsData.Item98;
                comboBoxItem99.SelectedIndex = InitWorker.GetSelectedItemsData.Item99;
                comboBoxItem100.SelectedIndex = InitWorker.GetSelectedItemsData.Item100;
                comboBoxItem101.SelectedIndex = InitWorker.GetSelectedItemsData.Item101;
                comboBoxItem102.SelectedIndex = InitWorker.GetSelectedItemsData.Item102;
                comboBoxItem103.SelectedIndex = InitWorker.GetSelectedItemsData.Item103;
                comboBoxItem104.SelectedIndex = InitWorker.GetSelectedItemsData.Item104;
                comboBoxItem105.SelectedIndex = InitWorker.GetSelectedItemsData.Item105;
                comboBoxItem106.SelectedIndex = InitWorker.GetSelectedItemsData.Item106;
                comboBoxItem107.SelectedIndex = InitWorker.GetSelectedItemsData.Item107;
                comboBoxItem108.SelectedIndex = InitWorker.GetSelectedItemsData.Item108;
                comboBoxItem109.SelectedIndex = InitWorker.GetSelectedItemsData.Item109;
                comboBoxItem110.SelectedIndex = InitWorker.GetSelectedItemsData.Item110;
                comboBoxItem111.SelectedIndex = InitWorker.GetSelectedItemsData.Item111;
                comboBoxItem112.SelectedIndex = InitWorker.GetSelectedItemsData.Item112;
                comboBoxItem113.SelectedIndex = InitWorker.GetSelectedItemsData.Item113;
                comboBoxItem114.SelectedIndex = InitWorker.GetSelectedItemsData.Item114;
                comboBoxItem115.SelectedIndex = InitWorker.GetSelectedItemsData.Item115;
                comboBoxItem116.SelectedIndex = InitWorker.GetSelectedItemsData.Item116;
                comboBoxItem117.SelectedIndex = InitWorker.GetSelectedItemsData.Item117;
                comboBoxItem118.SelectedIndex = InitWorker.GetSelectedItemsData.Item118;
                comboBoxItem119.SelectedIndex = InitWorker.GetSelectedItemsData.Item119;
                comboBoxItem120.SelectedIndex = InitWorker.GetSelectedItemsData.Item120;
                comboBoxItem121.SelectedIndex = InitWorker.GetSelectedItemsData.Item121;
                comboBoxItem122.SelectedIndex = InitWorker.GetSelectedItemsData.Item122;
                comboBoxItem123.SelectedIndex = InitWorker.GetSelectedItemsData.Item123;
                comboBoxItem124.SelectedIndex = InitWorker.GetSelectedItemsData.Item124;
                comboBoxItem125.SelectedIndex = InitWorker.GetSelectedItemsData.Item125;
                comboBoxItem126.SelectedIndex = InitWorker.GetSelectedItemsData.Item126;
                comboBoxItem127.SelectedIndex = InitWorker.GetSelectedItemsData.Item127;
                comboBoxItem128.SelectedIndex = InitWorker.GetSelectedItemsData.Item128;
                comboBoxItem129.SelectedIndex = InitWorker.GetSelectedItemsData.Item129;
                comboBoxItem130.SelectedIndex = InitWorker.GetSelectedItemsData.Item130;
                comboBoxItem131.SelectedIndex = InitWorker.GetSelectedItemsData.Item131;
                comboBoxItem132.SelectedIndex = InitWorker.GetSelectedItemsData.Item132;
                comboBoxItem133.SelectedIndex = InitWorker.GetSelectedItemsData.Item133;
                comboBoxItem134.SelectedIndex = InitWorker.GetSelectedItemsData.Item134;
                comboBoxItem135.SelectedIndex = InitWorker.GetSelectedItemsData.Item135;
                comboBoxItem136.SelectedIndex = InitWorker.GetSelectedItemsData.Item136;
                comboBoxItem137.SelectedIndex = InitWorker.GetSelectedItemsData.Item137;
                comboBoxItem138.SelectedIndex = InitWorker.GetSelectedItemsData.Item138;
                comboBoxItem139.SelectedIndex = InitWorker.GetSelectedItemsData.Item139;
                comboBoxItem140.SelectedIndex = InitWorker.GetSelectedItemsData.Item140;
                comboBoxItem141.SelectedIndex = InitWorker.GetSelectedItemsData.Item141;
                comboBoxItem142.SelectedIndex = InitWorker.GetSelectedItemsData.Item142;
                comboBoxItem143.SelectedIndex = InitWorker.GetSelectedItemsData.Item143;
                comboBoxItem144.SelectedIndex = InitWorker.GetSelectedItemsData.Item144;
                comboBoxItem145.SelectedIndex = InitWorker.GetSelectedItemsData.Item145;
                comboBoxItem146.SelectedIndex = InitWorker.GetSelectedItemsData.Item146;
                comboBoxItem147.SelectedIndex = InitWorker.GetSelectedItemsData.Item147;
                comboBoxItem148.SelectedIndex = InitWorker.GetSelectedItemsData.Item148;
                comboBoxItem149.SelectedIndex = InitWorker.GetSelectedItemsData.Item149;
                comboBoxItem150.SelectedIndex = InitWorker.GetSelectedItemsData.Item150;
                comboBoxItem151.SelectedIndex = InitWorker.GetSelectedItemsData.Item151;
                comboBoxItem152.SelectedIndex = InitWorker.GetSelectedItemsData.Item152;
                comboBoxItem153.SelectedIndex = InitWorker.GetSelectedItemsData.Item153;
                comboBoxItem154.SelectedIndex = InitWorker.GetSelectedItemsData.Item154;
                comboBoxItem155.SelectedIndex = InitWorker.GetSelectedItemsData.Item155;
                comboBoxItem156.SelectedIndex = InitWorker.GetSelectedItemsData.Item156;
                comboBoxItem157.SelectedIndex = InitWorker.GetSelectedItemsData.Item157;
                comboBoxItem158.SelectedIndex = InitWorker.GetSelectedItemsData.Item158;
                comboBoxItem159.SelectedIndex = InitWorker.GetSelectedItemsData.Item159;
                comboBoxItem160.SelectedIndex = InitWorker.GetSelectedItemsData.Item160;
                comboBoxItem161.SelectedIndex = InitWorker.GetSelectedItemsData.Item161;
                comboBoxItem162.SelectedIndex = InitWorker.GetSelectedItemsData.Item162;
                comboBoxItem163.SelectedIndex = InitWorker.GetSelectedItemsData.Item163;
                comboBoxItem164.SelectedIndex = InitWorker.GetSelectedItemsData.Item164;
                comboBoxItem165.SelectedIndex = InitWorker.GetSelectedItemsData.Item165;
                comboBoxItem166.SelectedIndex = InitWorker.GetSelectedItemsData.Item166;
                comboBoxItem167.SelectedIndex = InitWorker.GetSelectedItemsData.Item167;
                comboBoxItem168.SelectedIndex = InitWorker.GetSelectedItemsData.Item168;
                comboBoxItem169.SelectedIndex = InitWorker.GetSelectedItemsData.Item169;
                comboBoxItem170.SelectedIndex = InitWorker.GetSelectedItemsData.Item170;
                comboBoxItem171.SelectedIndex = InitWorker.GetSelectedItemsData.Item171;
                comboBoxItem172.SelectedIndex = InitWorker.GetSelectedItemsData.Item172;
                comboBoxItem173.SelectedIndex = InitWorker.GetSelectedItemsData.Item173;
                comboBoxItem174.SelectedIndex = InitWorker.GetSelectedItemsData.Item174;
                comboBoxItem175.SelectedIndex = InitWorker.GetSelectedItemsData.Item175;
                comboBoxItem176.SelectedIndex = InitWorker.GetSelectedItemsData.Item176;
                comboBoxItem177.SelectedIndex = InitWorker.GetSelectedItemsData.Item177;
                comboBoxItem178.SelectedIndex = InitWorker.GetSelectedItemsData.Item178;
                comboBoxItem179.SelectedIndex = InitWorker.GetSelectedItemsData.Item179;
                comboBoxItem180.SelectedIndex = InitWorker.GetSelectedItemsData.Item180;
                comboBoxItem181.SelectedIndex = InitWorker.GetSelectedItemsData.Item181;
                comboBoxItem182.SelectedIndex = InitWorker.GetSelectedItemsData.Item182;
                comboBoxItem183.SelectedIndex = InitWorker.GetSelectedItemsData.Item183;
                comboBoxItem184.SelectedIndex = InitWorker.GetSelectedItemsData.Item184;
                comboBoxItem185.SelectedIndex = InitWorker.GetSelectedItemsData.Item185;
                comboBoxItem186.SelectedIndex = InitWorker.GetSelectedItemsData.Item186;
                comboBoxItem187.SelectedIndex = InitWorker.GetSelectedItemsData.Item187;
                comboBoxItem188.SelectedIndex = InitWorker.GetSelectedItemsData.Item188;
                comboBoxItem189.SelectedIndex = InitWorker.GetSelectedItemsData.Item189;
                comboBoxItem190.SelectedIndex = InitWorker.GetSelectedItemsData.Item190;
                comboBoxItem191.SelectedIndex = InitWorker.GetSelectedItemsData.Item191;
                comboBoxItem192.SelectedIndex = InitWorker.GetSelectedItemsData.Item192;
                comboBoxItem193.SelectedIndex = InitWorker.GetSelectedItemsData.Item193;
                comboBoxItem194.SelectedIndex = InitWorker.GetSelectedItemsData.Item194;
                comboBoxItem195.SelectedIndex = InitWorker.GetSelectedItemsData.Item195;
                comboBoxItem196.SelectedIndex = InitWorker.GetSelectedItemsData.Item196;
                comboBoxItem197.SelectedIndex = InitWorker.GetSelectedItemsData.Item197;
                comboBoxItem198.SelectedIndex = InitWorker.GetSelectedItemsData.Item198;
                numericUpDownItemQ1.Value = InitWorker.GetSelectedItemsData.Item1Quantity;
                numericUpDownItemQ2.Value = InitWorker.GetSelectedItemsData.Item2Quantity;
                numericUpDownItemQ3.Value = InitWorker.GetSelectedItemsData.Item3Quantity;
                numericUpDownItemQ4.Value = InitWorker.GetSelectedItemsData.Item4Quantity;
                numericUpDownItemQ5.Value = InitWorker.GetSelectedItemsData.Item5Quantity;
                numericUpDownItemQ6.Value = InitWorker.GetSelectedItemsData.Item6Quantity;
                numericUpDownItemQ7.Value = InitWorker.GetSelectedItemsData.Item7Quantity;
                numericUpDownItemQ8.Value = InitWorker.GetSelectedItemsData.Item8Quantity;
                numericUpDownItemQ9.Value = InitWorker.GetSelectedItemsData.Item9Quantity;
                numericUpDownItemQ10.Value = InitWorker.GetSelectedItemsData.Item10Quantity;
                numericUpDownItemQ11.Value = InitWorker.GetSelectedItemsData.Item11Quantity;
                numericUpDownItemQ12.Value = InitWorker.GetSelectedItemsData.Item12Quantity;
                numericUpDownItemQ13.Value = InitWorker.GetSelectedItemsData.Item13Quantity;
                numericUpDownItemQ14.Value = InitWorker.GetSelectedItemsData.Item14Quantity;
                numericUpDownItemQ15.Value = InitWorker.GetSelectedItemsData.Item15Quantity;
                numericUpDownItemQ16.Value = InitWorker.GetSelectedItemsData.Item16Quantity;
                numericUpDownItemQ17.Value = InitWorker.GetSelectedItemsData.Item17Quantity;
                numericUpDownItemQ18.Value = InitWorker.GetSelectedItemsData.Item18Quantity;
                numericUpDownItemQ19.Value = InitWorker.GetSelectedItemsData.Item19Quantity;
                numericUpDownItemQ20.Value = InitWorker.GetSelectedItemsData.Item20Quantity;
                numericUpDownItemQ21.Value = InitWorker.GetSelectedItemsData.Item21Quantity;
                numericUpDownItemQ22.Value = InitWorker.GetSelectedItemsData.Item22Quantity;
                numericUpDownItemQ23.Value = InitWorker.GetSelectedItemsData.Item23Quantity;
                numericUpDownItemQ24.Value = InitWorker.GetSelectedItemsData.Item24Quantity;
                numericUpDownItemQ25.Value = InitWorker.GetSelectedItemsData.Item25Quantity;
                numericUpDownItemQ26.Value = InitWorker.GetSelectedItemsData.Item26Quantity;
                numericUpDownItemQ27.Value = InitWorker.GetSelectedItemsData.Item27Quantity;
                numericUpDownItemQ28.Value = InitWorker.GetSelectedItemsData.Item28Quantity;
                numericUpDownItemQ29.Value = InitWorker.GetSelectedItemsData.Item29Quantity;
                numericUpDownItemQ30.Value = InitWorker.GetSelectedItemsData.Item30Quantity;
                numericUpDownItemQ31.Value = InitWorker.GetSelectedItemsData.Item31Quantity;
                numericUpDownItemQ32.Value = InitWorker.GetSelectedItemsData.Item32Quantity;
                numericUpDownItemQ33.Value = InitWorker.GetSelectedItemsData.Item33Quantity;
                numericUpDownItemQ34.Value = InitWorker.GetSelectedItemsData.Item34Quantity;
                numericUpDownItemQ35.Value = InitWorker.GetSelectedItemsData.Item35Quantity;
                numericUpDownItemQ36.Value = InitWorker.GetSelectedItemsData.Item36Quantity;
                numericUpDownItemQ37.Value = InitWorker.GetSelectedItemsData.Item37Quantity;
                numericUpDownItemQ38.Value = InitWorker.GetSelectedItemsData.Item38Quantity;
                numericUpDownItemQ39.Value = InitWorker.GetSelectedItemsData.Item39Quantity;
                numericUpDownItemQ40.Value = InitWorker.GetSelectedItemsData.Item40Quantity;
                numericUpDownItemQ41.Value = InitWorker.GetSelectedItemsData.Item41Quantity;
                numericUpDownItemQ42.Value = InitWorker.GetSelectedItemsData.Item42Quantity;
                numericUpDownItemQ43.Value = InitWorker.GetSelectedItemsData.Item43Quantity;
                numericUpDownItemQ44.Value = InitWorker.GetSelectedItemsData.Item44Quantity;
                numericUpDownItemQ45.Value = InitWorker.GetSelectedItemsData.Item45Quantity;
                numericUpDownItemQ46.Value = InitWorker.GetSelectedItemsData.Item46Quantity;
                numericUpDownItemQ47.Value = InitWorker.GetSelectedItemsData.Item47Quantity;
                numericUpDownItemQ48.Value = InitWorker.GetSelectedItemsData.Item48Quantity;
                numericUpDownItemQ49.Value = InitWorker.GetSelectedItemsData.Item49Quantity;
                numericUpDownItemQ50.Value = InitWorker.GetSelectedItemsData.Item50Quantity;
                numericUpDownItemQ51.Value = InitWorker.GetSelectedItemsData.Item51Quantity;
                numericUpDownItemQ52.Value = InitWorker.GetSelectedItemsData.Item52Quantity;
                numericUpDownItemQ53.Value = InitWorker.GetSelectedItemsData.Item53Quantity;
                numericUpDownItemQ54.Value = InitWorker.GetSelectedItemsData.Item54Quantity;
                numericUpDownItemQ55.Value = InitWorker.GetSelectedItemsData.Item55Quantity;
                numericUpDownItemQ56.Value = InitWorker.GetSelectedItemsData.Item56Quantity;
                numericUpDownItemQ57.Value = InitWorker.GetSelectedItemsData.Item57Quantity;
                numericUpDownItemQ58.Value = InitWorker.GetSelectedItemsData.Item58Quantity;
                numericUpDownItemQ59.Value = InitWorker.GetSelectedItemsData.Item59Quantity;
                numericUpDownItemQ60.Value = InitWorker.GetSelectedItemsData.Item60Quantity;
                numericUpDownItemQ61.Value = InitWorker.GetSelectedItemsData.Item61Quantity;
                numericUpDownItemQ62.Value = InitWorker.GetSelectedItemsData.Item62Quantity;
                numericUpDownItemQ63.Value = InitWorker.GetSelectedItemsData.Item63Quantity;
                numericUpDownItemQ64.Value = InitWorker.GetSelectedItemsData.Item64Quantity;
                numericUpDownItemQ65.Value = InitWorker.GetSelectedItemsData.Item65Quantity;
                numericUpDownItemQ66.Value = InitWorker.GetSelectedItemsData.Item66Quantity;
                numericUpDownItemQ67.Value = InitWorker.GetSelectedItemsData.Item67Quantity;
                numericUpDownItemQ68.Value = InitWorker.GetSelectedItemsData.Item68Quantity;
                numericUpDownItemQ69.Value = InitWorker.GetSelectedItemsData.Item69Quantity;
                numericUpDownItemQ70.Value = InitWorker.GetSelectedItemsData.Item70Quantity;
                numericUpDownItemQ71.Value = InitWorker.GetSelectedItemsData.Item71Quantity;
                numericUpDownItemQ72.Value = InitWorker.GetSelectedItemsData.Item72Quantity;
                numericUpDownItemQ73.Value = InitWorker.GetSelectedItemsData.Item73Quantity;
                numericUpDownItemQ74.Value = InitWorker.GetSelectedItemsData.Item74Quantity;
                numericUpDownItemQ75.Value = InitWorker.GetSelectedItemsData.Item75Quantity;
                numericUpDownItemQ76.Value = InitWorker.GetSelectedItemsData.Item76Quantity;
                numericUpDownItemQ77.Value = InitWorker.GetSelectedItemsData.Item77Quantity;
                numericUpDownItemQ78.Value = InitWorker.GetSelectedItemsData.Item78Quantity;
                numericUpDownItemQ79.Value = InitWorker.GetSelectedItemsData.Item79Quantity;
                numericUpDownItemQ80.Value = InitWorker.GetSelectedItemsData.Item80Quantity;
                numericUpDownItemQ81.Value = InitWorker.GetSelectedItemsData.Item81Quantity;
                numericUpDownItemQ82.Value = InitWorker.GetSelectedItemsData.Item82Quantity;
                numericUpDownItemQ83.Value = InitWorker.GetSelectedItemsData.Item83Quantity;
                numericUpDownItemQ84.Value = InitWorker.GetSelectedItemsData.Item84Quantity;
                numericUpDownItemQ85.Value = InitWorker.GetSelectedItemsData.Item85Quantity;
                numericUpDownItemQ86.Value = InitWorker.GetSelectedItemsData.Item86Quantity;
                numericUpDownItemQ87.Value = InitWorker.GetSelectedItemsData.Item87Quantity;
                numericUpDownItemQ88.Value = InitWorker.GetSelectedItemsData.Item88Quantity;
                numericUpDownItemQ89.Value = InitWorker.GetSelectedItemsData.Item89Quantity;
                numericUpDownItemQ90.Value = InitWorker.GetSelectedItemsData.Item90Quantity;
                numericUpDownItemQ91.Value = InitWorker.GetSelectedItemsData.Item91Quantity;
                numericUpDownItemQ92.Value = InitWorker.GetSelectedItemsData.Item92Quantity;
                numericUpDownItemQ93.Value = InitWorker.GetSelectedItemsData.Item93Quantity;
                numericUpDownItemQ94.Value = InitWorker.GetSelectedItemsData.Item94Quantity;
                numericUpDownItemQ95.Value = InitWorker.GetSelectedItemsData.Item95Quantity;
                numericUpDownItemQ96.Value = InitWorker.GetSelectedItemsData.Item96Quantity;
                numericUpDownItemQ97.Value = InitWorker.GetSelectedItemsData.Item97Quantity;
                numericUpDownItemQ98.Value = InitWorker.GetSelectedItemsData.Item98Quantity;
                numericUpDownItemQ99.Value = InitWorker.GetSelectedItemsData.Item99Quantity;
                numericUpDownItemQ100.Value = InitWorker.GetSelectedItemsData.Item100Quantity;
                numericUpDownItemQ101.Value = InitWorker.GetSelectedItemsData.Item101Quantity;
                numericUpDownItemQ102.Value = InitWorker.GetSelectedItemsData.Item102Quantity;
                numericUpDownItemQ103.Value = InitWorker.GetSelectedItemsData.Item103Quantity;
                numericUpDownItemQ104.Value = InitWorker.GetSelectedItemsData.Item104Quantity;
                numericUpDownItemQ105.Value = InitWorker.GetSelectedItemsData.Item105Quantity;
                numericUpDownItemQ106.Value = InitWorker.GetSelectedItemsData.Item106Quantity;
                numericUpDownItemQ107.Value = InitWorker.GetSelectedItemsData.Item107Quantity;
                numericUpDownItemQ108.Value = InitWorker.GetSelectedItemsData.Item108Quantity;
                numericUpDownItemQ109.Value = InitWorker.GetSelectedItemsData.Item109Quantity;
                numericUpDownItemQ110.Value = InitWorker.GetSelectedItemsData.Item110Quantity;
                numericUpDownItemQ111.Value = InitWorker.GetSelectedItemsData.Item111Quantity;
                numericUpDownItemQ112.Value = InitWorker.GetSelectedItemsData.Item112Quantity;
                numericUpDownItemQ113.Value = InitWorker.GetSelectedItemsData.Item113Quantity;
                numericUpDownItemQ114.Value = InitWorker.GetSelectedItemsData.Item114Quantity;
                numericUpDownItemQ115.Value = InitWorker.GetSelectedItemsData.Item115Quantity;
                numericUpDownItemQ116.Value = InitWorker.GetSelectedItemsData.Item116Quantity;
                numericUpDownItemQ117.Value = InitWorker.GetSelectedItemsData.Item117Quantity;
                numericUpDownItemQ118.Value = InitWorker.GetSelectedItemsData.Item118Quantity;
                numericUpDownItemQ119.Value = InitWorker.GetSelectedItemsData.Item119Quantity;
                numericUpDownItemQ120.Value = InitWorker.GetSelectedItemsData.Item120Quantity;
                numericUpDownItemQ121.Value = InitWorker.GetSelectedItemsData.Item121Quantity;
                numericUpDownItemQ122.Value = InitWorker.GetSelectedItemsData.Item122Quantity;
                numericUpDownItemQ123.Value = InitWorker.GetSelectedItemsData.Item123Quantity;
                numericUpDownItemQ124.Value = InitWorker.GetSelectedItemsData.Item124Quantity;
                numericUpDownItemQ125.Value = InitWorker.GetSelectedItemsData.Item125Quantity;
                numericUpDownItemQ126.Value = InitWorker.GetSelectedItemsData.Item126Quantity;
                numericUpDownItemQ127.Value = InitWorker.GetSelectedItemsData.Item127Quantity;
                numericUpDownItemQ128.Value = InitWorker.GetSelectedItemsData.Item128Quantity;
                numericUpDownItemQ129.Value = InitWorker.GetSelectedItemsData.Item129Quantity;
                numericUpDownItemQ130.Value = InitWorker.GetSelectedItemsData.Item130Quantity;
                numericUpDownItemQ131.Value = InitWorker.GetSelectedItemsData.Item131Quantity;
                numericUpDownItemQ132.Value = InitWorker.GetSelectedItemsData.Item132Quantity;
                numericUpDownItemQ133.Value = InitWorker.GetSelectedItemsData.Item133Quantity;
                numericUpDownItemQ134.Value = InitWorker.GetSelectedItemsData.Item134Quantity;
                numericUpDownItemQ135.Value = InitWorker.GetSelectedItemsData.Item135Quantity;
                numericUpDownItemQ136.Value = InitWorker.GetSelectedItemsData.Item136Quantity;
                numericUpDownItemQ137.Value = InitWorker.GetSelectedItemsData.Item137Quantity;
                numericUpDownItemQ138.Value = InitWorker.GetSelectedItemsData.Item138Quantity;
                numericUpDownItemQ139.Value = InitWorker.GetSelectedItemsData.Item139Quantity;
                numericUpDownItemQ140.Value = InitWorker.GetSelectedItemsData.Item140Quantity;
                numericUpDownItemQ141.Value = InitWorker.GetSelectedItemsData.Item141Quantity;
                numericUpDownItemQ142.Value = InitWorker.GetSelectedItemsData.Item142Quantity;
                numericUpDownItemQ143.Value = InitWorker.GetSelectedItemsData.Item143Quantity;
                numericUpDownItemQ144.Value = InitWorker.GetSelectedItemsData.Item144Quantity;
                numericUpDownItemQ145.Value = InitWorker.GetSelectedItemsData.Item145Quantity;
                numericUpDownItemQ146.Value = InitWorker.GetSelectedItemsData.Item146Quantity;
                numericUpDownItemQ147.Value = InitWorker.GetSelectedItemsData.Item147Quantity;
                numericUpDownItemQ148.Value = InitWorker.GetSelectedItemsData.Item148Quantity;
                numericUpDownItemQ149.Value = InitWorker.GetSelectedItemsData.Item149Quantity;
                numericUpDownItemQ150.Value = InitWorker.GetSelectedItemsData.Item150Quantity;
                numericUpDownItemQ151.Value = InitWorker.GetSelectedItemsData.Item151Quantity;
                numericUpDownItemQ152.Value = InitWorker.GetSelectedItemsData.Item152Quantity;
                numericUpDownItemQ153.Value = InitWorker.GetSelectedItemsData.Item153Quantity;
                numericUpDownItemQ154.Value = InitWorker.GetSelectedItemsData.Item154Quantity;
                numericUpDownItemQ155.Value = InitWorker.GetSelectedItemsData.Item155Quantity;
                numericUpDownItemQ156.Value = InitWorker.GetSelectedItemsData.Item156Quantity;
                numericUpDownItemQ157.Value = InitWorker.GetSelectedItemsData.Item157Quantity;
                numericUpDownItemQ158.Value = InitWorker.GetSelectedItemsData.Item158Quantity;
                numericUpDownItemQ159.Value = InitWorker.GetSelectedItemsData.Item159Quantity;
                numericUpDownItemQ160.Value = InitWorker.GetSelectedItemsData.Item160Quantity;
                numericUpDownItemQ161.Value = InitWorker.GetSelectedItemsData.Item161Quantity;
                numericUpDownItemQ162.Value = InitWorker.GetSelectedItemsData.Item162Quantity;
                numericUpDownItemQ163.Value = InitWorker.GetSelectedItemsData.Item163Quantity;
                numericUpDownItemQ164.Value = InitWorker.GetSelectedItemsData.Item164Quantity;
                numericUpDownItemQ165.Value = InitWorker.GetSelectedItemsData.Item165Quantity;
                numericUpDownItemQ166.Value = InitWorker.GetSelectedItemsData.Item166Quantity;
                numericUpDownItemQ167.Value = InitWorker.GetSelectedItemsData.Item167Quantity;
                numericUpDownItemQ168.Value = InitWorker.GetSelectedItemsData.Item168Quantity;
                numericUpDownItemQ169.Value = InitWorker.GetSelectedItemsData.Item169Quantity;
                numericUpDownItemQ170.Value = InitWorker.GetSelectedItemsData.Item170Quantity;
                numericUpDownItemQ171.Value = InitWorker.GetSelectedItemsData.Item171Quantity;
                numericUpDownItemQ172.Value = InitWorker.GetSelectedItemsData.Item172Quantity;
                numericUpDownItemQ173.Value = InitWorker.GetSelectedItemsData.Item173Quantity;
                numericUpDownItemQ174.Value = InitWorker.GetSelectedItemsData.Item174Quantity;
                numericUpDownItemQ175.Value = InitWorker.GetSelectedItemsData.Item175Quantity;
                numericUpDownItemQ176.Value = InitWorker.GetSelectedItemsData.Item176Quantity;
                numericUpDownItemQ177.Value = InitWorker.GetSelectedItemsData.Item177Quantity;
                numericUpDownItemQ178.Value = InitWorker.GetSelectedItemsData.Item178Quantity;
                numericUpDownItemQ179.Value = InitWorker.GetSelectedItemsData.Item179Quantity;
                numericUpDownItemQ180.Value = InitWorker.GetSelectedItemsData.Item180Quantity;
                numericUpDownItemQ181.Value = InitWorker.GetSelectedItemsData.Item181Quantity;
                numericUpDownItemQ182.Value = InitWorker.GetSelectedItemsData.Item182Quantity;
                numericUpDownItemQ183.Value = InitWorker.GetSelectedItemsData.Item183Quantity;
                numericUpDownItemQ184.Value = InitWorker.GetSelectedItemsData.Item184Quantity;
                numericUpDownItemQ185.Value = InitWorker.GetSelectedItemsData.Item185Quantity;
                numericUpDownItemQ186.Value = InitWorker.GetSelectedItemsData.Item186Quantity;
                numericUpDownItemQ187.Value = InitWorker.GetSelectedItemsData.Item187Quantity;
                numericUpDownItemQ188.Value = InitWorker.GetSelectedItemsData.Item188Quantity;
                numericUpDownItemQ189.Value = InitWorker.GetSelectedItemsData.Item189Quantity;
                numericUpDownItemQ190.Value = InitWorker.GetSelectedItemsData.Item190Quantity;
                numericUpDownItemQ191.Value = InitWorker.GetSelectedItemsData.Item191Quantity;
                numericUpDownItemQ192.Value = InitWorker.GetSelectedItemsData.Item192Quantity;
                numericUpDownItemQ193.Value = InitWorker.GetSelectedItemsData.Item193Quantity;
                numericUpDownItemQ194.Value = InitWorker.GetSelectedItemsData.Item194Quantity;
                numericUpDownItemQ195.Value = InitWorker.GetSelectedItemsData.Item195Quantity;
                numericUpDownItemQ196.Value = InitWorker.GetSelectedItemsData.Item196Quantity;
                numericUpDownItemQ197.Value = InitWorker.GetSelectedItemsData.Item197Quantity;
                numericUpDownItemQ198.Value = InitWorker.GetSelectedItemsData.Item198Quantity;
            }
            catch (Exception Exception)
            {
                MessageBox.Show(Exception.ToString());
            }
            _loaded = true;
        }

        #endregion

    }
}
