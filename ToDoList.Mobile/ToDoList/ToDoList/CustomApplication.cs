using Android.App;
using SimpleInjector;
using System;
using ToDoList.Core.Helpers;
using ToDoList.Core.Interfaces.Database;
using ToDoList.Core.Interfaces.Services;
using ToDoList.Services;
using Xamarin.Essentials;

namespace ToDoList
{
    public class CustomApplication : Application, IDependencyResolver, IDispatcherService
    {
        public Container Container { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();

            Platform.Init(this);

            RegisterTypesInIoCContainer();

            InitApp();
        }

        private void RegisterTypesInIoCContainer()
        {
            Container = new Container();
            IoCRegistrator.Register(Container);

            Container.RegisterInstance<IDependencyResolver>(this);
            Container.RegisterInstance<IDispatcherService>(this);
            Container.Register<INavigationService, AndroidNavigationService>(Lifestyle.Singleton);
            Container.Register<IDialogService, AndroidDialogService>(Lifestyle.Singleton);

            Container.Verify();
        }

        private void InitApp()
        {
            var databaseStorage = GetInstance<IDatabaseStorage>();
            databaseStorage.Init();
        }

        #region IDependencyResolver implementation

        public T GetInstance<T>() where T : class
        {
            return Container.GetInstance<T>();
        }

        public object GetInstance(Type objectType)
        {
            return Container.GetInstance(objectType);
        }

        #endregion

        #region IDispatcherService implementation

        public void RunOnUIThread(Action action)
        {
            try
            {
                MainThread.BeginInvokeOnMainThread(action);
            }
            catch
            {
            }
        }

        #endregion
    }
}