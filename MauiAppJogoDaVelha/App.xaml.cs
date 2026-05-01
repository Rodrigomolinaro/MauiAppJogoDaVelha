using Microsoft.Extensions.DependencyInjection;

namespace MauiAppJogoDaVelha
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Application.Current.Resources.MergedDictionaries.Add(new DarkTheme());

            MainPage = new AppShell();
        }

        
        
    }
}