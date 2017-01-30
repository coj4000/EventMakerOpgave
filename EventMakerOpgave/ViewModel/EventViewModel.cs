using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.Model;

namespace EventMakerOpgave.ViewModel
{
    class EventViewModel
    {
        private ObservableCollection<Event> eventCollection;

        public ObservableCollection<Event> EventCollection
        {
            get { return EventCollection; }
            set { EventCollection = value; }
        }

        public EventViewModel()
        {

        }


    }
}
