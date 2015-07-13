using Checky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checky.Data.Repositories
{
    public class CheckyRepository : ICheckyRepository
    {
        private CheckyContext _ctx;

        public CheckyRepository(CheckyContext ctx)
        {
            _ctx = ctx;
            _ctx.Configuration.LazyLoadingEnabled = true;
        }

        public IQueryable<Kid> GetKids()
        {
            return _ctx.Kids;
        }

        public Kid GetKid(int id)
        {
            return _ctx.Kids.FirstOrDefault(k => k.Id == id);
        }
        
        public IQueryable<Parent> GetParents()
        {
            return _ctx.Parents;
        }

        public RepositoryActionResult<Kid> AddKid(Kid kid)
        {
            try
            {
                _ctx.Kids.Add(kid);
                var result =_ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Kid>(kid, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Kid>(kid, RepositoryActionStatus.NothingModified);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Kid>(kid, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Parent> AddParent(Parent parent)
        {
            try
            {
                _ctx.Parents.Add(parent);
                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Parent>(parent, RepositoryActionStatus.Created);
                }
                else
                {
                    return  new RepositoryActionResult<Parent>(parent, RepositoryActionStatus.NothingModified);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Parent>(parent, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Kid> UpdateKid(Kid kid)
        {
            try
            {
                // you can only update when an expense already exists for this id

                var existingKid = _ctx.Kids.FirstOrDefault(k => k.Id == kid.Id);

                if (existingKid == null)
                {
                    return new RepositoryActionResult<Kid>(kid, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                _ctx.Entry(existingKid).State = EntityState.Detached;

                // attach & save
                _ctx.Kids.Attach(kid);

                // set the updated entity state to modified, so it gets updated.
                _ctx.Entry(kid).State = EntityState.Modified;


                var result = _ctx.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Kid>(kid, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Kid>(kid, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Kid>(null, RepositoryActionStatus.Error, ex);
            }

        }
    }
}
