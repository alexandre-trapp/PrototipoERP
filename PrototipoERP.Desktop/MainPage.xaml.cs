using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;

namespace PrototipoERP.Desktop
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnLembretesClicked(object sender, EventArgs e)
        {
            count++;
            CounterLabel.Text = $"Lembrete count: {count}";

            SemanticScreenReader.Announce(CounterLabel.Text);
        }
    }
}
