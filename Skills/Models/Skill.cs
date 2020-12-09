using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace Skills.Models
{
    public class Skill : INotifyPropertyChanged
    {
        private int id;
        private int proficiencylevel;
        private string skillname;
        private string skillDescription;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get=> id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
   
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [MaxLength(100)]
        
        public int Proficiencylevel
        {
            get => proficiencylevel;
            set
            {
                proficiencylevel = value;
                OnPropertyChanged(nameof(Proficiencylevel));
            }
        }
        public string Skillname { get => skillname; set { skillname = value; OnPropertyChanged(nameof(Skillname)); } }
        public string SkillDescription { get => skillDescription; set { skillDescription = value; OnPropertyChanged(nameof(SkillDescription));  } }

    }
}
