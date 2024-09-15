using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBlog.Core.SeedWork;

namespace TechBlog.Data.SeedWork
{
    public class UnitOFWork : IUnitOfWork
    {
        private readonly TechBlogContext _context;
        public UnitOFWork(TechBlogContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
           return  await _context.SaveChangesAsync();  
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
