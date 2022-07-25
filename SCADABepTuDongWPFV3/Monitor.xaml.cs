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
using System.IO.Ports;
using System.Threading;

namespace SCADABepTuDongWPFV3
{
    public partial class Monitor : Window
    {
        //public string nameRecipe;
        public byte[] frame1;
        public byte[] frame2;
        public byte[] frame3;
        public byte[] frame4;
        public Monitor(/*string tempNameRecipe*/ byte[] TempFrame1, byte[] TempFrame2, byte[] TempFrame3, byte[] TempFrame4)
        {
            //nameRecipe = tempNameRecipe;
            frame1 = TempFrame1;
            frame2 = TempFrame2;
            frame3 = TempFrame3;
            frame4 = TempFrame4;
            InitializeComponent();
        }

        
        private void DragMoveWindow_event(object sender, MouseButtonEventArgs e)
        {
            wSendRTU.DragMove();
        }
        private void ColorZone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (wSendRTU.WindowState == WindowState.Normal) wSendRTU.WindowState = WindowState.Maximized;
            else wSendRTU.WindowState = WindowState.Normal;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            serialPortBep.Close();
            serialPortRobot.Close();
            this.Close();
        }
      
        private static SerialPort serialPortBep = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
        private static SerialPort serialPortRobot = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);



        //public byte[] dataframe = new byte[180];
        private void btnSendRTU_Click(object sender, RoutedEventArgs e)
        {
            //Check ket noi voi Bep
            if (serialPortBep.IsOpen)
            {
                serialPortBep.Close();
                serialPortBep.Open();
                Thread.Sleep(100);
            }
            else if (serialPortBep.IsOpen == false)
            {
                string MessageBoxAlertBep = "Cooker Port is closed.\nPlease check the connection again!";
                MessageBox.Show(MessageBoxAlertBep, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            //Check ket noi voi Robot
            if (serialPortRobot.IsOpen)
            {
                serialPortRobot.Close();
                serialPortRobot.Open();
                Thread.Sleep(100);
            }
            else
            {
                string MessageBoxAlertRobot = "Robot Port is closed.\nPlease check the connection again!";
                MessageBox.Show(MessageBoxAlertRobot, "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (serialPortBep.IsOpen && serialPortRobot.IsOpen)
            {
                //byte[] dataframe = new byte[180];
                //int IndexAction = 0;
                //convertTohex(ref dataframe, ref IndexAction);
                byte[] frame11 = WriteMultipleRegistersFrame(1, 16, 0, 90, frame1);
                serialPortBep.Write(frame11, 0, frame11.Length);
                Thread.Sleep(100);
                byte[] frame22 = WriteMultipleRegistersFrame(2, 16, 0, 90, frame2);
                serialPortBep.Write(frame22, 0, frame22.Length);
                Thread.Sleep(100);
                //byte[] frame33 = WriteMultipleRegistersFrame(2, 16, 0, 90, frame3);
                //serialPort.Write(frame33, 0, frame33.Length);
                //Thread.Sleep(100);
                //byte[] frame44 = WriteMultipleRegistersFrame(2, 16, 0, 90, frame4);
                //serialPort.Write(frame44, 0, frame44.Length);
                //Thread.Sleep(100);

                byte[] data1 = new byte[5];
                byte[] data2 = new byte[5];
                byte[] data3 = new byte[5];
                byte[] data4 = new byte[5];
                Thread t1 = new Thread(() =>
                {
                    while (true)
                    {
                        ReadRegisters(1, 3, 5, 2, out data1);
                        ShowContent(data1, txtReceiveMessage1);
                        ReadRegisters(2, 3, 5, 2, out data2);
                        ShowContent(data2, txtReceiveMessage2);
                        ReadRegisters(3, 3, 5, 2, out data3);
                        ShowContent(data3, txtReceiveMessage3);
                        ReadRegisters(4, 3, 5, 2, out data4);
                        ShowContent(data4, txtReceiveMessage4);
                        Thread.Sleep(1000);
                        ClearContent(txtReceiveMessage1);
                        ClearContent(txtReceiveMessage2);
                        ClearContent(txtReceiveMessage3);
                        ClearContent(txtReceiveMessage4);
                    }

                });
                t1.Start();
            }
        }

   

        //---------------------------------------------------------
        private byte[] WriteMultipleRegistersFrame(byte slaveID, byte functionCode, ushort startAddress, ushort numberOfRegisters, byte[] data)
        {
            byte[] frame = new byte[9 + data.Length];
            frame[0] = slaveID;
            frame[1] = functionCode;
            frame[2] = (byte)(startAddress >> 8);
            frame[3] = (byte)startAddress;
            frame[4] = (byte)(numberOfRegisters >> 8);
            frame[5] = (byte)numberOfRegisters;
            frame[6] = Convert.ToByte(data.Length);
            Array.Copy(data, 0, frame, 7, data.Length);
            byte[] CRC = CRCCalculation(frame);
            frame[frame.Length - 2] = CRC[0];
            frame[frame.Length - 1] = CRC[1];
            return frame;
        }

        public void WriteMultipleRegisters(byte slaveID, ushort startAddress, ushort numberOfRegisters, ushort value)
        {
            const byte function = 16;
            byte[] data = BitConverter.GetBytes(value);
            Array.Reverse(data);
            byte[] frame = WriteMultipleRegistersFrame(slaveID, function, startAddress, numberOfRegisters, data);
            serialPortBep.Write(frame, 0, frame.Length);
            
        }


        //------------------------------------------------------------------
        public void ReadRegisters(byte slaveAddress, byte function, ushort startAddress, uint NumberOfPoints, out byte[] data)
        {
            data = new byte[5];
    
          
            if (serialPortBep.IsOpen)
            {
                byte[] frame = ReadHoldingRegistersMsg(slaveAddress, startAddress, function, NumberOfPoints);
                serialPortBep.Write(frame, 0, frame.Length);
                Thread.Sleep(100); // Delay 100ms

                if (serialPortBep.BytesToRead >= 5)
                {
                    byte[] bufferReceiver = new byte[serialPortBep.BytesToRead];
                    serialPortBep.Read(bufferReceiver, 0, serialPortBep.BytesToRead);
                    serialPortBep.DiscardInBuffer();

                    // Process data.
                    data = new byte[bufferReceiver.Length - 5];
                    Array.Copy(bufferReceiver, 3, data, 0, data.Length);
                    //for (int i = 0; i < data.Length; i++)
                    //{
                    //    string str = Convert.ToString(data[i], 16);
                    //    this.Dispatcher.Invoke((Action)(() =>
                    //    {//this refer to form in WPF application 
                    //        txtReceiveMessage1.AppendText(" " + str);
                    //    }));                          
                    //}
                }

             }
            //Thread.Sleep(2000); // Delay 20ms
            //this.Dispatcher.Invoke((Action)(() =>
            //{//this refer to form in WPF application 
            //    txtReceiveMessage1.Clear();
            //}));
      
        }
        public void ShowContent(byte[] data, TextBox txt)
        {
            
            for (int i = 0; i < data.Length; i++)
            {
                string str = Convert.ToString(data[i], 16);
                this.Dispatcher.Invoke((Action)(() =>
                {//this refer to form in WPF application 
                    txt.AppendText(" " + str);
                }));
                
            }
        }
        public void ClearContent(TextBox txt)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {//this refer to form in WPF application 
                txt.Clear();
                
            }));
        }
  

        private byte[] ReadHoldingRegistersMsg(byte slaveAddress, ushort startAddress, byte function, uint numberOfPoints)
        {
            byte[] frame = new byte[8];
            frame[0] = slaveAddress;                // Slave Address
            frame[1] = function;                    // Function             
            frame[2] = (byte)(startAddress >> 8);   // Starting Address High
            frame[3] = (byte)startAddress;          // Starting Address Low            
            frame[4] = (byte)(numberOfPoints >> 8); // Quantity of Registers High
            frame[5] = (byte)numberOfPoints;        // Quantity of Registers Low
            byte[] crc = CRCCalculation(frame);     // Calculate CRC.
            frame[frame.Length - 2] = crc[0];       // Error Check Low
            frame[frame.Length - 1] = crc[1];       // Error Check High
            return frame;
        }
    
        private byte[] CRCCalculation(byte[] frame)
        {
            byte[] result = new byte[2];
            ushort CRCFull = 0xFFFF;
            char CRCLSB;
            for (int i = 0; i < frame.Length - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ frame[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                    {
                        CRCFull = (ushort)(CRCFull ^ 0xA001);

                    }
                }
            }
            result[1] = (byte)((CRCFull >> 8) & 0xFF);
            result[0] = (byte)((CRCFull & 0xFF));
            return result;
        }


        //--------------------------------
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {           
            if (serialPortBep.BytesToRead >= 5)
            {
                byte[] bufferReceiver = new byte[serialPortBep.BytesToRead];
                serialPortBep.Read(bufferReceiver, 0, serialPortBep.BytesToRead);
                serialPortBep.DiscardInBuffer();

                // Process data.
                byte[] data = new byte[bufferReceiver.Length - 5];
                Array.Copy(bufferReceiver, 3, data, 0, data.Length);
                for (int i = 0; i < data.Length; i++)
                {
                    string str = Convert.ToString(data[i], 16);
                    txtReceiveMessage1.AppendText(" " + str);
                }
            }

        }

        private void txtReceiveMessage1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
