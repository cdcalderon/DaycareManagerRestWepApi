
using Checky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checky.Data.Factories
{
    public class KidFactory
    {
        public DTO.Kid CreateKid(Kid kid)
        {
            return new DTO.Kid
            {
                Id = kid.Id,
                UserUnitId = kid.UserUnitId,
                FirstName = kid.FirstName,
                LastName = kid.LastName
            };
        }

        public Kid CreateKid(DTO.Kid kid)
        {
            return new Kid
            {
                Id = kid.Id,
                UserUnitId = kid.UserUnitId,
                FirstName = kid.FirstName,
                LastName = kid.LastName
            };
        }
    }
}
