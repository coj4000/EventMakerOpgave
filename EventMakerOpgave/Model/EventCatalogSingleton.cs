using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.Persistency;

namespace EventMakerOpgave.Model
{

    class EventCatalogSingleton
    {

        private static readonly EventCatalogSingleton instance = new EventCatalogSingleton();

        public static EventCatalogSingleton Instance
        {
            get { return instance; }
        }


        public ObservableCollection<Event> EventCollection { get; set; }

        private EventCatalogSingleton()
        {
            EventCollection = new ObservableCollection<Event>();
            LoadJson();
        }

        public void AddEvent(Event EventTilAdd)
        {
            EventCollection.Add(EventTilAdd);
            PersistencyService.SaveEventAsJsonAsync();
        }

        public void RemoveEvent(Event EventTilRemove)
        {
            EventCollection.Remove(EventTilRemove);
            PersistencyService.SaveEventAsJsonAsync();
        }

        private async void LoadJson()
        {
            EventCollection = await PersistencyService.LoadEventsFromJsonAsync();
        }
    }
}
