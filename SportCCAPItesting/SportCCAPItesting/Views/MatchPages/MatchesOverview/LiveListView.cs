
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SportCCAPItesting.Views.MatchPages.MatchesOverview
{
    public class LiveListView:ListView
    {
        public static readonly BindableProperty ItemsProperty =
    BindableProperty.Create("Items", typeof(IEnumerable), typeof(LiveListView), null, BindingMode.TwoWay);

        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

        public void NotifyItemSelected(object item)
        {
            if (ItemSelected != null)
            {
                ItemSelected(this, new SelectedItemChangedEventArgs(item));
            }
        }

    }
}
