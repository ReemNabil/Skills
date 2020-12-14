
using Skills.Models;
using Skills.Services;
using Skills.Utility;
using System.Windows.Input;
using Xamarin.Forms;

namespace Skills.ViewModels
{
    public class SkillsDetailsViewModel :ViewModelBase
    {

        private Skill selectedskill;
        public ICommand SaveCommand { get; }
        private ISkillService _skillService;
        private INavigationService _navigationService;
        public ICommand UploadCommand { get; }

        public Skill SelectedSkill
        { get => selectedskill;
            set
            {
                selectedskill = value;
                OnPropertyChanged(nameof(SelectedSkill));
            } 
        }

        public SkillsDetailsViewModel(ISkillService SkillService, INavigationService navigationService)
        {
            _skillService = SkillService;
            _navigationService = navigationService;
            selectedskill = new Skill();
            SaveCommand = new Command(OnSaveCommand);
            UploadCommand = new Command(OnUploadCommand);

        }
        private void OnUploadCommand(object obj)
        {
            _navigationService.NavigateTo(Viewnames.MainPage);
        }
        private void OnSaveCommand()
        {
            if (SelectedSkill.Id == 0)
                _skillService.AddSkill(SelectedSkill);
            else
                _skillService.UpdateSkill(SelectedSkill);

            MessagingCenter.Send(this, MessageNames.SkillsChangedMessage, SelectedSkill);

            _navigationService.GoBack();
        }
        public override void Initialize(object parameter)
        {
            if (parameter == null)
            {
              SelectedSkill = new Skill();
            }
            else
            {
                SelectedSkill = parameter as Skill;
            }       
        }

    }
}
