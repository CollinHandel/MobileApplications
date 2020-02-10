using System;
using Xamarin.Forms;

namespace PlatosCalculator
{
    public partial class PlatosCalculatorPage : CarouselPage
    {
        public PlatosCalculatorPage()
        {
            InitializeComponent();
            Title = "Platos Calculator";
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            Device.StartTimer(TimeSpan.FromMilliseconds(200), () => {
                this.CurrentPage = this.Children[1];
                return false;
            });
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () => {
                this.CurrentPage = this.Children[0];
                return false;
            });
        }

        void FemaleAge_Clicked(object sender, System.EventArgs e)
        {
            int intAge, intCalcAge;

            int.TryParse(txtAgeM.Text, out intAge);
            intCalcAge = (intAge / 2) + 7;

            lblCalculatedAgeF.Text = "Optimum female age is: " + intCalcAge.ToString() + " years old";
        }

        void MaleAge_Clicked(object sender, System.EventArgs e)
        {
            int intAge, intCalcAge;

            int.TryParse(txtAgeF.Text, out intAge);
            intCalcAge = (intAge * 2) - 14;

            lblCalculatedAgeM.Text = "Optimum male age is: " + intCalcAge.ToString() + " years old";
        }
    }
}
