using Skills.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Skills.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkillsView : ContentPage
    {
        public SkillsView()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.skillViewModel; 
              

        }
    }
}