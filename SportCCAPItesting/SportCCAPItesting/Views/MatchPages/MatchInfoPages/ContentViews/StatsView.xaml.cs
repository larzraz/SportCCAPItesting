﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views.MatchPages.MatchInfoPages.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsView : ContentView
    {
        public StatsView(Models.Match match)
        {
            InitializeComponent();
        }
    }
}