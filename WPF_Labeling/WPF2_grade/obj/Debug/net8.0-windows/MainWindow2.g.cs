﻿#pragma checksum "..\..\..\MainWindow2.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CD881FB1E39DB4393FE39E05EA53E86695B6AAF4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using WPF2_grade;


namespace WPF2_grade {
    
    
    /// <summary>
    /// SecondWindow
    /// </summary>
    public partial class SecondWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 21 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PicturesListView;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Canva;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageInCanva;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LabelInput;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LabelsListView;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChooseFolderButton;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ChosenFolderName;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button prevButton;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextButton;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\MainWindow2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FinishLabelingButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF2_grade;component/mainwindow2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PicturesListView = ((System.Windows.Controls.ListView)(target));
            
            #line 21 "..\..\..\MainWindow2.xaml"
            this.PicturesListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LabelsListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Canva = ((System.Windows.Controls.Canvas)(target));
            
            #line 33 "..\..\..\MainWindow2.xaml"
            this.Canva.MouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_MouseMove);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\MainWindow2.xaml"
            this.Canva.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseUp);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\MainWindow2.xaml"
            this.Canva.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ImageInCanva = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.LabelInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 56 "..\..\..\MainWindow2.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LabelsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.ChooseFolderButton = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\MainWindow2.xaml"
            this.ChooseFolderButton.Click += new System.Windows.RoutedEventHandler(this.ChooseFolderButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ChosenFolderName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.prevButton = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\MainWindow2.xaml"
            this.prevButton.Click += new System.Windows.RoutedEventHandler(this.prevButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.nextButton = ((System.Windows.Controls.Button)(target));
            
            #line 112 "..\..\..\MainWindow2.xaml"
            this.nextButton.Click += new System.Windows.RoutedEventHandler(this.nextButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.FinishLabelingButton = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\MainWindow2.xaml"
            this.FinishLabelingButton.Click += new System.Windows.RoutedEventHandler(this.FinishLabelingButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 67 "..\..\..\MainWindow2.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.LabelTextBox_KeyDown);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 70 "..\..\..\MainWindow2.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 71 "..\..\..\MainWindow2.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

