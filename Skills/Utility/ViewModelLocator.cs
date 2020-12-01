
using Skills.ViewModels;
using Skills.Views;

namespace Skills.Utility
{

    public static class ViewModelLocator
    {

        public static SkillViewModel skillsView { get; set; } = new SkillViewModel( App.SkillService , App.navigationService);
        public static SkillsDetailsViewModel skillsDetailsView { get; set; } = new SkillsDetailsViewModel(App.SkillService, App.navigationService);

    }
  
}
