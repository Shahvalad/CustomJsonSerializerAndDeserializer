using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJsonSerializerDeseri.Models
{
    public class Root
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Email { get; set; }
        public Login Login { get; set; }
        public Dob Dob { get; set; }
        public Registered Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public Id Id { get; set; }
        public Picture Picture { get; set; }
        public string Nat { get; set; }
    }
}
