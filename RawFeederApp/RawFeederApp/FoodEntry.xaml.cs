using RawFeederApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace RawFeederApp
{
    public partial class FoodEntry : ContentPage
    {
        public FoodEntry(RawFeederModel context)
        {
            InitializeComponent();
            BindingContext = context;
        }

        void Button_Pressed(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Calculate((RawFeederModel)BindingContext));
        }
    }
}