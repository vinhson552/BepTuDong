﻿#pragma checksum "..\..\ModbusRTU.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7D4C40F03076CC8DF3B3E6E62F3A8D4D44558D6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SCADABepTuDongWPFV3;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SCADABepTuDongWPFV3 {
    
    
    /// <summary>
    /// ModbusRTU
    /// </summary>
    public partial class ModbusRTU : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\ModbusRTU.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSendMessage;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ModbusRTU.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReceiveMessage;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ModbusRTU.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSendMessage;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ModbusRTU.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCOM;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ModbusRTU.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConnect;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\ModbusRTU.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReadMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SCADABepTuDongWPFV3;component/modbusrtu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModbusRTU.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtSendMessage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtReceiveMessage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnSendMessage = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ModbusRTU.xaml"
            this.btnSendMessage.Click += new System.Windows.RoutedEventHandler(this.btnSendMessage_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbCOM = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\ModbusRTU.xaml"
            this.cbCOM.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbCOM_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnConnect = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\ModbusRTU.xaml"
            this.btnConnect.Click += new System.Windows.RoutedEventHandler(this.btnConnect_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnReadMessage = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\ModbusRTU.xaml"
            this.btnReadMessage.Click += new System.Windows.RoutedEventHandler(this.btnReadMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
