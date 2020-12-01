using Skills.DataBase;
using Skills.Services;
using Skills.Utility;
using Skills.Views;
using System;
using Xamarin.Forms;

namespace Skills
{
    public partial class App : Application
    {
    
        public static NavigationService navigationService { get; } = new NavigationService();
        public static SkillService SkillService { get; } = new SkillService();

        private static SkillsDB _dataBase;
        public static SkillsDB dataBase
        {
            get
            {
                if (_dataBase == null)
                   _dataBase = new SkillsDB();
                return _dataBase;
            }
        }
        public App()
        {

            Device.SetFlags(new string[] { "Shapes_Experimental" });
       
            InitializeComponent();
            navigationService.Configure(Viewnames.SkillsDetailsView, typeof(SkillsDetailsView));
            navigationService.Configure(Viewnames.SkillsView, typeof(SkillsView));
           // MainPage = new MasterDetailPage1();
          MainPage = new NavigationPage(new SkillsView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
