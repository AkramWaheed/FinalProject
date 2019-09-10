using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace App3
{
    public partial class MainPage : ContentPage
    {
        RestService _restService; // instance of class for weather //

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService(); // intialising the weather data and method //

        }
        async void OnGetWeatherButtonClicked(object sender, EventArgs e) // getting weather data stored in weather object //
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData; // binding to use in xaml //
                string w = weatherData.Weather[0].Icon; // getting the icon image extension from json //

                string start = "http://openweathermap.org/img/w/"; // this has to be concatenated to icon name recieved by json //
                string end = ".png"; // this is the end extension of image icon //

                string complete = start + w + end; // joining the complete image to display in app //

                ionic.Source = new UriImageSource // creating new image for xaml display
                {
                    Uri = new Uri(complete), // binding the json to image //

                };

                ionic.HeightRequest = 150; // on click little make icon bigger //
                ionic.WidthRequest = 150; // same as above //
            }
        }

        string GenerateRequestUri(string endpoint) // some options to join with the api string 
        {
            string requestUri = endpoint; // join api url with api key
            requestUri += $"?q={_cityEntry.Text}"; // putting city in between url to get city //
            requestUri += "&units=metric"; // or units=metric or imperial //
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}"; // puttting api key to url //
            return requestUri;
        }

        private void BackToMainPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage()); // bringin to main page once clicked
        }
    }
}