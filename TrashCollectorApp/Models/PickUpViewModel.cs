using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorApp.Models
{
    public class PickUpViewModel
    {
        public Customer Customer { get; set; }
        public List<PickUp> PickUps { get; set; }
    }
}
