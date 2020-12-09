using CommonServiceLocator;
using Skills.Services;
using Skills.ViewModels;
using Skills.Views;
using Unity;
using Unity.ServiceLocation;

namespace Skills.Utility
{

    public static class ViewModelLocator
    {
        // better to use framewrk like unity 
        //public static IUnityContainer Container { get; private set; } =
        //      new UnityContainer();
        static ViewModelLocator()
        {
            //Container.RegisterType<INavigationService, NavigationService>();
            //Container.RegisterType<ISkillService, SkillService>();
            //var unityServiceLocator = new UnityServiceLocator(Container);
            //ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
            //Container.RegisterType<INavigationService>();

            //var navigationService = Container.Resolve<NavigationService>();
            //navigationService.Configure(Viewnames.SkillsDetailsView, typeof(SkillsDetailsView));
            //navigationService.Configure(Viewnames.SkillsView, typeof(SkillsView));
        }


        public static SkillViewModel skillViewModel { get; set; } =
       // new SkillViewModel(App.Container.Resolve<SkillService>(), App.Container.Resolve<NavigationService>());
        new SkillViewModel(App.SkillService , App.navigationService);

        public static SkillsDetailsViewModel skillsDetailsViewModel { get; set; } =
       //  new SkillsDetailsViewModel(App.Container.Resolve<SkillService>(), App.Container.Resolve<NavigationService>());
       new SkillsDetailsViewModel(App.SkillService , App.navigationService);


    }

}
