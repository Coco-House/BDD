﻿#pragma checksum "..\..\PageD'accueil.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "21E5431CC5AC236BF3DE44C6DD722B235177015112E185AD31E99D4BE32FA03C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BDD;
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


namespace BDD {
    
    
    /// <summary>
    /// PageD_accueil
    /// </summary>
    public partial class PageD_accueil : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\PageD'accueil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClientButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\PageD'accueil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CdRButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\PageD'accueil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GestionButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PageD'accueil.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DemoButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BDD;component/paged\'accueil.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PageD'accueil.xaml"
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
            this.ClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\PageD'accueil.xaml"
            this.ClientButton.Click += new System.Windows.RoutedEventHandler(this.Client);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CdRButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\PageD'accueil.xaml"
            this.CdRButton.Click += new System.Windows.RoutedEventHandler(this.CdR);
            
            #line default
            #line hidden
            return;
            case 3:
            this.GestionButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\PageD'accueil.xaml"
            this.GestionButton.Click += new System.Windows.RoutedEventHandler(this.Gestion);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DemoButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\PageD'accueil.xaml"
            this.DemoButton.Click += new System.Windows.RoutedEventHandler(this.Demo);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

