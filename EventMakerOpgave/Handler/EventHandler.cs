using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.ViewModel;
using EventMakerOpgave.Model;
using EventMakerOpgave.Converter;
using EventMakerOpgave.Persistency;

namespace EventMakerOpgave.Handler
{

    class EventHandler
    {

        public EventViewModel EventViewModel { get; set; }

        public EventHandler(EventViewModel evm)
        {
            this.EventViewModel = evm;
        }

        public void CreateEvent()
        {
            Event tempEvent = new Event(EventViewModel.Id, EventViewModel.Name, EventViewModel.Description, EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time));

            EventCatalogSingleton.Instance.AddEvent(tempEvent);
        }

        public void DeleteEvent()
        {
            EventCatalogSingleton.Instance.RemoveEvent(EventViewModel.SelectedEvent);
        }

        public bool CanDeleteEvent()
        {
            return EventCatalogSingleton.Instance.EventCollection.Count > 0;
        }

        //Historik
        public void DeleteHistorik()
        {
            EventCatalogSingleton.Instance.RemoveFraHistorik(EventViewModel.SelectedEvent);
        }

        public void ClearHistorik()
        {
            EventCatalogSingleton.Instance.ClearHistorik();
        }

        public void RestoreEvent()
        {
            EventCatalogSingleton.Instance.RestoreEvent(EventViewModel.SelectedEvent);
        }

        public bool canRemoveHistorik()
        {
                return EventCatalogSingleton.Instance.HistorikCollection.Count > 0;
        }

    }
}
