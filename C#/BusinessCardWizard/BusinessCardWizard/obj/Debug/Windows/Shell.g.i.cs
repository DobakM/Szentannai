﻿#pragma checksum "..\..\..\Windows\Shell.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "93449184AEA6631D40FF284EDE4A3772736FCDBB4C34305B93E3C7DA30DEEB4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BusinessCardWizard.Controls;
using BusinessCardWizard.Windows;
using System;
using System.ComponentModel;
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


namespace BusinessCardWizard.Windows {
    
    
    /// <summary>
    /// Shell
    /// </summary>
    public partial class Shell : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Windows\Shell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider zoomslider;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Windows\Shell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock status;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Windows\Shell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal BusinessCardWizard.Controls.SideBar sidebar;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Windows\Shell.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabs;
        
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
            System.Uri resourceLocater = new System.Uri("/BusinessCardWizard;component/windows/shell.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Shell.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.zoomslider = ((System.Windows.Controls.Slider)(target));
            return;
            case 2:
            this.status = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.sidebar = ((BusinessCardWizard.Controls.SideBar)(target));
            
            #line 50 "..\..\..\Windows\Shell.xaml"
            this.sidebar.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.sidebar_button_Click));
            
            #line default
            #line hidden
            return;
            case 4:
            this.tabs = ((System.Windows.Controls.TabControl)(target));
            
            #line 53 "..\..\..\Windows\Shell.xaml"
            this.tabs.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.tabs_Click));
            
            #line default
            #line hidden
            
            #line 53 "..\..\..\Windows\Shell.xaml"
            this.tabs.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.tabs_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

