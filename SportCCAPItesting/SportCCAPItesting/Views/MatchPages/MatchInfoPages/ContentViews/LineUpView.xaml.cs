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
    public partial class LineUpView : ContentView
    {
        public OverviewViewModel OVM { get; set; }
        public LineUpView(Models.Match match)
        {
            OVM = new OverviewViewModel(match);
            InitializeComponent();
            BindingContext = OVM;
        }
    }
}