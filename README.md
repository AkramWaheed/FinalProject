Project Title
Weather App
Getting Started
Please download the project folder from git hub using git bash or download the zip folder which is more eaiser.
Prerequisites
You need have visual studio installed in order to get the app up and running.
You can install visual studio from this link ..
You can install visual studio from this link ..
Installing
A step by step series of examples that tell you how to get a development env running
This link will show step by step how to install ..
Running and tests
Once you have visual studio downloaded second step just open the project solution which was dowloaded from github click on file .sln and fire it off from launch button.
Break down into geoposition
code example about current location
 public async static Task<Geoposition> getPosition() {

            var accessStatus = await Geolocator.RequestAccessAsync();

            if(accessStatus != GeolocationAccessStatus.Allowed)
            {
                throw new Exception();
                

            }
            //Give me whatever you can
            var geoLocator = new Geolocator { DesiredAccuracyInMeters = 0};

            var position = await geoLocator.GetGeopositionAsync();

            //return the position object 
            return position;
Break down into open weather API
Code example into HTTP REQUEST
  public async static Task<RootObject> GetWeather(double lat ,double lon)
        {
            var http = new HttpClient();
            var url = String.Format("http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&APPID=bbaedfc13ac236b02404a13559b2b111&units=metric", lat,lon);
            //Api  call - Open weather api 
            var responce = await http.GetAsync(url);
            var result = await responce.Content.ReadAsStringAsync();
            var serilizer = new DataContractJsonSerializer(typeof(RootObject));
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serilizer.ReadObject(memStream);

            return data;
            
        }
Built With
* Visual studio
* Open weather API
Authors
* WAHEED AKRAM - Initial work -(https://github.com/AkramWaheed)
License
This project is licensed under the MIT License - see the LICENSE.md file for details

