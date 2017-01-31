using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.ViewModel;
using EventMakerOpgave.Model;
using EventMakerOpgave.Converter;

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
            EventCatalogSingleton.Instance.AddEvent(new Event(EventViewModel.Id, EventViewModel.Name, EventViewModel.Description, EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time)));
        }

    }
}
