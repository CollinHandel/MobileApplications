using Xamarin.Forms;

namespace AddMaster
{
    public partial class AddMasterPage : ContentPage
    {
        public AddMasterPage()
        {
            InitializeComponent();
        }

        void Add_Clicked(object sender, System.EventArgs e)
        {
            double dblFirstNum, dblSecondNum;

            double.TryParse(txtFirstNumber.Text, out dblFirstNum);
            double.TryParse(txtSecondNumber.Text, out dblSecondNum);

            lblDisplay.Text = (dblFirstNum + dblSecondNum).ToString();
        }

        void Clear_Clicked(object sender, System.EventArgs e)
        {
            txtFirstNumber.Text = string.Empty;
            txtSecondNumber.Text = string.Empty;
            lblDisplay.Text = "0";
        }
    }
}
