using Xamarin.Forms;

namespace DistanceConverter
{
    public partial class DistanceConverterPage : ContentPage
    {
        public DistanceConverterPage()
        {
            InitializeComponent();
            Title = "Distance Converter";

            ToolbarItem tbi = new ToolbarItem();
            tbi.Text = "About";

            tbi.Clicked += delegate {
                Navigation.PushAsync(new Views.AboutPage());
            };

            this.ToolbarItems.Add(tbi);
        }
    }
}
