using Skills.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skills.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillsDetailsView : ContentPage
    {
        public SkillsDetailsView()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.skillsDetailsViewModel;
        }
    }
}