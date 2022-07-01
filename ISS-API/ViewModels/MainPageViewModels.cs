using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ISS_API.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ISS_API.ViewModels
{
    public class MainPageViewModels : INotifyPropertyChanged
    {
            private ISSdata _data;
            public string str { get; set; }
            public ISSdata data
            {
                get => _data;
                set
                {
                    _data = value;
                    OnPropertyChanged();
                }
            }
            public ICommand SearchCommand { get; set; }

            public MainPageViewModels()
            {
                str = "...Or use te searchbar to input a name.";
                SearchCommand = new Command(async () =>
                {
                    await GetData($"https://api.wheretheiss.at/v1/satellites/25544");
                });
            }

            public async Task GetData(string url)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    str = "...Or use te searchbar to input a name.";
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ISSdata>(jsonResult);
                    data = result;
                }
                else
                {
                    str = "No results. Try another name.";
                    data = new ISSdata();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
}
