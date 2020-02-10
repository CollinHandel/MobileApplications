using System.Net.Http;
using Marathon.Models;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Marathon
{
    public partial class MarathonPage : ContentPage
    {
        RaceCollection RaceObject;

        public MarathonPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FillPicker();
        }

        private void FillPicker() {

            var client = new HttpClient();
            client.BaseAddress = new System.Uri("http://itweb.fvtc.edu/wetzel/marathon/");
            var response = client.GetAsync("races/").Result;
            var wsJson = response.Content.ReadAsStringAsync().Result;

            RaceObject = JsonConvert.DeserializeObject<RaceCollection>(wsJson);

            if (RaceObject != null) {
                RacePicker.Items.Clear();

                foreach (race CurrentRace in RaceObject.races) {
                    RacePicker.Items.Add(CurrentRace.race_name);
                }
            }

        }

        void Race_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var SelectedRace = ((Picker)sender).SelectedIndex;
            var RaceID = RaceObject.races[SelectedRace].id;

            var client = new HttpClient();
            client.BaseAddress = new System.Uri("http://itweb.fvtc.edu/wetzel/marathon/");
            var response = client.GetAsync("results/" + RaceID).Result;
            var wsJson = response.Content.ReadAsStringAsync().Result;

            var ResultsObject = JsonConvert.DeserializeObject<ResultsCollection>(wsJson);

            var CellTemplate = new DataTemplate(typeof(TextCell));
            CellTemplate.SetBinding(TextCell.TextProperty, "name");
            CellTemplate.SetBinding(TextCell.DetailProperty, "detail");
            ListViewResults.ItemTemplate = CellTemplate;

            ListViewResults.ItemsSource = ResultsObject.results;
        }
    }
}
