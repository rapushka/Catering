﻿#pragma checksum "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FC991EBB9A2EF991DE91459A56CFA7DE6D34B3A5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace CateringCore.Windows.Cook {
    
    
    /// <summary>
    /// CookMainWindow
    /// </summary>
    public partial class CookMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EmployeeFullnameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchOrderIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid OrdersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FoodsInOrderDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CateringCore;component/windows/cook/cookmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
            ((CateringCore.Windows.Cook.CookMainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EmployeeFullnameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.SearchOrderIdTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
            this.SearchOrderIdTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UpdateFilters);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OrdersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 68 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
            this.OrdersDataGrid.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.OnOrderReselected);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FoodsInOrderDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 91 "..\..\..\..\..\Windows\Cook\CookMainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MarkAsCooked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

