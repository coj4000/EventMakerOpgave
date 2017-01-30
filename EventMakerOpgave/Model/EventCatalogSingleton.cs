using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            EventCollection.Add(new Event(1, "Event 1", "Den første event i verdenshistorien", "Ønskeøen", DateTime.Now));
        }

        public void AddEvent(Event EventTilAdd)
        {
            EventCollection.Add(EventTilAdd);
        }

    }
}
