using SportCCAPItesting.Views;

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
            this.Children.Add(new TodaysMatches());
            this.Children.Add(new CountryList());
        }
    }
}