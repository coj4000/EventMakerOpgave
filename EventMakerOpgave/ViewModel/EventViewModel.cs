using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMakerOpgave.Model;
using System.Windows.Input;
using EventMakerOpgave.Common;
using System.ComponentModel;

namespace EventMakerOpgave.ViewModel
{
    class EventViewModel : INotifyPropertyChanged
    {
        //Handler
        public Handler.EventHandler EventHandler { get; set; }

        //ICommand props
        public ICommand CreateEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public ICommand DeleteHistorikCommand { get; set; }
        public ICommand ClearHistorikCommand { get; set; }
        public ICommand RestoreEventCommand { get; set; }

        //Props
        private ObservableCollection<Event> eventCollection;
        public ObservableCollection<Event> EventCollection
        {
            get { return eventCollection; }
            set { eventCollection = value; }
        }

        private ObservableCollection<Event> historikCollection;
        public ObservableCollection<Event> HistorikCollection
        {
            get { return historikCollection; }
            set { historikCollection = value; }
        }


        private int id;
        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string place;
        public string Place
        {
            get { return place; }
            set { place = value;
                OnPropertyChanged(nameof(Place));
            }
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

        private Event selectedEvent;
        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set { selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }


        public EventViewModel()
        {
            EventCollection = new ObservableCollection<Event>();
            EventCollection = EventCatalogSingleton.Instance.EventCollection;

            HistorikCollection = new ObservableCollection<Event>();
            historikCollection = EventCatalogSingleton.Instance.HistorikCollection;

            EventHandler = new Handler.EventHandler(this);

            DateTime dt = System.DateTime.Now; 
            date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            CreateEventCommand = new RelayCommand(EventHandler.CreateEvent, null);
            DeleteEventCommand = new RelayCommand(EventHandler.DeleteEvent, EventHandler.CanDeleteEvent);
            DeleteHistorikCommand = new RelayCommand(EventHandler.DeleteHistorik, EventHandler.canRemoveHistorik);
            ClearHistorikCommand = new RelayCommand(EventHandler.ClearHistorik, EventHandler.canRemoveHistorik);
            RestoreEventCommand = new RelayCommand(EventHandler.RestoreEvent, EventHandler.canRemoveHistorik);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
