using Android.Provider;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Skills.Models;
using Skills.Utility;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Skills
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.skillViewModel;
        }


       private byte[] image;

        public byte[] Imagee { get => image; set => image = value; }

        private async void PickPhotoButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await SelectPhoto();
                if (result != null)
                    viewPhotoImage.Source = result;
                //byte[] myimage = System.IO.File.ReadAllBytes(result);
                SaveAsync();
            }
            catch (Exception ex)
            {
                // handle your exception
                System.Console.WriteLine(ex);
            }
        }
        private async void TakePhotoButton_Clicked(object sender, EventArgs e)
        {

            try
            {
                var result = await TakePhoto();
                if (result != null)
                    viewPhotoImage.Source = result;
                SaveAsync();
            }
            catch (Exception ex)
            {
                // handle your exception
            }
        }
        public async Task<ImageSource> SelectPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", "Sorry! Permission not granted to photos.", "OK");
                return null;
            }

            var isPermissionGranted = await RequestCameraAndGalleryPermissions();
            if (!isPermissionGranted)
                return null;

            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return null;

            var imageSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            return imageSource;
        }
        private async Task<bool> RequestCameraAndGalleryPermissions()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            var photosStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Photos);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var permissionRequestResult = await CrossPermissions.Current.RequestPermissionsAsync(
                    new Permission[] { Permission.Camera, Permission.Storage, Permission.Photos });

                var cameraResult = permissionRequestResult[Plugin.Permissions.Abstractions.Permission.Camera];
                var storageResult = permissionRequestResult[Plugin.Permissions.Abstractions.Permission.Storage];
                var photosResult = permissionRequestResult[Plugin.Permissions.Abstractions.Permission.Photos];

                return (
                    cameraResult != PermissionStatus.Denied &&
                    storageResult != PermissionStatus.Denied &&
                    photosResult != PermissionStatus.Denied);
            }

            return true;
        }
        public async Task<ImageSource> TakePhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable ||
                    !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "Sorry! No camera available.", "OK");
                return null;
            }

            var isPermissionGranted = await RequestCameraAndGalleryPermissions();
            if (!isPermissionGranted)
                return null;

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "TestPhotoFolder",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.Medium,
                MaxWidthHeight = 1000,
            });

            if (file == null)
                return null;

            var imageSource = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                 image = GetImageStreamAsBytes(stream);
                return stream;
            });
            return imageSource;
        }

        public async void SaveAsync()
        {
            var connection = App.dataBase.connection;
            connection.Insert(new MediaItemToUpload { MediaType = MediaType.Audio, Image = image });
            //Retrive From DB
            MediaItemToUpload mediaItem = connection.Table<MediaItemToUpload>().FirstOrDefault();
            MemoryStream mStream = new MemoryStream(mediaItem.Image);
            var imageSource =  ImageSource.FromStream(()=>mStream);
            viewPhotoImage.Source =imageSource;
            


        }
        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
