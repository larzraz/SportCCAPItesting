﻿using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views.MatchPages.MatchInfoPages.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewView : ContentView
    {
        public OverviewViewModel OVM { get; set; }
        public Match Match { get; set; }
        public OverviewView(Models.Match match)
        {
            OVM = new OverviewViewModel(match);
            Match = match;
            BindingContext = OVM;          
            InitializeComponent();
            //Fulltime_Label.SetBinding(Label.BindingContextProperty, OVM.Match.Result.ScoreInfo.Score[0].Name);
            //Halftime_Label.SetBinding(Label.BindingContextProperty,OVM.Match.Result.ScoreInfo.Score[1].Name);
        }
    }
}