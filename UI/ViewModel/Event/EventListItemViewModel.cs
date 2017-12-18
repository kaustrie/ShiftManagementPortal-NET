using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagementPortal.UI.ViewModel.Event
{
    public class EventListItemViewModel
    {
        public EventListItemViewModel() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
