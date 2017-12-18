using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShiftManagementPortal.Core.Domain.Model;
using ShiftManagementPortal.Core.Repository;
using ShiftManagementPortal.Infrastructure.Data;

namespace ShiftManagementPortal.Infrastructure.Repositories
{
    public class VenueRepository: SqlBase, IVenueRepository
    {
        public VenueRepository(IDatabaseContext context) : base(context)
        {
            
        }

        public Venue GetById(object id)
        {
            return DatabaseContext.Venues.SingleOrDefault(x => x.Id == (long) id);
        }

        public IEnumerable<Venue> GetAll()
        {
            throw new NotImplementedException();
        }

        public Venue Add(Venue item)
        {
            throw new NotImplementedException();
        }

        public void Update(Venue item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Venue item)
        {
            throw new NotImplementedException();
        }
    }
}
