using SCADABepTuDongWPFV3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.IO.Ports;

namespace SCADABepTuDongWPFV3
{
    public partial class wdTestCook : Window
    {
        string recipeName;
        int step = 0;
        int k = 0;
        int ID = 0;
        string ReceiveBep;
        string ReceiveRobot;
        string gcode1, gcode2, gcode3, gcode4;
        public string _CheckEnd;
        private List<RecipeModel> MyList1 = new List<RecipeModel>();
        public static SerialPort PortBep = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
        public static SerialPort PortRobot = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);

        public wdTestCook(string recipe)
        {

            InitializeComponent();
            this.DataContext = this;
            recipeName = recipe;
            Hienthi1.Text = recipeName.ToString();
            Open_Robot_Bep();
            preSetUpRobot();
            RunCook(recipeName);
            ShowCook();
        }
        private void Open_Robot_Bep() //Đọc dữ liệu từ các cổng truyền thông
        {
            Thread t11 = new Thread(() =>
            {
                while (true)
                {
                    this.Dispatcher.Invoke((Action)(() =>
                    {//this refer to form in WPF application 

                        ReceiveBep += PortBep.ReadExisting();

                    }));
                }
            });
            t11.Start();

            Thread t12 = new Thread(() =>
            {
                while (true)
                {
                    this.Dispatcher.Invoke((Action)(() =>
                    {//this refer to form in WPF application 

                        ReceiveRobot += PortRobot.ReadExisting();

                    }));
                }
            });
            t12.Start();
        }
        
        private void preSetUpRobot() //Các bước khởi tạo trước khi truyền tọa độ cho Robot
        {
            if (PortRobot.IsOpen)
            {
                byte[] bytestosend2 = new byte[1] { 0x30 }; //StopByte
                PortRobot.Write(bytestosend2, 0, 1);
                Thread.Sleep(500);
                bytestosend2 = new byte[1] { 0x10 }; //ExitByte
                PortRobot.Write(bytestosend2, 0, 1);
                Thread.Sleep(500);
                bytestosend2 = new byte[1] { 0x12 }; //ResetByte
                PortRobot.Write(bytestosend2, 0, 1);
                Thread.Sleep(4000);

                bytestosend2 = new byte[1] { 0x30 };
                PortRobot.Write(bytestosend2, 0, 1);
                Thread.Sleep(500);
                bytestosend2 = new byte[1] { 0x10 };
                PortRobot.Write(bytestosend2, 0, 1);
                Thread.Sleep(500);
                bytestosend2 = new byte[1] { 0x14 }; //TeachByte
                PortRobot.Write(bytestosend2, 0, 1);
                Thread.Sleep(500);
            }
        }
        private void RunCook( string tempRecipeName) //Check tên bước để đưa ra lệnh điều khiển tương ứng cho robot và bếp
        {
            Thread t2 = new Thread(() =>
            {
                int end = 0;
                while (end == 0)
                {
                    var tempRecipe = DataProvider.Ins.DB.Recipes.Where(p => p.DisplayName == tempRecipeName);
                    foreach (var item in tempRecipe)
                    {
                        ID = item.Id;
                    }
                    var tempStepRecipe = DataProvider.Ins.DB.StepRecipes.Where(p => p.IdRecipe == ID);
                    foreach (var item in tempStepRecipe)
                    {
                        step = (int)item.NumberStep; 
                        switch(item.DisplayName)
                        {
                            case ("Gia nhiệt"):
                                {
                                    setUpBep((byte)item.C_Temp, 0, 0, 1);
                                    int time = 3600 * (int)item.C_Hours + 60 * (int)item.C_Minutes + (int)item.C_Seconds;
                                    Thread.Sleep(time*1000);
                                    break;
                                }
                            case ("Thêm hộp 1"):
                                {
                                    var RobotAction = DataProvider.Ins.DB.RobotActionCodes.Where(x => x.ActionName == "Thêm hộp 1").SingleOrDefault();
                                    gcode1 = RobotAction.GCode;
                                    string[] code1 = gcode1.Split('\n');
                                    setUpRobot(code1);
                                    break;
                                }
                            case ("Thêm hộp 2"):
                                {
                                    var RobotAction = DataProvider.Ins.DB.RobotActionCodes.Where(x => x.ActionName == "Thêm hộp 2").SingleOrDefault();
                                    gcode2 = RobotAction.GCode;
                                    string[] code2 = gcode2.Split('\n');
                                    setUpRobot(code2);
                                    break;
                                }
                            case ("Thêm hộp 3"):
                                {
                                    var RobotAction = DataProvider.Ins.DB.RobotActionCodes.Where(x => x.ActionName == "Thêm hộp 3").SingleOrDefault();
                                    gcode3 = RobotAction.GCode;
                                    string[] code3 = gcode3.Split('\n');
                                    setUpRobot(code3);
                                    break;
                                }
                            case ("Thêm hộp 4"):
                                {
                                    var RobotAction = DataProvider.Ins.DB.RobotActionCodes.Where(x => x.ActionName == "Thêm hộp 4").SingleOrDefault();
                                    gcode4 = RobotAction.GCode;
                                    string[] code4 = gcode4.Split('\n');
                                    setUpRobot(code4);
                                    break;
                                }
                            case ("Dừng nấu"):
                                {
                                    setUpBep(0, 0, 0, 0);
                                    break;
                                }
                            default:
                                {
                                    Thread.Sleep(5000);
                                    break;
                                }
                        }
                        ReceiveRobot = "";
                        ReceiveBep = "";
                    }
                    end = 1;
                    string[] InitPos = { "G20 X=280.1 Y=0 Z=553 A=0 B=180 C=0 D=0" };
                    setUpRobot(InitPos);
                }

            });
            t2.Start();
       
        }
        //----------------------------------------------------
        private void setUpRobot(string[] a)        //Gửi mã Gcode cho Robot
        {
            int i = 1;
            PortRobot.WriteLine(a[0]);
            while (i < a.Length)
            {
                Thread.Sleep(100);

                this.Dispatcher.Invoke((Action)(() =>
                {//this refer to form in WPF application 

                    _CheckEnd = ReceiveRobot.Substring(ReceiveRobot.Length - 1, 1);
                }));

                if (_CheckEnd == "%")
                {
                    PortRobot.WriteLine(a[i]);

                    i++;
                }

            }
        }
        private string Display(byte[] frame)
        {
            string result = string.Empty;
            foreach (byte item in frame)
            {
                result = string.Format("{0:X2} ", item);
            }
            return result;
        }
        private void setUpBep(byte Temp, byte Timer, byte paraTimer, byte power)        //Gửi dữ liệu cho bếp
        {
            byte[] frame = new byte[11];
            frame[0] = 0x5A;/* Byte khoi tao */
            frame[1] = 0x08;
            frame[2] = 0x01;
            frame[3] = 0x01;
            frame[4] = Temp; // nhiet do
            frame[5] = Timer; // Bat timer, frame[5] = 0x01;
            frame[6] = paraTimer;
            frame[7] = 0x00;
            frame[8] = 0x00;
            frame[9] = power; // Tat bep, frame[9] = 0x00;

            for (int i = 1; i < 10; i++)
                frame[10] += frame[i];
            PortBep.Write(frame, 0, frame.Length);
            this.Display(frame);
            Thread.Sleep(100);
        }
        //---------------------------------------------------------
        private void ShowCook()
        {
            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    if (k != step)
                    {
                        this.Dispatcher.Invoke(() => LoadRecipe(ID, step));
                    }
                    k = step;
                    Thread.Sleep(100);
                }
            });
            t1.Start();
        }
        private void LoadRecipe(int Id, int step) //hiển thị các bước đang thực hiện lên giao diện
        {

            //MyList1.Clear();
            var List_step = DataProvider.Ins.DB.StepRecipes.Where(p => p.IdRecipe == Id && p.NumberStep == step);

            foreach (var item in List_step)
            {
                MyList1.Add(new RecipeModel()
                {
                    STT = (int)item.NumberStep,
                    DisplayName = item.DisplayName,
                    Param = item.C_Param,
                    Temp = (int)item.C_Temp,
                    Timer = 3600 * (int)item.C_Hours + 60 * (int)item.C_Minutes + (int)item.C_Seconds
                }
                );
                lvRecipeList.ItemsSource = null;
                lvRecipeList.ItemsSource = MyList1;
            }
        }

        private void DragMoveWindow_event(object sender, MouseButtonEventArgs e)
        {
            wdActivate.DragMove();
        }

        private void ColorZone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (wdActivate.WindowState == WindowState.Normal) wdActivate.WindowState = WindowState.Maximized;
            else wdActivate.WindowState = WindowState.Normal;
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
                this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hienthi1.Text = recipeName.ToString();

            int ID = 0;
            var data_sql = DataProvider.Ins.DB.Recipes.Where(p => p.DisplayName == recipeName);
            foreach (var item in data_sql)
            {
                ID = item.Id;
            }

            var ListRecipe = DataProvider.Ins.DB.StepRecipes.Where(p => p.IdRecipe == ID);
            foreach (var item in ListRecipe)
            {
                LoadRecipe(ID, (int)item.NumberStep);

            }
        }

        public class RecipeModel
        {
            private int sTT;
            public int STT { get => sTT; set { sTT = value; OnPropertyChanged("STT"); } } 

            private string displayName;
            public string DisplayName { get => displayName; set { displayName = value; OnPropertyChanged("DisplayName"); } }

            private string param;
            public string Param { get => param; set { param = value; OnPropertyChanged("Param"); } }

            private int temp ;
            public int Temp { get => temp; set { temp = value; OnPropertyChanged("Temp"); } }

            private int timer;
            public int Timer { get => timer; set { timer = value; OnPropertyChanged("Timer"); } }
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        //---------------------------------------------------------------------------
        public RecipeModel selectedItem;
        public RecipeModel SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       

        public string DisplayName { get; private set; }
     

       


    }
}
