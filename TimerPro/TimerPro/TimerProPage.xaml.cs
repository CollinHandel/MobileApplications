using Xamarin.Forms;
using TimerPro.Custom;
using System;

namespace TimerPro
{
    public partial class TimerProPage : ContentPage
    {
        TimerLogic oTimerLogic;
        bool isRunning;

        public TimerProPage()
        {
            InitializeComponent();
            oTimerLogic = new TimerLogic();
        }

        void Start_Clicked(object sender, System.EventArgs e)
        {
            btnStop.IsEnabled = true;
            btnStart.IsEnabled = false;
            isRunning = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                if (isRunning) {
                    oTimerLogic.SetTickCount();
                    lblDisplay.Text = oTimerLogic.GetFormatedString();
                }
                return isRunning;
            });
        }

        void Stop_Clicked(object sender, System.EventArgs e)
        {
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            isRunning = false;
        }

        void Reset_Clicked(object sender, System.EventArgs e)
        {
            oTimerLogic.Reset();
            lblDisplay.Text = oTimerLogic.GetFormatedString();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            lblDisplay.Text = "00:00:00";
        }
    }
}
