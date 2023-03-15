using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDevonWolsleger.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BookstoreContext context;
        public EFBooksRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Books> Bookss => context.Bookss.Include(x => x.Lines).ThenInclude(x => x.Book);

        IQueryable<Books> IBooksRepository.Bookss { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SaveBooks(Books books)
        {
            context.AttachRange(books.Lines.Select(x => x.Book));

            if (books.BooksId == 0)
            {
                context.Bookss.Add(books);
            }

            context.SaveChanges();
        }
    }
}
