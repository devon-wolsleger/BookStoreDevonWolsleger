using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDevonWolsleger.Models
{
    public interface IBooksRepository
    {
        IQueryable<Books> Bookss { get; set; }

        void SaveBooks(Books books);
    }
}
