﻿#pragma checksum "..\..\ModuleClient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6A4FE4E8F0CFFF7632E218440E585A30E926CDC9A0F149635E0BC97791FEFB0E"
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
    /// ModuleClient
    /// </summary>
    public partial class ModuleClient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ModuleClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConnexionButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ModuleClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ModuleClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PasserCommandeButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ModuleClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeconnexionButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ModuleClient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RetourButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BDD;component/moduleclient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModuleClient.xaml"
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
            this.ConnexionButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\ModuleClient.xaml"
            this.ConnexionButton.Click += new System.Windows.RoutedEventHandler(this.Connexion_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LoginButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\ModuleClient.xaml"
            this.LoginButton.Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PasserCommandeButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ModuleClient.xaml"
            this.PasserCommandeButton.Click += new System.Windows.RoutedEventHandler(this.PasserUneCommande_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeconnexionButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ModuleClient.xaml"
            this.DeconnexionButton.Click += new System.Windows.RoutedEventHandler(this.Deconnexion_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RetourButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ModuleClient.xaml"
            this.RetourButton.Click += new System.Windows.RoutedEventHandler(this.RetourButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

