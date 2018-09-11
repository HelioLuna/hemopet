using hemopet.Core.Controls;
using hemopet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hemopet.Core.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : BottomBarPage
    {
        public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            BarBackgroundColor = Color.White;

            CustomNavigationPage DadosPage = new CustomNavigationPage(new MeusDados.DadosPage(Navigation), "Meus Dados");
            CustomNavigationPage AnimaisPage = new CustomNavigationPage(new Animal.AnimaisPage(Navigation), "Meus Animais");
            //CustomNavigationPage CronogramaPage = new CustomNavigationPage(new Cronograma.CronogramaPage(), "Cronograma");

            Children.Insert(0, DadosPage);
            Children.Insert(1, AnimaisPage);
           // Children.Insert(2, CronogramaPage);
        }
	}
}