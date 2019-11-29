using SportCCAPItesting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views.MatchPages.MatchesOverview
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NestListViewTest : ContentPage
    {
        public LiveScoreViewModel LVM { get; set; }
        public NestListViewTest()
        {
            LVM = new LiveScoreViewModel();
            BindingContext = LVM;
            InitializeComponent();
        }
    }
}