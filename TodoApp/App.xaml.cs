using Microsoft.Build.Framework.XamlTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using TodoApp.Services;

namespace TodoApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void OnStartUp(object sender, StartupEventArgs e)
        {
            string configPath = "config.ini";
            // Create a collection of services
            IServiceCollection services = new ServiceCollection();


            //Add utility services
            services.AddSingleton(LogFactory<App>.CreateLog);// метод сервис коннтейнера, сюда передаём фобрику
            services.AddScoped<Config>();


            //Add config
            if (!File.Exists(configPath))// проверяем наличия файла
            {
                File.Create(configPath).Close();
            }
            var configBuilder = new ConfigurationBuilder().AddIniFile(configPath);
            IConfiguration config = configBuilder.Build();
            services.AddSingleton<IConfiguration>(config);


            //// config db
            //string
            //    host = config.GetValue<string>("host"),
            //    user = config.GetValue<string>("user"),
            //    dbname = config.GetValue<string>("dbname"),
            //    dbpass = config.GetValue<string>("dbpass");

            //string Dsn =
            //    $"Server ={host}; Database = {dbname};User = {dbpass}; Password ={dbpass}";
            //var context = new Context.AppContext(Dsn);
            //services.AddSingleton<Context.AppContext>(context);

            //Category el1 = context.categories.Find(1);
            //// context.categories.Single<Category>();
            //context.categories.Create(); // добавляем элементы





            // Add services to the collection and configure them
            services.AddTransient<FirstService>();
            services.AddTransient<MainWindow>();

            // Create a service provider to call the services
            ServiceProvider provider = services.BuildServiceProvider();

            // Initialize Main Window
            MainWindow window = provider.GetService<MainWindow>();
            Logger<App> logger = provider.GetService<Logger<App>>();

            logger.LogInformation("Test");
            window.Show();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var cultureInfo = new CultureInfo("ru-Ru");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }
    }
}
