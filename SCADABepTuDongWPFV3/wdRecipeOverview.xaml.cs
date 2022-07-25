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
    public partial class wdRecipeOverview : Window
    {
        private List<RecipeModel> recipeList = new List<RecipeModel>();
        public static SerialPort portBep = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
        public static SerialPort portRobot = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
        public bool cookerStatus;
        public bool robotStatus;


        public wdRecipeOverview()
        {
            InitializeComponent();
            this.DataContext = this;
            LoadRecipe();
        }

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

        public string DisplayName { get; private set; }

        private void LoadRecipe()
        {
            recipeList.Clear();
            var temp = DataProvider.Ins.DB.Recipes.ToList();
            int STT = 1;
            foreach (var item in temp)
            {
                recipeList.Add(new RecipeModel() { STT = STT, DisplayName = item.DisplayName });
                STT++;
            }
            lvRecipeList.ItemsSource = null;
            lvRecipeList.ItemsSource = recipeList;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvRecipeList.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("DisplayName", ListSortDirection.Ascending));
        }

        #region
        /// <summary>
        /// Sets property if it does not equal existing value. Notifies listeners if change occurs.
        /// </summary>
        /// <typeparam name="T">Type of property.</typeparam>
        /// <param name="member">The property's backing field.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This
        /// value is optional and can be provided automatically when invoked from compilers
        /// that support <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual bool SetProperty<T>(ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(member, value))
            {
                return false;
            }

            member = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property, used to notify listeners.</param>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Window wd = new wdSettingRecipe(true, "");
            wd.ShowDialog();
            LoadRecipe();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Choose the Recipe you want to edit!", "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Window wd = new wdSettingRecipe(false, SelectedItem.DisplayName);
                wd.ShowDialog();
                LoadRecipe();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Choose the Recipe to Delete first!", "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var tempRecipe = DataProvider.Ins.DB.Recipes.Where(p => p.DisplayName == SelectedItem.DisplayName).SingleOrDefault();
                DataProvider.Ins.DB.Recipes.Remove(tempRecipe);
                var tempStepRecipe = DataProvider.Ins.DB.StepRecipes.Where(p => p.IdRecipe == DataTemp.Ins.tempRecipe.Id);
                foreach (var item in tempStepRecipe)
                {
                    DataProvider.Ins.DB.StepRecipes.Remove(item);
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadRecipe();
            }
        }

        private void btnTestCook_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Choose the Recipe first", "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //portBep.Open();
                //portRobot.Open();
                if (portBep.IsOpen)
                {
                    cookerStatus = true;
                }
                else if (portBep.IsOpen == false)
                {
                    string MessageBoxAlertBep = "Cooker Port is closed.\nPlease check the connection again!";
                    MessageBox.Show(MessageBoxAlertBep, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cookerStatus = false;
                }

                if (cookerStatus == true)
                {
                    //Check ket noi voi Robot
                    if (portRobot.IsOpen)
                    {
                        robotStatus = true;
                    }
                    else
                    {
                        string MessageBoxAlertRobot = "Robot Port is closed.\nPlease check the connection again!";
                        MessageBox.Show(MessageBoxAlertRobot, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                if ((robotStatus && cookerStatus) == true)
                {
                    string ten_mon = SelectedItem.DisplayName;
                    Window wd = new wdTestCook(ten_mon);
                    wd.ShowDialog();
                }
            }
            
        }

        //--------------------------------------------------------------------
        //Phần này phục vụ cho việc truyền khung dữ liệu cho các bếp về sau
        public byte[] dataFrame1 = new byte[180];
        public byte[] dataFrame2 = new byte[180];
        public byte[] dataFrame3 = new byte[180];
        public byte[] dataFrame4 = new byte[180];
        private void btnCook_1(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) { MessageBox.Show("Choose the Recipe first!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning); }
            else
            {
                int indexAction1 = 0;
                convertTohex(ref dataFrame1, ref indexAction1);
            } 
        }
        private void btnCook_2(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) { MessageBox.Show("Choose the Recipe first!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning); }
            else
            {
                int indexAction2 = 0;
                convertTohex(ref dataFrame2, ref indexAction2);
            }    
        }

        private void btnCook_3(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) { MessageBox.Show("Choose the Recipe first!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning); }
            else
            {
                int indexAction3 = 0;
                convertTohex(ref dataFrame3, ref indexAction3);
            }
        }

        private void btnCook_4(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null) { MessageBox.Show("Choose the Recipe first!", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning); }
            else
            {
                int indexAction4 = 0;
                convertTohex(ref dataFrame4, ref indexAction4);
            }
        }
        private void btnCook_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedItem == null)
            {

            }
            Window wd = new Monitor(/*SelectedItem.DisplayName*/  dataFrame1, dataFrame2, dataFrame3, dataFrame4);
            wd.ShowDialog();
        }
        //-------------------------------------------

        private void convertTohex(ref byte[] dataframe, ref int IndexAction)
        {
            int i = 0, temp1;
            byte hex_name = 0;
            string temp2;
            string StepName;
            string ParamName;
       
            var tempRecipe = DataProvider.Ins.DB.Recipes.Where(p => p.DisplayName == SelectedItem.DisplayName).SingleOrDefault();
            var tempStepRecipe = DataProvider.Ins.DB.StepRecipes.Where(p => p.IdRecipe == tempRecipe.Id);
        
            foreach (var item in tempStepRecipe)
            {
                StepName = item.DisplayName.ToString();
                ParamName = item.C_Param.ToString();
                /* Sau firstcheck va thirdcheck thi co indexaction va hex_name*/
                firstcheck(ref IndexAction, StepName);
                thirdCheck(ref IndexAction, StepName, ParamName, out hex_name);

                if (IndexAction == 0)
                {
                    dataframe[i] = hex_name;
                    temp2 = (string)item.C_Param;
                    temp1 = int.Parse(temp2);
                    convertTobyte(ref dataframe[i + 1], ref dataframe[i + 2], temp1);
                    dataframe[i + 3] = (byte)item.C_Temp;
                    convertTime(ref dataframe[i + 4], ref dataframe[i + 5], (int)item.C_Hours, (int)item.C_Minutes, (int)item.C_Seconds);
                }
                else
                {
                    dataframe[i] = hex_name;
                    convertTobyte(ref dataframe[i + 1], ref dataframe[i + 2], 0);
                    dataframe[i + 3] = (byte)item.C_Temp;
                    convertTime(ref dataframe[i + 4], ref dataframe[i + 5], (int)item.C_Hours, (int)item.C_Minutes, (int)item.C_Seconds);
                }
                IndexAction = 0;
                i += 6;
            }
        }

        private void convertTobyte(ref byte a, ref byte b, int c)
        {
            if ((c > 255) && (c <= 511))
            {
                a = 1;
                b = (byte)c;
            }
            else if ((c > 511) && (c <= 1023))
            {
                a = 3;
                b = (byte)c;
            }
            else if ((c >= 0) && (c <= 255))
            {
                a = 0;
                b = (byte)c;
            }
        }

        private void convertTime(ref byte a, ref byte b, int c, int d, int e)
        {
            int x;
            x = 3600 * c + 60 * d + e;
            convertTobyte(ref a, ref b, x);
        }
        private void firstcheck(ref int index, string name) //Check tên của bước nấu
        {

            switch (name)
            {
                case ("Đóng nắp"):
                    {
                        index = 1;
                        break;
                    }
                case ("Mở nắp"):
                    {
                        index = 2;
                        break;
                    }
                case ("Thêm hộp 1"):
                    {
                        index = 3;
                        break;
                    }
                case ("Thêm hộp 2"):
                    {
                        index = 4;
                        break;
                    }
                case ("Thêm hộp 3"):
                    {
                        index = 5;
                        break;
                    }
                case ("Thêm hộp 4"):
                    {
                        index = 6;
                        break;
                    }
                case ("Dừng nấu"):
                    {
                        index = 7;
                        break;
                    }
            }
        }
        private void secondCheck(string name, out byte hex_name)
        {
            hex_name = 0;
            List<string> list;
            list = new List<string>() { "Thêm nước", "Thêm xốt đặc", "Thêm canh", "Thêm nước súp", "Thêm mắm", "Thêm dầu" };
            byte i = 0;
            foreach (string item in list)
            {
                if (item == name) { hex_name = i; break; }
                else { i++; }
            }
        }

        private void thirdCheck(ref int index, string name1, string name2, out byte hex_name) //Check các option của các bước công thức rồi gán một mã hex tương ứng
        {
            hex_name = 0;
            byte i;
            List<string> list1;
            List<string> list2;
            List<string> list3;
            list1 = new List<string>() { "Đóng xong đảo nhanh", "Đóng xong đảo chậm", "Đóng xong đảo vừa", "Đóng xong không đảo", "Đóng xong đảo xoay chiều nhanh", "Đóng xong đảo xoay chiều chậm", "Đóng xong đảo xoay chiều vừa", };
            list2 = new List<string>() { "Mở hé một nửa", "Mở tốc độ chậm", "Mở chế độ chống bắn dính" };
            list3 = new List<string>() { "Đổ nhanh", "Đổ chậm", "Đổ vào xong lắc", "Lắc xong đổ vào" };
            switch (index)
            {
                case (0):
                    {
                        secondCheck(name1, out hex_name);
                        break;
                    }
                case (1):
                    {
                        i = 16;
                        foreach (string item in list1)
                        {
                            if (item == name2) { hex_name = i; break; }
                            else { i++; }
                        }
                        break;
                    }
                case (2):
                    {
                        i = 32;
                        foreach (string item in list2)
                        {
                            if (item == name2) { hex_name = i; break; }
                            else { i++; }
                        }
                        break;
                    }
                case (3):
                    {
                        i = 48;
                        foreach (string item in list3)
                        {
                            if (item == name2) { hex_name = i; break; }
                            else { i++; }
                        }
                        break;
                    }
                case (4):
                    {
                        i = 64;
                        foreach (string item in list3)
                        {
                            if (item == name2) { hex_name = i; break; }
                            else { i++; }
                        }
                        break;
                    }
                case (5):
                    {
                        i = 80;
                        foreach (string item in list3)
                        {
                            if (item == name2) { hex_name = i; break; }
                            else { i++; }
                        }
                        break;
                    }
                case (6):
                    {
                        i = 96;
                        foreach (string item in list3)
                        {
                            if (item == name2) { hex_name = i; break; }
                            else { i++; }
                        }
                        break;
                    }
                case (7):
                    {
                        hex_name = 112;
                        break;
                    }
            }

        }

        private void DragMoveWindow_event(object sender, MouseButtonEventArgs e)
        {
            wRecipeOverview.DragMove();
        }

        private void ColorZone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (wRecipeOverview.WindowState == WindowState.Normal) wRecipeOverview.WindowState = WindowState.Maximized;
            else wRecipeOverview.WindowState = WindowState.Normal;
        }

    }
    public class RecipeModel
        {
            private int sTT;
            public int STT { get => sTT; set { sTT = value; OnPropertyChanged("STT"); } }
            private string displayName;
            public string DisplayName { get => displayName; set { displayName = value; OnPropertyChanged("DisplayName"); } }
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

}
