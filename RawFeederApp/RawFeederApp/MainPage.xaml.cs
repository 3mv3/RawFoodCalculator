using RawFeederApp.ViewModels;
using Xamarin.Forms;

namespace RawFeederApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new RawFeederModel();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e) => Navigation.PushAsync(new FoodEntry((RawFeederModel)BindingContext));
    }
}
