using SportCCAPItesting.Models;
using SportCCAPItesting.Views.MatchPages.MatchInfoPages.ContentViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class MatchInfoViewModel : BaseViewModel
    {
        private ObservableCollection<ContentView> _cv;
        private ObservableCollection<ContentPage> _cp;
        public ICommand ItemChangedCommand => new Command<ContentView>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);

        public Match Match { get; set; }
        public ObservableCollection<ContentView> CV { get { return _cv; } set { _cv = value; OnPropertyChanged("CV"); } }
        public ObservableCollection<ContentPage> CP { get { return _cp; } set { _cp = value; OnPropertyChanged("CP"); } }
        public bool HasPropertyValueChangedOverview { get; set; }
        public bool HasPropertyValueChangedLineUps { get; set; }
        public bool HasPropertyValueChangedStats { get; set; }
        public bool HasPropertyValueChangedH2H { get; set; }
        public bool HasPropertyValueChangedTable{ get; set; }
        public ContentView CurrentItem { get; set; }
        public int Position { get; set; }
        public MatchInfoViewModel(Match m)
        {
            Match = m;
            SetList();
            HasPropertyValueChangedOverview = true;
            OnPropertyChanged("HasPropertyValueChangedToday");
        }

        public void SetList()
        {
            CP = new ObservableCollection<ContentPage> { new OVP(Match) };
            CV = new ObservableCollection<ContentView>
            {
                
                new OverviewView(Match),
                new LineUpView(Match),
                new StatsView(Match),
                new Head2HeadView(Match) };
                if (Match.HasTable == "yes") {
                CV.Add(new Views.MatchPages.MatchInfoPages.ContentViews.TableView(Match));
                    }
            
        }
        private void ItemChanged(ContentView obj)
        {
            CurrentItem = obj;
            OnPropertyChanged("CurrentItem");
        }
        private void PositionChanged(int obj)
        {
            Position = obj;
            switch (Position)
            {
                case 0:
                    SetAllToFalse();
                    HasPropertyValueChangedOverview = true;
                    OnPropertyChanged("HasPropertyValueChangedOverview");
                    break;

                case 1:
                    SetAllToFalse();
                    HasPropertyValueChangedLineUps = true;
                    OnPropertyChanged("HasPropertyValueChangedLineUps");
                    break;

                case 2:
                    SetAllToFalse();
                    HasPropertyValueChangedStats = true;
                    OnPropertyChanged("HasPropertyValueChangedStats");
                    break;

                case 3:
                    SetAllToFalse();
                    HasPropertyValueChangedH2H = true;
                    OnPropertyChanged("HasPropertyValueChangedH2H");
                    break;

                case 4:
                    SetAllToFalse();
                    HasPropertyValueChangedTable = true;
                    OnPropertyChanged("HasPropertyValueChangedTable");
                    break;
            }

            OnPropertyChanged("Position");
        }

        private void SetAllToFalse()
        {
            HasPropertyValueChangedOverview = false;
            HasPropertyValueChangedLineUps = false;
            HasPropertyValueChangedStats = false;
            HasPropertyValueChangedH2H = false;
            HasPropertyValueChangedTable = false;
            OnPropertyChanged("HasPropertyValueChangedOverview");
            OnPropertyChanged("HasPropertyValueChangedLineUps");
            OnPropertyChanged("HasPropertyValueChangedStats");
            OnPropertyChanged("HasPropertyValueChangedH2H");
            OnPropertyChanged("HasPropertyValueChangedTable");
        }

    }
}
