﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportCCAPItesting.ViewModels
{
    public class CameraViewModel : BaseViewModel
    {
        public ICommand ResetCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public CameraViewModel()
        {
            SaveCommand = new Command<bool>(async islandscape => await OnSave((bool)islandscape));
            SetFilename();
        }

        void SetFilename()
        {
            var datestamp = string.Format("{0:yyMMddHHmmss}", DateTime.Now);
            Filename = $"ConferenceVision_{datestamp}.jpg";
        }

        public bool _canCancel = true;
        public bool CanCancel
        {
            get
            {
                return _canCancel;
            }
            set
            {
                _canCancel = value;
                OnPropertyChanged(nameof(CanCancel));
            }
        }

        public bool _canCapture = true;
        public bool CanCapture
        {
            get
            {
                return _canCapture;
            }
            set
            {
                _canCapture = value;
                OnPropertyChanged(nameof(CanCapture));
            }
        }

        private string _filename;
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                OnPropertyChanged(nameof(Filename));
            }
        }

        public int EncodingId
        {
            get
            {
                return 411;
            }
        }

      

       

      
       

        public async Task OnSave(bool isLandscape)
        {
            Debug.WriteLine($"ON SAVE Media:{Filename}");
            //var m = new Memory()
            //{
            //    MediaPath = Filename,
            //    CreatedBy = "ConferenceVision",
            //    CreatedAt = DateTime.Now
            //};

            //if (await DependencyService.Get<VisionService>().DetectAchievements(m))
            //{
            //    App.DataStore.Memories.Insert(0, m);

            //    DependencyService.Get<DataStoreService>().Save(App.DataStore);

            //    LastMemory = m;

            //    SetFilename();

            //    OnPropertyChanged(nameof(ThumbnailImagePath));
            //    OnPropertyChanged(nameof(HasLastMemory));
            //    OnPropertyChanged(nameof(HasAchievement));
            //}
            //else
            //{
            //    await App.Current.MainPage.DisplayAlert("Error", "Failed to Save Image", "Cancel");
            //}
        }

        private void CreateFakeMemory()
        {
            //LastMemory = new Memory
            //{
            //    Achievements = new ObservableCollection<Achievement> { new Achievement { Name = "Xamarin", Icon = "iconXamarin" } }
            //};

            //OnPropertyChanged(nameof(ThumbnailImagePath));
            //OnPropertyChanged(nameof(HasLastMemory));
            //OnPropertyChanged(nameof(HasAchievement));
        }

    }
}
