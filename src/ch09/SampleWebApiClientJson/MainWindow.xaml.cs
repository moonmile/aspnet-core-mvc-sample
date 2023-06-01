using SampleWebApi.Models;
using SampleWebApiClientJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleWebApiClientJson;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += MainWindow_Loaded;
    }

    string urlBase = "http://localhost:5000";
    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        _vm = new MyViewModel();
        this.DataContext = _vm;

        // 都道府県データの読み込み
        var cl = new HttpClient();
        cl.BaseAddress = new Uri(urlBase);
        var res = await cl.GetAsync("/api/Addresses");
        var st = await res.Content.ReadAsStreamAsync();
        var items = await JsonSerializer.DeserializeAsync<List<Address>>(st,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        _vm.Addresses = items!;
    }
    MyViewModel _vm;

    private async void clickGet(object sender, RoutedEventArgs e)
    {
        var cl = new HttpClient();
        cl.BaseAddress = new Uri(urlBase);
        var res = await cl.GetAsync("/api/People");
        var st = await res.Content.ReadAsStreamAsync();
        var items = await JsonSerializer.DeserializeAsync<List<Person>>(st,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        _vm.People = items!;
        MessageBox.Show("一覧取得しました");
    }

    private async void clickGetId(object sender, RoutedEventArgs e)
    {
        if (_vm.Person.Id == 0) return;
        int id = _vm.Person.Id;

        var cl = new HttpClient();
        cl.BaseAddress = new Uri(urlBase);
        var res = await cl.GetAsync($"/api/People/{id}");
        var st = await res.Content.ReadAsStreamAsync();
        var item = await JsonSerializer.DeserializeAsync<Person>(st,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (item.Id == 0) return;
        _vm.Person = item!;
        MessageBox.Show("データを取得しました");
    }

    private async void clickPost(object sender, RoutedEventArgs e)
    {
        var cl = new HttpClient();
        _vm.Person.Id = 0; // 新規作成のため ID = 0 にしておく
        cl.BaseAddress = new Uri(urlBase);
        var content = JsonContent.Create(_vm.Person);
        var res = await cl.PostAsync($"/api/People", content);
        var st = await res.Content.ReadAsStreamAsync();
        var item = await JsonSerializer.DeserializeAsync<Person>(st,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        _vm.Person = item!;
        MessageBox.Show("新規作成しました");
    }

    private async void clickPutId(object sender, RoutedEventArgs e)
    {
        var id = _vm.Person.Id;
        var cl = new HttpClient();
        cl.BaseAddress = new Uri(urlBase);
        var content = JsonContent.Create(_vm.Person);
        var res = await cl.PutAsync($"/api/People/{id}", content);
        MessageBox.Show("更新しました");
    }

    private async void clickDeleteId(object sender, RoutedEventArgs e)
    {
        var id = _vm.Person.Id;
        var cl = new HttpClient();
        cl.BaseAddress = new Uri(urlBase);
        var res = await cl.DeleteAsync($"/api/People/{id}");
        MessageBox.Show("削除しました");
    }
}
