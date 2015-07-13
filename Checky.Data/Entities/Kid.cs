using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checky.Data.Entities
{
    public partial class Kid
    {
        public Kid()
        {
            Parents = new List<Parent>();
        }
        public int Id { get; set; }

        public int UserUnitId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Parent> Parents { get; set; }

    }
}
