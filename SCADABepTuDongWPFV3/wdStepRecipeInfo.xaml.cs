using SCADABepTuDongWPFV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SCADABepTuDongWPFV3
{
    /// <summary>
    /// Interaction logic for wdStepRecipeInfo.xaml
    /// </summary>
    public partial class wdStepRecipeInfo : Window
    {
        public wdStepRecipeInfo(string tempAction, int tempNumberStep, bool tempIsCreateNew, int tempTotalStepOriginal)
        {
            InitializeComponent();
            NameAction = tempAction;
            TotalStepOriginal = tempTotalStepOriginal;
            NumberStep = tempNumberStep;
            IsCreateNew = tempIsCreateNew;
            //IdRecipe = tempIdRecipe;
            //IdStepRecipe = tempIdStepRecipe;
            lbTitle.Content = "Step " + NumberStep + ": " + NameAction;
            FirstCheck();
            if (!IsCreateNew && DataTemp.Ins.tempStepRecipe.Count > NumberStep) LoadStepRecipe();

            // SettingRecipeTemp.Ins.Name
            List<string> list1;
            List<string> list2;
            List<string> list3;
            list1 = new List<string>() {"Đóng xong đảo nhanh", "Đóng xong đảo chậm", "Đóng xong đảo vừa", "Đóng xong không đảo", "Đóng xong đảo xoay chiều nhanh", "Đóng xong đảo xoay chiều chậm", "Đóng xong đảo xoay chiều vừa", };
            list2 = new List<string>() { "Mở hé một nửa", "Mở tốc độ chậm", "Mở chế độ chống bắn dính"};
            list3 = new List<string>() { "Đổ nhanh", "Đổ chậm", "Đổ vào xong lắc", "Lắc xong đổ vào" };
     
            cbParamCloseLid.ItemsSource = list1;
            cbParamOpenLid.ItemsSource = list2;
            cbParamAddBox.ItemsSource = list3;

        }
        private wdSettingRecipe wdParent;

        private string NameAction;
        private int IndexAction = -1;
        private int NumberStep;
        //private int IdRecipe;
        private int IdStepRecipe;
        private bool IsCreateNew = false;
        private int TotalStepOriginal = -1;
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {

            if (IsCreateNew && DataTemp.Ins.tempStepRecipe.Count < NumberStep)
            {
                Add();
            }
            else if (DataTemp.Ins.tempStepRecipe.Count < NumberStep)
            {
                Add();
            }
            else Edit(); 
            this.DialogResult = true;
            this.Close();
        }

        private void LoadStepRecipe()
        {
            if (NumberStep > 0)
            {
                switch (IndexAction)
                {
                    case (0):   
                        {
                            txtParam.Text = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param;
                            break;
                        }
                    case (1):   
                        {
                            cbParamCloseLid.SelectedItem = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param;
                            break;
                        }
                    case (2):  
                        {
                            cbParamOpenLid.SelectedItem = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param;
                            break;
                        }
                    case (3):   
                        {
                            cbParamAddBox.SelectedItem = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param;
                            break;
                        }
                }
                txtNhietDo.Text = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Temp.ToString();
                //cbHour.SelectedItem = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Hours.ToString();
                //cbMinute.SelectedItem = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Minutes.ToString();
                //cbSecond.SelectedItem = DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Seconds.ToString();

                cbHour.SelectedIndex = (int)DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Hours;
                cbMinute.SelectedItem = (int)DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Minutes;
                cbSecond.SelectedItem = (int)DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Seconds;
            }
        }

        private void Add()
        {
            //Add StepRecipeInfo
            string tempParam = "";
            switch (IndexAction)
            {
                case (0):   
                    {
                        tempParam = txtParam.Text;
                        break;
                    }
                case (1):   
                    {
                        tempParam = cbParamCloseLid.SelectedItem.ToString();
                        break;
                    }
                case (2):  
                    {
                        tempParam = cbParamOpenLid.SelectedItem.ToString();
                        break;
                    }
                case (3):   
                    {
                        tempParam = cbParamAddBox.SelectedItem.ToString();
                        break;
                    }
            }
            DataTemp.Ins.tempStepRecipe.Add(new StepRecipe()
            {
                IdRecipe = 123,
                NumberStep = NumberStep,
                DisplayName = NameAction,
                C_Param = tempParam,
                C_Temp = int.Parse(txtNhietDo.Text),
                C_Hours = int.Parse(cbHour.SelectedItem.ToString()),
                C_Minutes = int.Parse(cbMinute.SelectedItem.ToString()),
                C_Seconds = int.Parse(cbSecond.SelectedItem.ToString())
            }); ;
        }

        private void Edit()
        {
            if (NumberStep > 0)
            {
                DataTemp.Ins.tempStepRecipe[NumberStep - 1].DisplayName = NameAction;
                switch (IndexAction)
                {
                    case (0):   
                        {
                            DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param = txtParam.Text;
                            break;
                        }
                    case (1):   
                        {
                            DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param = cbParamCloseLid.SelectedItem.ToString();
                            break;
                        }
                    case (2):   
                        {
                            DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param = cbParamOpenLid.SelectedItem.ToString();
                            break;
                        }
                    case (3):  
                        {
                            DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Param = cbParamAddBox.SelectedItem.ToString();
                            break;
                        }
                }
                DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Temp = int.Parse(txtNhietDo.Text);
                DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Hours = int.Parse(cbHour.SelectedIndex.ToString());
                DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Minutes = int.Parse(cbMinute.SelectedItem.ToString());
                DataTemp.Ins.tempStepRecipe[NumberStep - 1].C_Seconds = int.Parse(cbSecond.SelectedItem.ToString());
            }
        }

        private void FirstCheck()
        {
            switch (NameAction)
            {
                case ("Thêm nước"):
                    {
                        IndexAction = 0;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Visible;
                        GridTemp.Visibility = Visibility.Visible;
                        GridTime.Visibility = Visibility.Visible;
                        break;
                    }
                case ("Thêm xốt đặc"):
                    {
                        IndexAction = 0;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Visible;
                        GridTemp.Visibility = Visibility.Visible;
                        GridTime.Visibility = Visibility.Visible;
                        break;
                    }
                case ("Thêm canh"):
                    {
                        IndexAction = 0;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Visible;
                        GridTemp.Visibility = Visibility.Visible;
                        GridTime.Visibility = Visibility.Visible;
                        break;
                    }
                case ("Thêm nước súp"):
                    {
                        IndexAction = 0;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Visible;
                        GridTemp.Visibility = Visibility.Visible;
                        GridTime.Visibility = Visibility.Visible;
                        break;
                    }
                case ("Thêm mắm"):
                    {
                        IndexAction = 0;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Visible;
                        GridTemp.Visibility = Visibility.Visible;
                        GridTime.Visibility = Visibility.Visible;
                        break;
                    }
                case ("Thêm dầu"):
                    {
                        IndexAction = 0;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Visible;
                        GridTemp.Visibility = Visibility.Visible;
                        GridTime.Visibility = Visibility.Visible;
                        break;
                    }
                case ("Đóng nắp"):
                    {
                        IndexAction = 1;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Visible;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Collapsed;
                        GridTemp.Visibility = Visibility.Visible;
                        GridTime.Visibility = Visibility.Visible;
                        break;
                    }
                case ("Mở nắp"):
                    {
                        IndexAction = 2;
                        cbParamAddBox.Visibility = Visibility.Collapsed;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Visible;
                        txtParam.Visibility = Visibility.Collapsed;
                        GridTemp.Visibility = Visibility.Collapsed;
                        GridTime.Visibility = Visibility.Collapsed;
                        break;
                    }
                case ("Thêm hộp 1"):
                    {
                        IndexAction = 3;
                        cbParamAddBox.Visibility = Visibility.Visible;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Collapsed;
                        GridTemp.Visibility = Visibility.Collapsed;
                        GridTime.Visibility = Visibility.Collapsed;
                        break;
                    }
                case ("Thêm hộp 2"):
                    {
                        IndexAction = 3;
                        cbParamAddBox.Visibility = Visibility.Visible;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Collapsed;
                        GridTemp.Visibility = Visibility.Collapsed;
                        GridTime.Visibility = Visibility.Collapsed;
                        break;
                    }
                case ("Thêm hộp 3"):
                    {
                        IndexAction = 3;
                        cbParamAddBox.Visibility = Visibility.Visible;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Collapsed;
                        GridTemp.Visibility = Visibility.Collapsed;
                        GridTime.Visibility = Visibility.Collapsed;
                        break;
                    }
                case ("Thêm hộp 4"):
                    {
                        IndexAction = 3;
                        cbParamAddBox.Visibility = Visibility.Visible;
                        cbParamCloseLid.Visibility = Visibility.Collapsed;
                        cbParamOpenLid.Visibility = Visibility.Collapsed;
                        txtParam.Visibility = Visibility.Collapsed;
                        GridTemp.Visibility = Visibility.Collapsed;
                        GridTime.Visibility = Visibility.Collapsed;
                        break;
                    }
            }
        }

        private void btnCancal_Click(object sender, RoutedEventArgs e)
        {
            if (IsCreateNew)
            {
                this.DialogResult = false;
            }
            else this.Close();
        }
    }
}
