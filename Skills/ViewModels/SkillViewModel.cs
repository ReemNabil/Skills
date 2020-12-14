using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Skills.Models;
using Skills.Services;
using Skills.Utility;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Skills.ViewModels
{
    public class SkillViewModel : ViewModelBase
    {
        private ObservableCollection<Skill> skills;
        private ImageSource imageSource ; 
        public ICommand AddCommand { get; }
        public ICommand SkillSelectedCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand UpLoadCommand { get; }

        private ISkillService _skillService;

        private INavigationService _navigationService;

        public SkillViewModel(ISkillService SkillService, INavigationService navigationService)
        {
            _skillService = SkillService;
            _navigationService = navigationService;
            skills = new ObservableCollection<Skill>(_skillService.GetAllSkills());
            AddCommand = new Command(OnAddCommand);
            LoadCommand = new Command(OnLoadCommand);
            UpLoadCommand = new Command(OnUpLoadPhotoCommand);
            SkillSelectedCommand = new Command<Skill>(OnSkillSelectedCommand);
            MessagingCenter.Subscribe<SkillsDetailsViewModel, Skill>
                (this, MessageNames.SkillsChangedMessage, OnSkillsListChange);
         
        }

       

        private async void OnUpLoadPhotoCommand(object obj)
        {
            var image = await SelectPhoto();
            if (image != null)
                ImageSource = image;
        }

        public async Task<ImageSource> SelectPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //await DisplayAlert("Photos Not Supported",
                //           "Sorry! Permission not granted to photos.", "OK");
                //return null;
            }

            var isPermissionGranted = await RequestCameraAndGalleryPermissions();
            if (!isPermissionGranted)
                return null;

            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new
                Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return null;

            var imageSource = Xamarin.Forms.ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            return imageSource;
        }

        private async Task<bool> RequestCameraAndGalleryPermissions()
        {
            var cameraStatus = await CrossPermissions.Current.
            CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.
            CheckPermissionStatusAsync(Permission.Storage);
            var photosStatus = await CrossPermissions.Current.
            CheckPermissionStatusAsync(Permission.Photos);

            if (
            cameraStatus != PermissionStatus.Granted ||
            storageStatus != PermissionStatus.Granted ||
            photosStatus != PermissionStatus.Granted)
            {
                var permissionRequestResult = await CrossPermissions.Current.
                RequestPermissionsAsync(
                    new Permission[]
                    {
                Permission.Camera,
                Permission.Storage,
                Permission.Photos
                    });

                var cameraResult = permissionRequestResult[Permission.Camera];
                var storageResult = permissionRequestResult[Permission.Storage];
                var photosResults = permissionRequestResult[Permission.Photos];

                return (
                    cameraResult != PermissionStatus.Denied &&
                    storageResult != PermissionStatus.Denied &&
                    photosResults != PermissionStatus.Denied);
            }

            return true;
        }
        private void OnSkillsListChange(SkillsDetailsViewModel sender, Skill skill)
        {
            skills = new ObservableCollection<Skill>(_skillService.GetAllSkills());

        }

        private void OnLoadCommand()
        {
            // skills = new ObservableCollection<Skill>(_skillService.GetAllSkills());
            _navigationService.NavigateTo(Viewnames.Posts);

        }

        private void OnSkillSelectedCommand(Skill obj)
        {

            _navigationService.NavigateTo(Viewnames.SkillsDetailsView, obj);
            

        }

        private void OnAddCommand()
        {
            _navigationService.NavigateTo(Viewnames.SkillsDetailsView);
        }


        public ObservableCollection<Skill> SKills {
            get => skills;
            set
            {
                skills = value;
                OnPropertyChanged(nameof(SKills));
            }
                
        }

        public ImageSource ImageSource { get => imageSource; set { imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }  }
    }
}
