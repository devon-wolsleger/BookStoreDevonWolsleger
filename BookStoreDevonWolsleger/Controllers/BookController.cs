using BookStoreDevonWolsleger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDevonWolsleger.Controllers
{
    public class BookController : Controller
    {
        private IBooksRepository repo { get; set; }
        private Basket basket {get;set;}
        public BookController (IBooksRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Books());
        }

        [HttpPost]
        public IActionResult Checkout(Books books)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                books.Lines = basket.Items.ToArray();
                repo.SaveBooks(books);
                basket.ClearBasket();

                return RedirectToPage("/SaleCompleted");
            }

            else
            {
                return View();
            }
        }
    }
}
