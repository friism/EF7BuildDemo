using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace BuildDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DemoContext())
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                // INSERT
                ctx.WorkOrders.Add(new WorkOrder
                {
                    WorkOrderId = 1,
                    Title = "WorkOrder1",
                    AssignedTo = "Rowan",
                    Notes = new List<Note> {
                        new Note { NoteId = 1, Author="Shay" },
                        new Note { NoteId = 2, Author="Jim" }
                    }
                });

                ctx.WorkOrders.Add(new WorkOrder {
                    WorkOrderId = 2,
                    Title = "WorkOrder2",
                    AssignedTo = "Andrew",
                    Notes = new List<Note> {
                        new Note { NoteId = 3, Author="Jackie" },
                        new Note { NoteId = 4, Author="John" }
                    }
                });

                ctx.SaveChanges();

                // ITERATE OVER ALL
                foreach (var o in ctx.WorkOrders) {
                    Console.WriteLine(o.Title);
                }

                // WHERE
                var rowanOrders = ctx.WorkOrders.Where(o => o.AssignedTo == "Rowan").ToList();
                foreach (var o in rowanOrders)
                {
                    Console.WriteLine("Rowan order: " + o.Title);
                }

                // UPDATE
                rowanOrders.Single().Title = "WorkOrder3";
                ctx.SaveChanges();

                Console.WriteLine(ctx.WorkOrders.Single(o => o.Title == "WorkOrder3").WorkOrderId);

#if MARS_SEEMS_TO_BE_REQUIRED
                // INCLUDE
                var includeAll = ctx.Set<WorkOrder>().Include(o => o.Notes).ToList();
                Console.WriteLine("COUNT: " + includeAll.Count);

                foreach (var o in includeAll)
                {
                    Console.WriteLine("Work order " + o.WorkOrderId);
                    foreach (var n in o.Notes)
                        Console.WriteLine("  Note by: " + n.Author);
                }
#endif
            }
        }
    }
}
