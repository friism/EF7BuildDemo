using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildDemo
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Added { get; set; }

        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
    }
}
