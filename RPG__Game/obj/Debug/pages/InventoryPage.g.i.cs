﻿#pragma checksum "..\..\..\pages\InventoryPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A54770AD66E754C27145EE69AA15ACC2926C1FD1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

using RPG__Game.pages;
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
using WpfAnimatedGif;


namespace RPG__Game.pages {
    
    
    /// <summary>
    /// InventoryPage
    /// </summary>
    public partial class InventoryPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\pages\InventoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvUsers;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\pages\InventoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SliderAdd;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\pages\InventoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SliderRemove;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\pages\InventoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider StaminaSlider;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\pages\InventoryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image character_standing;
        
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
            System.Uri resourceLocater = new System.Uri("/RPG__Game;component/pages/inventorypage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\InventoryPage.xaml"
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
            
            #line 11 "..\..\..\pages\InventoryPage.xaml"
            ((RPG__Game.pages.InventoryPage)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Page_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lvUsers = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.SliderAdd = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\pages\InventoryPage.xaml"
            this.SliderAdd.Click += new System.Windows.RoutedEventHandler(this.SliderAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SliderRemove = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\pages\InventoryPage.xaml"
            this.SliderRemove.Click += new System.Windows.RoutedEventHandler(this.SliderRemove_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.StaminaSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 63 "..\..\..\pages\InventoryPage.xaml"
            this.StaminaSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.character_standing = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
