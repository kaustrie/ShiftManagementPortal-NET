using System;
using System.Collections.Generic;
using System.Text;
using ShiftManagementPortal.Infrastructure.Data;

namespace ShiftManagementPortal.Infrastructure
{
    public class SqlBase
    {
        private readonly IDatabaseContext _context;
        public SqlBase(IDatabaseContext context)
        {
            _context = context;
        }

        public IDatabaseContext DatabaseContext => _context;
    }
}
