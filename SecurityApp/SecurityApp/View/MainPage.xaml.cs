using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SecurityApp
{
	public partial class MainPage : ContentPage
	{
        RestController client; 
		public MainPage(RestController client)
		{
            this.client = client;
			InitializeComponent();
		}

        private async Task Button_ClickedAsync(object sender, EventArgs e)
        {
            await client.GetTemperatureAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var value = this.newTemperature.Text;
            await client.PutTemperatureAsync(value);
        }
    }
}
