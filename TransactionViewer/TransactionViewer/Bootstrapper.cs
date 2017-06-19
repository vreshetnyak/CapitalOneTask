using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TransactionViewer
{
    internal class Bootstrapper : UnityBootstrapper
    {
        #region Methods

        protected override IUnityContainer CreateContainer()
        {
            return new UnityContainer();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType<IMainViewModel, MainViewModel>();
        }

        protected override DependencyObject CreateShell()
        {
            var view = this.Container.Resolve<MainWindow>();

            if (view != null)
                view.Show();

            return view;
        }

        public void Run(string[] arguments)
        {
            this.Run();
        }

        #endregion
    }
}
