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
    public partial class StackLayoutTesting : ContentPage
    {
        public LiveScoreViewModel LVM { get; set; }
        public StackLayoutTesting()
        {
            LVM = new LiveScoreViewModel();
            BindingContext = LVM;
            InitializeComponent();
            scrView.ScrollToAsync(stkLayout.Children[2], ScrollToPosition.Center, true);
            
        }
    }
}