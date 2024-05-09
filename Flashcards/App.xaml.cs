using Flashcards.MVVM.Model.Context;
using Flashcards.MVVM.ViewModel;
using Flashcards.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider ServiceProvider { get; private set; }


        private IConfiguration configuration;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<FlashcardsDbContext>(options =>
            {
                options.UseSqlServer(@"Data Source=.;Initial Catalog=Flashcards;Integrated Security=True;TrustServerCertificate=True");
            });

            services.AddTransient(typeof(MainWindow));
            services.AddSingleton(provider =>
                WindowViewModel.GetInstance(provider.GetRequiredService<FlashcardsDbContext>()));
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }

    }
}
