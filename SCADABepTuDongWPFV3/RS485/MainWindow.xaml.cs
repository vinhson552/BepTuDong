
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
using Syst
using System.Threading;

namespace RS485
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static SerialPort serialPort = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort.IsOpen) serialPort.Close();
            serialPort.Open();
        }
    }
}
