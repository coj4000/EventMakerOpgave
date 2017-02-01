using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.Model;
using Windows.Storage;
using Newtonsoft.Json;

namespace EventMakerOpgave.Persistency
{
    class PersistencyService
    {

        const String fileName = "savedFile.json";

        public static async void SaveEventAsJsonAsync()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string JsonData = JsonConvert.SerializeObject(EventCatalogSingleton.Instance.EventCollection);
            await FileIO.WriteTextAsync(localFile, JsonData);

        }

        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            String jsonData = await FileIO.ReadTextAsync(localFile);
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonData);
        }
        
        
    }
}
