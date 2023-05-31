using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exchanger :ContentPage
    {
        private Entry usdLabel;
        private Label eurLabel;
        private Label date;

        public Exchanger (string user)
        {
            InitializeComponent( );

            double usd = 70.000;

            usdLabel = new Entry
            {
                Text = $"{usd}",
                FontAttributes = FontAttributes.Bold,
                StyleId = "else",
                Margin = new Thickness(30, 0, 0, 0)
            };

            eurLabel = new Label
            {
                Text = $"EUR: {double.Parse(usdLabel.Text) * 1.075}",
                FontAttributes = FontAttributes.Bold,
                TextDecorations = TextDecorations.Underline,
                Margin = new Thickness(30, 0, 0, 0)
            };

            var userLabel = new Label
            {
                Text = $"Welcome back, {user}!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            date = new Label
            {
                Text = DateTime.Today.ToString( ),
                HorizontalTextAlignment = TextAlignment.End,
                FontAttributes = FontAttributes.Bold,
                TextDecorations = TextDecorations.Underline,
                Margin = new Thickness(30, 0, 10, 0)
            };

            Content = new StackLayout
            {
                Children =
                {
                    userLabel,
                    new Label { Text = "Центробанк РФ: ",Margin =new Thickness (30,0,50,0)},
                    new Label { Text = "Today is: ",HorizontalTextAlignment = TextAlignment.End,Margin = new Thickness(0,0,10,0)},
                    date,
                    usdLabel,
                    eurLabel
                }
            };            
        }
    }
}