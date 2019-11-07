using SportCCAPItesting.Models;
using SportCCAPItesting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting.Views.MatchPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchInfoPage : ContentPage
    {
        MatchInfoViewModel MVM;
        public MatchInfoPage(Match m)
        {
            MVM = new MatchInfoViewModel(m);
            BindingContext = MVM;           
            InitializeComponent();
            

            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}