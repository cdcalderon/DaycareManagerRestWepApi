using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checky.Data.Entities
{
    public partial class Parent
    {
        public Parent()
        {
            Kids = new List<Kid>();
        }
        public int Id { get; set; }

        public int UserUnitId { get; set; }

        public int FirstName { get; set; }

        public int LastName { get; set; }

        public virtual ICollection<Kid> Kids{ get; set; }
    }
}
