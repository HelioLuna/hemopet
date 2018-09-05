using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hemopet.Core.Views.MeusDados
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DadosPage : ContentPage
	{
		public DadosPage(INavigation navigation)
		{
			InitializeComponent ();
		}
	}
}