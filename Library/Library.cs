using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Library
    {
        private List<Book> bookList;
        private List<Customer> customerList;
        private List<BorrowService> borrowList;

        public Library()
        {
            bookList = new List<Book>();
            customerList = new List<Customer>();
            borrowList = new List<BorrowService>();
        }
        public void AddBook(Book book)
        {
            bookList.Add(book);
        }
        public void AddCustomer(Customer customer)
        {
            customerList.Add(customer);
        }
        public void RemoveBook(Book book)
        {
            bookList.Remove(book);
        }
        public void RemoveCustomer(Customer customer)
        {
            customerList.Remove(customer);
        }
        public void BorrowBook(Book book, Customer customer)
        {
            if (bookList.Contains(book) && customerList.Contains(customer))
            {
                BorrowService borrow = new BorrowService() { Book = book, Customer = customer };
                borrow.BorrowBook();
                borrowList.Add(borrow);
                RemoveBook(book);
                Console.WriteLine($"{book.BookTitle} is borrowed by {customer.Name}");
            }
            else
            {
                Console.WriteLine("Customer or book not found !");
            }
        }
        public void ReturnBook(Book book, Customer customer)
        {
            foreach (BorrowService borrow in borrowList)
            {
                if (borrow.Book == book && borrow.Customer == customer)
                {
                    borrow.ReturnBook();
                    borrowList.Remove(borrow);
                    AddBook(book);
                    Console.WriteLine($"{book.BookTitle} is returned by {customer.Name}");
                    return;
                }
            }
            Console.WriteLine($"Borrowed book with this title was not found.");
        }
        public void GetBorrowedBookList(Customer customer)
        {
            bool isBorrowed = false;
            foreach (BorrowService borrow in borrowList)
            {
                if (borrow.Customer == customer)
                {
                    Console.WriteLine(borrow);
                    isBorrowed = true;
                }
            }
            if (!isBorrowed)
            {
                Console.WriteLine("Customer did not borrow any book!");
            }
        }
    }
}
