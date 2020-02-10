using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DateNight.Views
{
    public partial class CostPage : ContentPage
    {
        public CostPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try {
                lblCost.Text = App.dateCal.GetDateCost();
            } catch(Exception e) {
                lblCost.Text = "$0.00";
                DisplayAlert("Error", e.Message, "Ok");
            }

        }
    }
}
