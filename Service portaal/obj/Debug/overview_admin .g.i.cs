﻿#pragma checksum "..\..\overview_admin .xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6D955F909650295CC4098FA8E86E57D9C4CB93A72DB40537905F07D650D1E57F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Service_portaal;
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


namespace Service_portaal {
    
    
    /// <summary>
    /// overview
    /// </summary>
    public partial class overview : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\overview_admin .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tbtn;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\overview_admin .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button vmbtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\overview_admin .xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbsfeer;
        
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
            System.Uri resourceLocater = new System.Uri("/Service portaal;component/overview_admin%20.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\overview_admin .xaml"
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
            this.tbtn = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\overview_admin .xaml"
            this.tbtn.Click += new System.Windows.RoutedEventHandler(this.tbtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.vmbtn = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\overview_admin .xaml"
            this.vmbtn.Click += new System.Windows.RoutedEventHandler(this.vmbtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbsfeer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 13 "..\..\overview_admin .xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

