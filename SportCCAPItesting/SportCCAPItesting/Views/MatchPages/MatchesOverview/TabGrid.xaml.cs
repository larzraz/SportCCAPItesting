using SportCCAPItesting.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabGrid : ContentPage   
    {
 
        public LiveScoreViewModel LVM { get; set; }

        public TabGrid()
        {
            LVM = new LiveScoreViewModel();
            BindingContext = LVM;
            InitializeComponent();
            
        }
    }

    public class Test
    {
        public String Name { get; set; }
    }
}