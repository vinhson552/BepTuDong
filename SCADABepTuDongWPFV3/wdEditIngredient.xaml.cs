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
    /// <summary>
    /// Interaction logic for wdEditIngredient.xaml
    /// </summary>
    public partial class wdEditIngredient : Window
    {
        List<string> ListUnit = new List<string>();
        public string nameIngre;
        public bool checkIngre = true;

        public wdEditIngredient(string tempIngredientName)
        {
            InitializeComponent();
            var tempIngredientUnit = DataProvider.Ins.DB.IngredientUnits.ToList();
            foreach (var item in tempIngredientUnit)
            {
                ListUnit.Add(item.UnitName);
            }
            cbUnit.ItemsSource = ListUnit;
            this.DataContext = this;
            nameIngre = tempIngredientName;
            loadIngredient(nameIngre);
        }
        //-----------------------------------------------------
        private void loadIngredient(string Name)
        {
            var tempIngre = DataProvider.Ins.DB.Ingredients.Where(p => p.DisplayName == Name).First();
            txtIngreName.Text = tempIngre.DisplayName;
            cbUnit.Text = tempIngre.Unit;
        }
        //-----------------------------------------------------
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string IngredientName = txtIngreName.Text;
            IngredientName = IngredientName.Trim();
            while (IngredientName.IndexOf("  ") != -1)
            {
                IngredientName = IngredientName.Replace("  ", " ");
            }

            if ((txtIngreName.Text == "") && (cbUnit.Text == ""))
            {
                string MessageIngre = "The Ingredient Name and Unit are empty.\nPlease check  again!";
                MessageBox.Show(MessageIngre, "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
                checkIngre = false;
            }
            else if ((cbUnit.Text == "") || (txtIngreName.Text == ""))
            {
                string MessageIngre = "The Ingredient Name box or Ingredient Unit box is emty.\nPlease check again!";
                MessageBox.Show(MessageIngre, "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
                checkIngre = false;
            }
            if (checkIngre)
            {
                if (CheckIngredientExist(IngredientName.ToUpper()))
                {
                    var Ingre = DataProvider.Ins.DB.Ingredients.Where(p => p.DisplayName == nameIngre.ToUpper()).SingleOrDefault();
                    DataProvider.Ins.DB.Ingredients.Remove(Ingre);
                    DataProvider.Ins.DB.SaveChanges();

                    var tempIngre = new Ingredient() { DisplayName = IngredientName.ToUpper(), Unit = cbUnit.Text.ToUpper() };
                    DataProvider.Ins.DB.Ingredients.Add(tempIngre);
                    DataProvider.Ins.DB.SaveChanges();
                    this.Close();
                }
            }
        }
        //--------------------------------------------------------------
        private bool CheckIngredientExist(string DisplayName)
        {
            string tempMessageBoxEn = "This Ingredient was exist.\nTry again with another name.";
            if (DataProvider.Ins.DB.Ingredients.Where(x => x.DisplayName == DisplayName).Count() == 0)
                return true;
            else
            {
                MessageBox.Show(tempMessageBoxEn, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
