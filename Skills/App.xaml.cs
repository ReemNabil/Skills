using CommonServiceLocator;
using Skills.DataBase;
using Skills.Services;
using Skills.Utility;
using Skills.Views;
using System;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;

namespace Skills
{
    public partial class App : Application
    {

       public static NavigationService navigationService { get; } = new NavigationService();

        public static SkillService SkillService { get; } = new SkillService();

        private static SkillsDB _dataBase;
        //public static IUnityContainer Container { get; private set; } =
        //   new UnityContainer(); 
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
            // better in utitly 
            InitializeComponent();
            navigationService.Configure(Viewnames.SkillsDetailsView, typeof(SkillsDetailsView));
            navigationService.Configure(Viewnames.SkillsView, typeof(SkillsView));
            //  MainPage = new MainPage();
            Plugin.Media.CrossMedia.Current.Initialize();
            MainPage = new NavigationPage(new SkillsView());
            //Container.RegisterType<INavigationService, NavigationService>();
            //Container.RegisterType<ISkillService, SkillService>();
            //var unityServiceLocator = new UnityServiceLocator(Container);
            //ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            //var navigationService = Container.Resolve<NavigationService>();
            //navigationService.Configure(Viewnames.SkillsDetailsView, typeof(SkillsDetailsView));
            //navigationService.Configure(Viewnames.SkillsView, typeof(SkillsView));
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
