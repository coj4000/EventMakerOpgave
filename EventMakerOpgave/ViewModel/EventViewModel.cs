using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.Model;
using System.Windows.Input;
using EventMakerOpgave.Common;

namespace EventMakerOpgave.ViewModel
{
    class EventViewModel
    {
        //Handler
        public Handler.EventHandler EventHandler { get; set; }

        //ICommand props
        public ICommand CreateEventCommand { get; set; }

        //Props
        private ObservableCollection<Event> eventCollection;
        public ObservableCollection<Event> EventCollection
        {
            get { return eventCollection; }
            set { eventCollection = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string place;
        public string Place
        {
            get { return place; }
            set { place = value; }
        }

        private DateTimeOffset date;
        public DateTimeOffset Date
        {
            get { return date; }
            set { date = value; }
        }

        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }


        public EventViewModel()
        {
            EventCollection = new ObservableCollection<Event>();
            EventCollection = EventCatalogSingleton.Instance.EventCollection;

            EventHandler = new Handler.EventHandler(this);

            DateTime dt = System.DateTime.Now; 
            date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            CreateEventCommand = new RelayCommand(EventHandler.CreateEvent, null);

        }


    }
}
