﻿#pragma checksum "..\..\Demo5.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EEF919D6A9E4E20AB336F9C67564F8FD5F4B4EB9F0E10D5C57D7C45C5617C036"
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
    /// Demo5
    /// </summary>
    public partial class Demo5 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TableDonnees;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TableRecettes;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RetourButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RetourPageAcc;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ListeProdLabel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle ListeProdRectangle;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ProduitComboBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SaisieManuelle;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AfficherButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RetourCheckBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label listeRecettesLabel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Demo5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle ListeRecettesRectangle;
        
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
            System.Uri resourceLocater = new System.Uri("/BDD;component/demo5.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Demo5.xaml"
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
            this.TableDonnees = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.TableRecettes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.RetourButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Demo5.xaml"
            this.RetourButton.Click += new System.Windows.RoutedEventHandler(this.RetourButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RetourPageAcc = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Demo5.xaml"
            this.RetourPageAcc.Click += new System.Windows.RoutedEventHandler(this.RetourPageAcc_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListeProdLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ListeProdRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 7:
            this.ProduitComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.SaisieManuelle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.AfficherButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Demo5.xaml"
            this.AfficherButton.Click += new System.Windows.RoutedEventHandler(this.AfficherButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.RetourCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 32 "..\..\Demo5.xaml"
            this.RetourCheckBox.Checked += new System.Windows.RoutedEventHandler(this.RetourCheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 11:
            this.listeRecettesLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.ListeRecettesRectangle = ((System.Windows.Shapes.Rectangle)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

