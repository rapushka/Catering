﻿#pragma checksum "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8C6BF3CEAB63376E450380CEE8DB3830429D1375"
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
    /// DishesTypesListPage
    /// </summary>
    public partial class DishesTypesListPage : CateringCore.Windows.Pages.Common.EditableListPage<CateringCore.Model.DishType>, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DishesTypesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EditTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddItemButton;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ApplyItemButton;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ResetItemButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CateringCore;component/windows/manager/pages/dishes/dishestypeslistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
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
            
            #line 47 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
            this.SearchTitleTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnSearchChange);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DishesTypesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 61 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
            this.DishesTypesDataGrid.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.OnItemSelected);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 74 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveItem);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AddItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
            this.AddItemButton.Click += new System.Windows.RoutedEventHandler(this.AddItem);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ApplyItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
            this.ApplyItemButton.Click += new System.Windows.RoutedEventHandler(this.ApplyItem);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ResetItemButton = ((System.Windows.Controls.Button)(target));
            
            #line 120 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesTypesListPage.xaml"
            this.ResetItemButton.Click += new System.Windows.RoutedEventHandler(this.ResetItem);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

