﻿#pragma checksum "..\..\..\pages\GameOver.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4C925643FDA066998E8A4FEB0EDD11EC966F5904"
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


namespace RPG__Game.pages {
    
    
    /// <summary>
    /// GameOver
    /// </summary>
    public partial class GameOver : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\pages\GameOver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button newGame;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\pages\GameOver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loadGame;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\pages\GameOver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitGame;
        
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
            System.Uri resourceLocater = new System.Uri("/RPG__Game;component/pages/gameover.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\GameOver.xaml"
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
            this.newGame = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\pages\GameOver.xaml"
            this.newGame.MouseEnter += new System.Windows.Input.MouseEventHandler(this.button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\pages\GameOver.xaml"
            this.newGame.MouseLeave += new System.Windows.Input.MouseEventHandler(this.button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\pages\GameOver.xaml"
            this.newGame.Click += new System.Windows.RoutedEventHandler(this.newGame_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.loadGame = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\pages\GameOver.xaml"
            this.loadGame.MouseEnter += new System.Windows.Input.MouseEventHandler(this.button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\pages\GameOver.xaml"
            this.loadGame.MouseLeave += new System.Windows.Input.MouseEventHandler(this.button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\pages\GameOver.xaml"
            this.loadGame.Click += new System.Windows.RoutedEventHandler(this.loadGame_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.exitGame = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\pages\GameOver.xaml"
            this.exitGame.MouseEnter += new System.Windows.Input.MouseEventHandler(this.button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\pages\GameOver.xaml"
            this.exitGame.MouseLeave += new System.Windows.Input.MouseEventHandler(this.button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 36 "..\..\..\pages\GameOver.xaml"
            this.exitGame.Click += new System.Windows.RoutedEventHandler(this.exitGame_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

