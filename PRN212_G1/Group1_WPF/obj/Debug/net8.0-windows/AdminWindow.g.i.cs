﻿#pragma checksum "..\..\..\AdminWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52A9A41B27F8554BEEFEFC24F038040D9D62EE43"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Group1_WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Group1_WPF {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTripButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditTripButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteTripButton;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchLocationTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid LocationsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddLocationButton;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditLocationButton;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteLocationButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Group1_WPF;V1.0.0.0;component/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AddTripButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\AdminWindow.xaml"
            this.AddTripButton.Click += new System.Windows.RoutedEventHandler(this.AddTripButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EditTripButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\AdminWindow.xaml"
            this.EditTripButton.Click += new System.Windows.RoutedEventHandler(this.EditTripButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DeleteTripButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\AdminWindow.xaml"
            this.DeleteTripButton.Click += new System.Windows.RoutedEventHandler(this.DeleteTripButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SearchLocationTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\AdminWindow.xaml"
            this.SearchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LocationsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.AddLocationButton = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\AdminWindow.xaml"
            this.AddLocationButton.Click += new System.Windows.RoutedEventHandler(this.AddLocationButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EditLocationButton = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\AdminWindow.xaml"
            this.EditLocationButton.Click += new System.Windows.RoutedEventHandler(this.EditLocationButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DeleteLocationButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\AdminWindow.xaml"
            this.DeleteLocationButton.Click += new System.Windows.RoutedEventHandler(this.DeleteLocationButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

