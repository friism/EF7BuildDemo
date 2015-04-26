using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildDemo
{
    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime DueBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RequestedBy { get; set; }
        public string AssignedTo { get; set; }

        public List<Note> Notes { get; set; }
    }
}
