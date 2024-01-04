using _Subject.Models;
using Microsoft.EntityFrameworkCore;

namespace _Subject
{
    public interface ISubjetContext
    {
        DbSet<Subjet> Subjets { get; set; }

        void SaveChanges();
    }
}
