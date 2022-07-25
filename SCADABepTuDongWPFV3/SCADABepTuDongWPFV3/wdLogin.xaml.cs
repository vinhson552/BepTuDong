using MaterialDesignThemes.Wpf;
using SCADABepTuDongWPFV3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for wdLogin.xaml
    /// </summary>
    public partial class wdLogin : Window
    {
        public bool isLogin { get; set; }
        string tempUsername = "";
        string tempPassword = "";

        public wdLogin()
        {
            InitializeComponent();
            isLogin = false;
            this.DataContext = this;
            LoadFirst();
            txtUsername.Focus();
        }
       
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginFunction();
        }

        private void LoginFunction()
        {
            tempUsername = txtUsername.Text;
            tempPassword = txtPassword.Password;
            tempPassword = MD5Hash(Base64Encode(tempPassword));
            var acc = DataProvider.Ins.DB.Users.Where(p => p.UserName == tempUsername && p.Password == tempPassword);
            var accCount = acc.Count();
            if (accCount == 1)
            {
                isRememberMe(txtUsername.Text, txtPassword.Password);
                checkAdmin(acc.Single());
                isLogin = true;
                Window wd = new wdHome();
                wd.Show();
                this.Close();
            }
            else
            {
                isLogin = false;
                string tempMessageBoxEn = "Login Failed.\nYour username or password is incorrect.\nPlease try again.";
                MessageBox.Show(tempMessageBoxEn, "Notification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void checkAdmin(User tempModel)
        {
            int tempIdRole = DataProvider.Ins.DB.UserRoles.Where(x => x.DisplayName == "Admin").Single().Id;
            if (tempModel.IdRole == tempIdRole)
                DataTemp.Ins.IsAdmin = true;
            else DataTemp.Ins.IsAdmin = false;
        }

        private void isRememberMe(string userName, string tempPass)
        {
            if (cRemember.IsChecked == true)
            {
                Properties.Settings.Default.tempUsername = userName;
                Properties.Settings.Default.tempPass = tempPass;
                Properties.Settings.Default.IsRemember = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.tempUsername = "";
                Properties.Settings.Default.tempPass = "";
                Properties.Settings.Default.IsRemember = false;
                Properties.Settings.Default.Save();
            }
        }

        private void LoadFirst()
        {
            if (Properties.Settings.Default.IsRemember == true)
            {
                cRemember.IsChecked = true;
                txtUsername.Text = Properties.Settings.Default.tempUsername;
                txtPassword.Password = Properties.Settings.Default.tempPass;
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string tempMessageBoxEn = "Please contact to administrator to get password again.";
            MessageBox.Show(tempMessageBoxEn, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
