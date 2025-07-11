using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using SO_OMS.Presentation.Forms;


namespace SO_OMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles(); 
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false); 
            
            var provider = BootStrapper.BuildServiceProvider();
            var loginForm = provider.GetRequiredService<LoginForm>();
            System.Windows.Forms.Application.Run(loginForm);
        }
    }
}
