using Android.Provider;
using SQLite;
using System.ComponentModel;

namespace Skills.Models
{
    public class MediaItemToUpload : INotifyPropertyChanged
    {
        private MediaType mediaType;
        private byte[] image;
        private int primaryKey;
        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get => primaryKey; set { primaryKey = value;
                OnPropertyChanged(nameof(PrimaryKey));
            } }
        public byte[] Image { get => image; set { image = value; OnPropertyChanged(nameof(Image)); } }
        public MediaType MediaType { get => mediaType; set { mediaType = value; OnPropertyChanged(nameof(MediaType)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
