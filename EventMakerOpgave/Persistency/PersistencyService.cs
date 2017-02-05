using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.Model;
using Windows.Storage;
using Newtonsoft.Json;
using System.Diagnostics;

namespace EventMakerOpgave.Persistency
{
    class PersistencyService
    {

        public static async void SaveEventAsJsonAsync(String fileName, ObservableCollection<Event> save)
        {

            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string JsonData = JsonConvert.SerializeObject(save);
            await FileIO.WriteTextAsync(localFile, JsonData);

        }

        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            String jsonData = await FileIO.ReadTextAsync(localFile);
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonData);
        }
        
        
    }
}
