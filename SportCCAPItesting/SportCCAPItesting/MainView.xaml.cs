using SportCCAPItesting.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportCCAPItesting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();
            this.Children.Add(new Sports());
            this.Children.Add(new CountryList());
            this.Children.Add(new Matches());
            this.Children.Add(new TodaysMatches());
         
        }
    }
}