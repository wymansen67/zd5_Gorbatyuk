using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    public partial class MainPage :ContentPage
    {
        public MainPage ()
        {
            InitializeComponent( );

            var welcomeLbl = new Label
            {
                StyleId = "header",
                Text = "Welcome",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var userEntry = new Entry
            {
                Placeholder = "Enter your username",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "entry"
            };

            var psswdEntry = new Entry
            {
                Placeholder = "Enter your password",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "entry"
            };

            var rmbMeButton = new RadioButton
            {
                Content = "Remember me",
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Color.White
            };

            var signInButton = new Button
            {
                Text = "Login",
                StyleId = "button",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            var signInLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,                
                Children = { rmbMeButton, signInButton, new Label { Text = "Forget you password? ", HorizontalOptions = LayoutOptions.End } }
            };

            var errorMsgLbl = new Label
            {
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center
            };
            var moneyBttn = new Button
            {
                Text = "Curreny Exchange",
                StyleId = "button",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            moneyBttn.Clicked += (sender, e) =>
            {
                string user = userEntry.Text;
                Navigation.PushAsync(new Exchanger(user));
            };

            signInButton.Clicked += (sender, e) =>
            {

                if ( string.IsNullOrWhiteSpace(userEntry.Text) || string.IsNullOrWhiteSpace(psswdEntry.Text) )
                {
                    errorMsgLbl.Text = "Username and password fields cannot be empty";
                }
                else
                {
                    string username = userEntry.Text;
                    string password = psswdEntry.Text;
                    Navigation.PushAsync(new Calc(username));
                }
            };

            var stackLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(25),
                Children = { welcomeLbl, userEntry, psswdEntry, signInButton, errorMsgLbl, rmbMeButton, signInLayout, moneyBttn }
            };

            Content = stackLayout;
        }
    }
}
