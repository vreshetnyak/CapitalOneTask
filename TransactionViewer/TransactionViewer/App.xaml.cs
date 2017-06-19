using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace TransactionViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            App.Current.DispatcherUnhandledException += (sender, exceptionArgs) =>
            {
                if (exceptionArgs != null && exceptionArgs.Exception != null)
                {
                    StringBuilder sbError = new StringBuilder();
                    sbError.AppendLine(exceptionArgs.Exception.Message);
                    sbError.AppendLine(TransactionViewer.Properties.Resources.Msg_ApplicationWillBeClosed);

                    MessageBox.Show(sbError.ToString(), TransactionViewer.Properties.Resources.Txt_CriticalError);

                    App.Current.Shutdown();
                }
            };
            new Bootstrapper().Run(e.Args);
        }
    }
}
