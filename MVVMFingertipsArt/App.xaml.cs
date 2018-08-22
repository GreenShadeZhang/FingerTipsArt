using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MVVMFingertipsArt.Models;
using MVVMFingertipsArt.Services;
using MVVMFingertipsArt.ViewModels;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace MVVMFingertipsArt
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;
       // public static ObservableCollection<GridViewDataTemplate> grids { get; set; } = new ObservableCollection<GridViewDataTemplate>();
        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();
            SqliteGetdataService.MakeSureSqliteExsit();
            //grids = SqliteGetdataService.GetData();
            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
       
           // ViewModel.Data = grids;
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.HomePage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
