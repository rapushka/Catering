﻿#pragma checksum "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86730637C0DCCE56A5EB8F943AD68600E9028E93"
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
    /// DishesListPage
    /// </summary>
    public partial class DishesListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DishesDataGrid;
        
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            ((CateringCore.Windows.Pages.DishesListPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DishesListPage_OnLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DishesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            
            #line 94 "..\..\..\..\..\..\..\Windows\Manager\Pages\DIshes\DishesListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DishesTypesButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

