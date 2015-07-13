
using Checky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checky.Data.Repositories
{
    public interface ICheckyRepository
    {
        IQueryable<Kid> GetKids();

        IQueryable<Parent> GetParents();

        RepositoryActionResult<Kid> AddKid(Kid kid);

        RepositoryActionResult<Parent> AddParent(Parent parent);

        Kid GetKid(int id);

        RepositoryActionResult<Kid> UpdateKid(Kid kid);
    }
}
