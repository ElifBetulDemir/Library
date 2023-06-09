using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BorrowService 
    {
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public void BorrowBook()
        {
            BorrowDate = DateTime.Now;
        }
        public void ReturnBook()
        {
            ReturnDate = DateTime.Now;
        }
       
    }
}
