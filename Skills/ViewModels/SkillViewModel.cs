using Skills.Models;
using Skills.Services;
using Skills.Utility;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Skills.ViewModels
{
    public class SkillViewModel : ViewModelBase
    {
        private ObservableCollection<Skill> skills;
        public ICommand AddCommand { get; }
        public ICommand SkillSelectedCommand { get; }
        public ICommand LoadCommand { get; }

        private ISkillService _skillService;

        private INavigationService _navigationService;

        public SkillViewModel(ISkillService SkillService, INavigationService navigationService)
        {
            _skillService = SkillService;
            _navigationService = navigationService;
            skills = new ObservableCollection<Skill>(_skillService.GetAllSkills());
            AddCommand = new Command(OnAddCommand);
            LoadCommand = new Command(OnLoadCommand);
            SkillSelectedCommand = new Command<Skill>(OnSkillSelectedCommand);
        }

        private void OnLoadCommand()
        {
            skills = new ObservableCollection<Skill>(_skillService.GetAllSkills());
        }

        private void OnSkillSelectedCommand(Skill obj)
        {

           App.navigationService.NavigateTo(Viewnames.SkillsDetailsView, obj);

        }

        private void OnAddCommand()
        {
           App.navigationService.NavigateTo(Viewnames.SkillsDetailsView);
        }


        public ObservableCollection<Skill> SKills {
            get => skills;
            set
            {
                skills = value;
                OnPropertyChanged(nameof(SKills));
            }
                
        }

    
    }
}
