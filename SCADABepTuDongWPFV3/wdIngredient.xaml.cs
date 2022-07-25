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

namespace SCADABepTuDongWPFV3
{
    public partial class wdIngredient : Window
    {
        List<string> ListUnit = new List<string>();
        private List<Ingredient> MyList1 = new List<Ingredient>();
        public bool Check = true;

        public wdIngredient()
        {
            InitializeComponent();
            var tempIngredientUnit = DataProvider.Ins.DB.IngredientUnits.ToList();
            foreach (var item in tempIngredientUnit)
            {
                ListUnit.Add(item.UnitName);
            }
            cbUnit.ItemsSource = ListUnit;
            this.DataContext = this;
            LoadIngredient();
        }
        //-----------------------------------------------------------

        private void LoadIngredient() //Load danh sách NL lên giao diện
        {
            MyList1.Clear();
            var tempIngredient = DataProvider.Ins.DB.Ingredients.ToList();
            //int STT = 1;
            foreach (var item in tempIngredient)
            {
                MyList1.Add(new Ingredient() { DisplayName = item.DisplayName, Unit = item.Unit });
                //STT++;
            }
            lvIngredient.ItemsSource = null;
            lvIngredient.ItemsSource = MyList1;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvIngredient.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("DisplayName", ListSortDirection.Ascending));
        }

        //--------------------------------------------------
        //private void ListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    var tempDisplayName = ((Ingredient)lvNL.SelectedItem).DisplayName;
        //    tempId = ((Ingredient)lvNL.SelectedItem).Id;
        //    if (tempDisplayName != null)
        //    {
        //        txtDisplayName.Text = tempDisplayName;
        //    }
        //}

        //-------------------------------------------------

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {           
            string checkIngre = txtDisplayName.Text;           
            checkIngre = checkIngre.Trim();
            while (checkIngre.IndexOf("  ") != -1)
            {
                checkIngre = checkIngre.Replace("  ", " ");
            }

            //Kiểm tra xem các ô thông tin NL đã được điền đầy đủ hay chưa
            if ((txtDisplayName.Text == "") && (cbUnit.Text == ""))
            {
                string MessageIngre = "The Ingredient Name and Unit are empty.\nPlease check  again!";
                MessageBox.Show(MessageIngre, "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
                Check = false;
            }
            else if ((cbUnit.Text == "") || (txtDisplayName.Text == ""))
            {
                string MessageIngre = "The Ingredient Name box or Ingredient Unit box is emty.\nPlease check again!";
                MessageBox.Show(MessageIngre, "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
                Check = false;
            }

            switch (Check)
            {
                case (false):
                    {
                        txtDisplayName.Text = "";
                        cbUnit.Text = "";
                        break;
                    }
                case (true):
                    {
                        if (CheckIngredientExist(checkIngre.ToUpper()))
                        {
                            var tempIngre = new Ingredient() { DisplayName = checkIngre.ToUpper() , Unit = cbUnit.Text.ToUpper()};
                            DataProvider.Ins.DB.Ingredients.Add(tempIngre);
                            DataProvider.Ins.DB.SaveChanges();
                            MyList1.Add(tempIngre);
                            txtDisplayName.Text = "";
                            cbUnit.Text = "";
                        }
                        break;
                    }
            }
            LoadIngredient();
        }
        private bool CheckIngredientExist(string DisplayName)
        {
            string tempMessageBoxEn = "This Ingredient was exist.\nTry again with another name.";
            if (DataProvider.Ins.DB.Ingredients.Where(x => x.DisplayName == DisplayName).Count() == 0)
                return true;
            else
            {
                MessageBox.Show(tempMessageBoxEn, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtDisplayName.Text = "";
                cbUnit.Text = "";
                return false;
            }
        }
        //------------------------------------------------------------------
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedItem==null)
            {
                MessageBox.Show("Select the ingredient to edit first", "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
            }    
            else
            {
                Window wd = new wdEditIngredient(SelectedItem.DisplayName);
                wd.ShowDialog();
                LoadIngredient();
            }    
         
            //txtDisplayName.Text = SelectedItem.DisplayName;
            //string oldIngre = txtDisplayName.Text;
            //var temp = DataProvider.Ins.DB.Ingredients.Where(p => p.DisplayName == SelectedItem.DisplayName).SingleOrDefault();
            //DataProvider.Ins.DB.Ingredients.Remove(temp);
            //DataProvider.Ins.DB.SaveChanges();
            
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Choose the Ingredient to delete!","Notification",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var tempIngre = DataProvider.Ins.DB.Ingredients.Where(p => p.DisplayName == SelectedItem.DisplayName).SingleOrDefault();
                DataProvider.Ins.DB.Ingredients.Remove(tempIngre);
                DataProvider.Ins.DB.SaveChanges();
                LoadIngredient();
            }

        }
        //--------------------------------------------------------------------------------------
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void DragMoveWindow_event(object sender, MouseButtonEventArgs e)
        {
            wIngredient.DragMove();
        }

        private void ColorZone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (wIngredient.WindowState == WindowState.Normal) wIngredient.WindowState = WindowState.Maximized;
            else wIngredient.WindowState = WindowState.Normal;
        }

        private Ingredient _SelectedItem;
        public Ingredient SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }
        //private int sTT;
        //public int STT { get => sTT; set { sTT = value; OnPropertyChanged("STT"); } }

        private string _DisplayName;
        public string DisplayName
        {
            get => _DisplayName;
            set { _DisplayName = value; OnPropertyChanged("DisplayName"); }
        }

        private string _Unit;
        public string Unit { get => _Unit; set { _Unit = value; OnPropertyChanged("Unit"); } }
        #region
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
