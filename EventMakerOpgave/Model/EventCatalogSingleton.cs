using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.Persistency;
using System.Diagnostics;

namespace EventMakerOpgave.Model
{

    class EventCatalogSingleton
    {

        const String fileEvent = "savedFileEvent.json";
        const String fileHistorik = "savedFileHistorik.json";

        private static readonly EventCatalogSingleton instance = new EventCatalogSingleton();

        public static EventCatalogSingleton Instance
        {
            get { return instance; }
        }


        public ObservableCollection<Event> EventCollection { get; set; }
        public ObservableCollection<Event> HistorikCollection { get; set; }

        private EventCatalogSingleton()
        {
            EventCollection = new ObservableCollection<Event>();
            HistorikCollection = new ObservableCollection<Event>();
            LoadJson();
        }

        public void AddEvent(Event EventTilAdd)
        {
            EventCollection.Add(EventTilAdd);
            PersistencyService.SaveEventAsJsonAsync(fileEvent, EventCollection);
        }

        public void RemoveEvent(Event EventTilRemove)
        {
            if(EventTilRemove != null)
            {
            EventCollection.Remove(EventTilRemove);
            HistorikCollection.Add(EventTilRemove);
            PersistencyService.SaveEventAsJsonAsync(fileEvent, EventCollection);
            PersistencyService.SaveEventAsJsonAsync(fileHistorik, HistorikCollection);
            }
        }

        public void RemoveFraHistorik(Event EventTilRemove)
        {
            HistorikCollection.Remove(EventTilRemove);
            PersistencyService.SaveEventAsJsonAsync(fileHistorik, HistorikCollection);
        }

        public void ClearHistorik()
        {
            if(HistorikCollection.Count > 0)
            {
                HistorikCollection.Clear();
                PersistencyService.SaveEventAsJsonAsync(fileHistorik, HistorikCollection);
            }
        }

        public void RestoreEvent(Event EventTilRestore)
        {
            if(EventTilRestore != null)
            {
            EventCollection.Add(EventTilRestore);
            HistorikCollection.Remove(EventTilRestore);
            PersistencyService.SaveEventAsJsonAsync(fileEvent, EventCollection);
            PersistencyService.SaveEventAsJsonAsync(fileHistorik, HistorikCollection);
            }
        }

        private async void LoadJson()
        {
            try
            {
            EventCollection = await PersistencyService.LoadEventsFromJsonAsync(fileEvent);
            HistorikCollection = await PersistencyService.LoadEventsFromJsonAsync(fileHistorik);
            } catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
