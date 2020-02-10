using Xamarin.Forms;

namespace HelloWorld
{
    public partial class HelloWorldPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (lblDisplay.Text == "Hello World!")
            {
                lblDisplay.Text = "Goodbye World!";
            } else {
                lblDisplay.Text = "Hello World!";
            }
        }

        public HelloWorldPage()
        {
            InitializeComponent();
        }
    }
}
