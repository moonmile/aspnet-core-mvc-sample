using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SampleWebApiClient
{
    /// <summary>
    /// MainWindow0.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void clickGet(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var res = await hc.GetAsync("http://localhost:5000/api/People");
            var str = await res.Content.ReadAsStringAsync();
            textResult.Text = str;
        }
        private int _id = 1002;
        private async void clickGetId(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var res = await hc.GetAsync($"http://localhost:5000/api/People/{_id}");
            var str = await res.Content.ReadAsStringAsync();
            textResult.Text = str;
        }

        private async void clickPost(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var data = new Person
            {
                Name = "new person",
                AddressId = 1,
                Age = 99
            };
            var content = JsonContent.Create(data);
            var res = await hc.PostAsync("http://localhost:5000/api/People", content);
            var str = await res.Content.ReadAsStringAsync();
            textResult.Text = str;
        }

        private async void clickPutId(object sender, RoutedEventArgs e)
        {
            var hc = new HttpClient();
            var data = new Person
            {
                Id = _id,
                Name = "update person",
                AddressId = 1,
                Age = 99
            };
            var content = JsonContent.Create(data);
            var res = await hc.PutAsync($"http://localhost:5000/api/People/{_id}", content);
        }
    }
}
