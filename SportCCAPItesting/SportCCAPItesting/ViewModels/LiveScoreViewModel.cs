using SportCCAPItesting.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class LiveScoreViewModel : BaseViewModel
    {
        //Private variables
        private ObservableCollection<ListContentView> _lcv;

        private DateTime Today = DateTime.Now;
        private DateTime TodayDateMinusTwo { get { return Today.AddDays(-2); } }
        private DateTime TodayDateMinusOne { get { return Today.AddDays(-1); } }
        private DateTime TodayDatePlusOne { get { return Today.AddDays(1); } }
        private DateTime TodayDatePlusTwo { get { return Today.AddDays(2); } }

        //Properties
        public ICommand ItemChangedCommand => new Command<ListContentView>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);
        public ICommand TappedDateCommand => new Command<string>(ChangeToTappedDate);
        public RelayCommandSnap ChangeDateCommand => new RelayCommandSnap(obj => ChangeToTappedDate((string)obj));




        public string TodayDateMinusTwoString { get { return TodayDateMinusTwo.ToString("ddd"); } }
        public string TodayDateMinusOneString { get { return TodayDateMinusOne.ToString("ddd"); } }
        public string TodayString { get { return "Today"; } }
        public string TodayDatePlusOneString { get { return TodayDatePlusOne.ToString("ddd"); } }
        public string TodayDatePlusTwoString { get { return TodayDatePlusTwo.ToString("ddd"); } }

        public string TodayDateMinusTwoDateString { get { return TodayDateMinusTwo.Day.ToString(); } }
        public string TodayDateMinusOneDateString { get { return TodayDateMinusOne.Day.ToString(); } }
        public string TodayDateString { get { return Today.Day.ToString(); } }
        public string TodayDatePlusOneDateString { get { return TodayDatePlusOne.Day.ToString(); } }
        public string TodayDatePlusTwoDateString { get { return TodayDatePlusTwo.Day.ToString(); } }


        public ObservableCollection<ListContentView> LCV { get { return _lcv; } set { _lcv = value; OnPropertyChanged("LCV"); } }
        public bool HasPropertyValueChangedTodayMinus2 { get; set; }
        public bool HasPropertyValueChangedTodayMinus1 { get; set; }
        public bool HasPropertyValueChangedToday { get; set; }
        public bool HasPropertyValueChangedTodayPlus1 { get; set; }
        public bool HasPropertyValueChangedTodayPlus2 { get; set; }
        public ListContentView CurrentItem { get; set; }
        public int Position { get; set; }


        public LiveScoreViewModel()
        {
            SetList();
            OnPropertyChanged("CurrentItem");
            Position = 2;
            HasPropertyValueChangedToday = true;
            OnPropertyChanged("HasPropertyValueChangedToday");
            OnPropertyChanged("Position");
            
        }

        //Methods
        public void SetList()
        {
            LCV = new ObservableCollection<ListContentView>
            {
                new ListContentView(TodayDateMinusTwo),
                new ListContentView(TodayDateMinusOne),
                new ListContentView(Today),
                new ListContentView(TodayDatePlusOne),
                new ListContentView(TodayDatePlusTwo),
                new ListContentView(Today)
            };
            
        }

        private void ItemChanged(ListContentView obj)
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
                    HasPropertyValueChangedTodayMinus2 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayMinus2");
                    break;

                case 1:
                    SetAllToFalse();
                    HasPropertyValueChangedTodayMinus1 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayMinus1");
                    break;

                case 2:
                    SetAllToFalse();
                    HasPropertyValueChangedToday = true;
                    OnPropertyChanged("HasPropertyValueChangedToday");
                    break;

                case 3:
                    SetAllToFalse();
                    HasPropertyValueChangedTodayPlus1 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayPlus1");
                    break;

                case 4:
                    SetAllToFalse();
                    HasPropertyValueChangedTodayPlus2 = true;
                    OnPropertyChanged("HasPropertyValueChangedTodayPlus2");
                    break;
            }

            OnPropertyChanged("Position");
        }

        private void SetAllToFalse()
        {
            HasPropertyValueChangedTodayMinus2 = false;
            HasPropertyValueChangedTodayMinus1 = false;
            HasPropertyValueChangedToday = false;
            HasPropertyValueChangedTodayPlus1 = false;
            HasPropertyValueChangedTodayPlus2 = false;
            OnPropertyChanged("HasPropertyValueChangedTodayMinus2");
            OnPropertyChanged("HasPropertyValueChangedTodayMinus1");
            OnPropertyChanged("HasPropertyValueChangedToday");
            OnPropertyChanged("HasPropertyValueChangedTodayPlus1");
            OnPropertyChanged("HasPropertyValueChangedTodayPlus2");
        }

        private void ChangeToTappedDate(string position)
        {
            Position = Convert.ToInt32(position);
            PositionChanged(Convert.ToInt32(position));
            OnPropertyChanged("Position");
        }
    }
}