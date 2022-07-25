using SCADABepTuDongWPFV3.Model;
using System;
using System.Collections.Generic;
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

namespace SCADABepTuDongWPFV3
{
    /// <summary>
    /// Interaction logic for wdSettingRecipe.xaml
    /// </summary>
    public partial class wdSettingRecipe : Window, INotifyPropertyChanged
    {
        List<ComboBox> cbSteps;
        List<string> ListIngre = new List<string>();
        List<string> ListUnit = new List<string>();
        public string NameRecipe = "";
        int TotalStep = 0;
        int TotalStepOriginal = 0;
        bool IsLoaded = false;
        bool isCreateNewRecipe = false;
        int NumberStep = -1;

        public wdSettingRecipe(bool tempIsCreateNewRecipe, string tempNameRecipe)
        {
            InitializeComponent();
            this.DataContext = this;
            cbSteps = new List<ComboBox>() { cbStep1, cbStep2, cbStep3, cbStep4, cbStep5, cbStep6, cbStep7, cbStep8, cbStep9, cbStep10, cbStep11, cbStep12, cbStep13, cbStep14, cbStep15
                                            , cbStep16, cbStep17, cbStep18, cbStep19, cbStep20, cbStep21, cbStep22, cbStep23, cbStep24, cbStep25, cbStep26, cbStep27, cbStep28, cbStep29, cbStep30};
            List<string> listRe;
            listRe = new List<string>() {"Gia nhiệt", "Thêm nước","Thêm xốt đặc", "Thêm canh", "Thêm nước súp", "Thêm mắm", "Thêm dầu", "Đóng nắp", "Mở nắp", "Thêm hộp 1", "Thêm hộp 2", "Thêm hộp 3", "Thêm hộp 4", "Mở nắp và thêm hộp 1", "Mở nắp và thêm hộp 2", "Mở nắp và thêm hộp 3", "Mở nắp và thêm hộp 4", "Mở nắp và thêm hộp 5", "Dừng nấu" };

            for (int i = 0; i < 30; i++)
            {
                cbSteps[i].ItemsSource = listRe;
            }
            isCreateNewRecipe = tempIsCreateNewRecipe;

            var tempIngredientList = DataProvider.Ins.DB.Ingredients.ToList();
            foreach (var item in tempIngredientList)
            {
                ListIngre.Add(item.DisplayName);
                ListUnit.Add(item.Unit);
            }
            cbBox4.ItemsSource = cbBox3.ItemsSource = cbBox2.ItemsSource = cbBox1.ItemsSource = ListIngre;
            if (isCreateNewRecipe)
            {
                lbTitle.Content = "CREATE RECIPE";
            }
            else
            {
                lbTitle.Content = "EDIT RECIPE";
                NameRecipe = tempNameRecipe;
                LoadRecipe(NameRecipe);
            }

        }
        private void LoadRecipe(string name)
        {
            DataTemp.Ins.tempRecipe = DataProvider.Ins.DB.Recipes.Where(p => p.DisplayName == name).First();
            txtNameRecipe.Text = DataTemp.Ins.tempRecipe.DisplayName;
            txtDescribe.Text = DataTemp.Ins.tempRecipe.Describe;
            cbBox1.SelectedItem = DataTemp.Ins.tempRecipe.Box1;
            cbBox2.SelectedItem = DataTemp.Ins.tempRecipe.Box2;
            cbBox3.SelectedItem = DataTemp.Ins.tempRecipe.Box3;
            cbBox4.SelectedItem = DataTemp.Ins.tempRecipe.Box4;
            //cbUnit1.SelectedItem = DataTemp.Ins.tempRecipe.unit11;
            //cbUnit2.SelectedItem = DataTemp.Ins.tempRecipe.unit22;
            //cbUnit3.SelectedItem = DataTemp.Ins.tempRecipe.unit33;
            //cbUnit4.SelectedItem = DataTemp.Ins.tempRecipe.unit44;
            txtUnit1.Text = DataTemp.Ins.tempRecipe.Unit1;
            txtUnit2.Text = DataTemp.Ins.tempRecipe.Unit2;
            txtUnit3.Text = DataTemp.Ins.tempRecipe.Unit3;
            txtUnit4.Text = DataTemp.Ins.tempRecipe.Unit4;
            int i = 1;
            var StepRecipeList = DataProvider.Ins.DB.StepRecipes.Where(p => p.IdRecipe == DataTemp.Ins.tempRecipe.Id);
            foreach (var item in StepRecipeList)
            {
                DataTemp.Ins.tempStepRecipe.Add(item);
                var tempStepRecipe = StepRecipeList.Where(p => p.NumberStep == i).First();
                cbSteps[(int)tempStepRecipe.NumberStep - 1].SelectedItem = tempStepRecipe.DisplayName;
                cbSteps[(int)tempStepRecipe.NumberStep - 1].Visibility = Visibility.Visible;
                TotalStep = i;
                TotalStepOriginal = i;
                i++;
            }
            IsLoaded = true;
        }

        
        private void btnAddProgram_Click(object sender, RoutedEventArgs e)
        {
            if (TotalStep < cbSteps.Count)
            {
                cbSteps[TotalStep].Visibility = Visibility.Visible;
                TotalStep++;
                scrbar.ScrollToEnd();
            }
        }

        private void btnDelProgram_Click(object sender, RoutedEventArgs e)
        {
            if (TotalStep > 0)
            {
                TotalStep--;
                cbSteps[TotalStep].Visibility = Visibility.Collapsed;
                scrbar.ScrollToEnd();
            }
        }

        private void cbSteps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded || isCreateNewRecipe)
            {
                int tempNumberStep = -1;
                for (int i = 0; i < cbSteps.Count; i++)
                {
                    if (cbSteps[i].IsDropDownOpen)
                    {
                        tempNumberStep = i + 1;
                        break;
                    }
                }
                NumberStep = tempNumberStep;
                Window wd = new wdStepRecipeInfo(SelectedItem, NumberStep, isCreateNewRecipe, TotalStepOriginal);
                wd.ShowDialog();
                btnSave.Focus();

                if (wd.DialogResult == false)
                {
                    cbSteps[tempNumberStep - 1].SelectedIndex = -1;
                }
            }
        }

        private void cbSteps_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int tempNumberStep = -1;
            for (int i = 0; i < cbSteps.Count; i++)
            {
                if (cbSteps[i].IsFocused)
                {
                    tempNumberStep = i + 1;
                    if (cbSteps[i].SelectedItem != null)
                    {
                        SelectedItem = cbSteps[i].SelectedItem.ToString();
                        break;
                    }
                }
            }
            if (cbSteps[tempNumberStep - 1].SelectedItem != null)
            {
                NumberStep = tempNumberStep;
                Window wd = new wdStepRecipeInfo(SelectedItem, NumberStep, isCreateNewRecipe, TotalStepOriginal);
                wd.ShowDialog();
            }
            btnSave.Focus();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //-------------------------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(isCreateNewRecipe)
            {
                if(IsRecipeExist())
                {
                    Add();
                    this.Close();
                }
            }
            else {
                Edit();
                this.Close();
            }
        }
        private bool IsRecipeExist()
        {
            string tempMessageBoxEn = "This Recipe was loaded";
            if (DataProvider.Ins.DB.Recipes.Where(x => x.DisplayName == txtNameRecipe.Text).Count() == 0)
                return true;
            else
            {
                MessageBox.Show(tempMessageBoxEn, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        //--------------------------------------------------------------
       
        private void Add()
        {
            string RecipeName = txtNameRecipe.Text;
            RecipeName = RecipeName.Trim();
            while (RecipeName.IndexOf("  ") != -1)
            {
                RecipeName = RecipeName.Replace("  ", " ");
            }
            string Describe = txtDescribe.Text;
            Describe = Describe.Trim();
            while (Describe.IndexOf("  ") != -1)
            {
                Describe = Describe.Replace("  ", " ");
            }
            DataTemp.Ins.tempRecipe.DisplayName = RecipeName.ToUpper();
            DataTemp.Ins.tempRecipe.Describe = Describe;
            if (cbBox1.SelectedItem != null) DataTemp.Ins.tempRecipe.Box1 = cbBox1.SelectedItem.ToString();
            if (cbBox2.SelectedItem != null) DataTemp.Ins.tempRecipe.Box2 = cbBox2.SelectedItem.ToString();
            if (cbBox3.SelectedItem != null) DataTemp.Ins.tempRecipe.Box3 = cbBox3.SelectedItem.ToString();
            if (cbBox4.SelectedItem != null) DataTemp.Ins.tempRecipe.Box4 = cbBox4.SelectedItem.ToString();
            DataTemp.Ins.tempRecipe.Unit1 = txtUnit1.Text;
            DataTemp.Ins.tempRecipe.Unit2 = txtUnit2.Text;
            DataTemp.Ins.tempRecipe.Unit3 = txtUnit3.Text;
            DataTemp.Ins.tempRecipe.Unit4 = txtUnit4.Text;
            var Recipes = DataTemp.Ins.tempRecipe;
            DataProvider.Ins.DB.Recipes.Add(Recipes);
            DataProvider.Ins.DB.SaveChanges();

            DataTemp.Ins.tempRecipe = DataProvider.Ins.DB.Recipes.Where(p => p.DisplayName == DataTemp.Ins.tempRecipe.DisplayName).SingleOrDefault();
            foreach (var item in DataTemp.Ins.tempStepRecipe)
            {
                item.IdRecipe = DataTemp.Ins.tempRecipe.Id;
                DataProvider.Ins.DB.StepRecipes.Add(item);
            }
            DataProvider.Ins.DB.SaveChanges();
        }

        //--------------------------------------------------
        private void Delete()
        {
            var Recipe = DataProvider.Ins.DB.Recipes.Where(p => p.DisplayName == NameRecipe).SingleOrDefault();
            DataProvider.Ins.DB.Recipes.Remove(Recipe);
            var StepRecipeList = DataProvider.Ins.DB.StepRecipes.Where(p => p.IdRecipe == DataTemp.Ins.tempRecipe.Id);
            foreach (var item in StepRecipeList)
            {
                DataProvider.Ins.DB.StepRecipes.Remove(item);
            }
            DataProvider.Ins.DB.SaveChanges();
        }

        //-----------------------------------------------
        private void Edit()
        {
            Delete();
            Add();
        }

        //----------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //------------------------------------------------
        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void DragMoveWindow_event(object sender, MouseButtonEventArgs e)
        {
            wSettingRecipe.DragMove();
        }

        private void ColorZone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (wSettingRecipe.WindowState == WindowState.Normal) wSettingRecipe.WindowState = WindowState.Maximized;
            else wSettingRecipe.WindowState = WindowState.Normal;
        }

        
    }
}
