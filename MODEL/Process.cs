using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProcKill.MODEL
{
    [XmlRoot("ProcessList")]
    public class ProcessList
    {
        List<ProcessItem> _items;
        
        [XmlElement("Process")]
        public List<ProcessItem> Items
        {
          get { return _items; }
          set { _items = value; }
        }
    }

    public class ProcessItem
    {
        private string _name;

        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
