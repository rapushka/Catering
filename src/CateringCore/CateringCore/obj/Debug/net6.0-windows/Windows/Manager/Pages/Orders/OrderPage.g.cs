﻿#pragma checksum "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1CE7A715DEE4908DDD1F553B8B3C8249C6F22E25"
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


namespace CateringCore.Windows.Pages {
    
    
    /// <summary>
    /// OrdersListPage
    /// </summary>
    public partial class OrdersListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchOrderIdTextBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchFullNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid OrdersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid FoodsInOrderDataGrid;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DishesInOrderDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/CateringCore;component/windows/manager/pages/orders/orderpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
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
            
            #line 9 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
            ((CateringCore.Windows.Pages.OrdersListPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Load);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchOrderIdTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.SearchFullNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.OrdersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 67 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
            this.OrdersDataGrid.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.UpdateView);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FoodsInOrderDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.DishesInOrderDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            
            #line 101 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 107 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 114 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 127 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReceiptButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 134 "..\..\..\..\..\..\..\Windows\Manager\Pages\Orders\OrderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AssignButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

