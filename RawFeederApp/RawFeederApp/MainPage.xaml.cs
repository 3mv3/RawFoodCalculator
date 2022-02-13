using RawFeederApp.ViewModels;
using Xamarin.Forms;

namespace RawFeederApp
{
    public partial class MainPage : ContentPage
    {
        RawFeederModel RawFeederModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = RawFeederModel = new RawFeederModel();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            RawFeederModel.SetRanges();
            Navigation.PushAsync(new FoodEntry(RawFeederModel));
        }
    }
}
