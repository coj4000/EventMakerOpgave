using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMakerOpgave.Model
{
    class Event
    {

        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Place { get; set; }
        public DateTime DateTime { get; set; }

        public Event(int ID, String Name, String Description, String Place, DateTime DateTime)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Place = Place;
            this.DateTime = DateTime;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
