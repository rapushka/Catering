﻿#pragma checksum "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F9D549E5A683AF6EC838443FC88297873499DF84"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CateringCore.Model;
using CateringCore.Windows.Pages.Common;
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
    /// DishesListPage
    /// </summary>
    public partial class DishesListPage : CateringCore.Windows.Pages.Common.EditableListPage<CateringCore.Model.Dish>, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SearchTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DishesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox EditTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditPriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyItemButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CateringCore;component/windows/manager/pages/dishes/disheslistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.16.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.SearchTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            this.SearchTitleTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.UpdateSearch);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 55 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            this.SearchTypeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UpdateSearch);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DishesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 69 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            this.DishesDataGrid.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.OnItemSelected);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 81 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveItem);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 91 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DishesTypesButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EditTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.EditTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.EditPriceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 120 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddItem);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ApplyItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            this.ApplyItemButton.Click += new System.Windows.RoutedEventHandler(this.ApplyItem);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 137 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ResetItem);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

