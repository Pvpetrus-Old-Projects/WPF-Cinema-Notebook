﻿#pragma checksum "..\..\..\Pages\FilmDetails.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9D2687A7A600DDF1EE9AA135599B6EB3BBB8CCD4F3F2961B8D3EF369B156324"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjektWPF.Pages;
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


namespace ProjektWPF.Pages {
    
    
    /// <summary>
    /// FilmDetails
    /// </summary>
    public partial class FilmDetails : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Pages\FilmDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox filmTitle;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\FilmDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker filmDate;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\FilmDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox filmViewed;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Pages\FilmDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox filmDescription;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Pages\FilmDetails.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteFilmButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjektWPF;component/pages/filmdetails.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\FilmDetails.xaml"
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
            this.filmTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.filmDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.filmViewed = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.filmDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.deleteFilmButton = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\Pages\FilmDetails.xaml"
            this.deleteFilmButton.Click += new System.Windows.RoutedEventHandler(this.deleteFilm);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 122 "..\..\..\Pages\FilmDetails.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.saveAddFilm);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
