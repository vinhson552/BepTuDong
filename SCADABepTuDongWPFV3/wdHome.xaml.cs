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
    /// Interaction logic for wdHome.xaml
    /// </summary>
    public partial class wdHome : Window
    {
        public wdHome()
        {
            InitializeComponent();
        }

        private void btnIngredient_Click(object sender, RoutedEventArgs e)
        {
            Window wd = new wdIngredient();
            wd.ShowDialog();
        }
        private void btnRecipeList_Click(object sender, RoutedEventArgs e)
        {

            Window wd = new wdRecipeOverview();
            wd.ShowDialog();
        }
        private void btnReport_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Window wd = new wdLogin();
            wd.Show();
            this.Close();
        }
    }
}
