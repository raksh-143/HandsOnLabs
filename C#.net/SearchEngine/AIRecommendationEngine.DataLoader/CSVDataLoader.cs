using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecommendationEngine.Common.Entities;

namespace RecommendationEngine.DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        private static List<User> Users;
        private static List<BookUserRating> BookUserRatings;
        private static List<Book> Books;
        public BookDetails Load()
        {
            Parallel.Invoke(LoadUsers,LoadBookUserRatings,LoadBooks);
            AssociateRatingToBook();
            AssociateRatingToUser();
            BookDetails bookDetails = new BookDetails();
            bookDetails.Users = Users;
            bookDetails.BookUserRatings = BookUserRatings;
            bookDetails.Books = Books;
            return bookDetails;
        }

        private void AssociateRatingToBook()
        {
            Parallel.ForEach(Books,book=>
            {
                string curBookISBN = book.ISBN;
                List<BookUserRating> curBookUserRatings = new List<BookUserRating>();
                foreach(BookUserRating bur in BookUserRatings)
                {
                    if(bur.ISBN == curBookISBN)
                    {
                        bur.Book = book;
                        curBookUserRatings.Add(bur);
                    }
                }
                book.BookUserRatings = curBookUserRatings;
            });
        }

        private void AssociateRatingToUser()
        {
            Parallel.ForEach(Users, user =>
            {
                string curUserID = user.UserID;
                List<BookUserRating> curUserRatings = new List<BookUserRating>();
                foreach (BookUserRating bur in BookUserRatings)
                {
                    if (bur.UserID == curUserID)
                    {
                        bur.User = user;
                        curUserRatings.Add(bur);
                    }
                }
                user.BookUserRatings = curUserRatings;
            });
        }

        private static void LoadUsers()
        {
            List<User> users = new List<User>();
            StreamReader reader = new StreamReader("C:\\Users\\Adnim\\source\\repos\\SearchEngine\\AIRecommendationEngine.DataLoader\\Data\\BX-Users.csv");
            try
            {
                reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    string user = reader.ReadLine();
                    string[] curUser = user.Split(';');
                    Parallel.For(0, curUser.Length, i =>
                    {
                        curUser[i] = curUser[i].Trim('"');
                    });
                    User curUserObj = new User();
                    curUserObj.UserID = curUser[0];
                    curUserObj.Age = int.Parse(curUser[2]);
                    string[] curUserLoc = curUser[1].Split(',');
                    Parallel.For(0, curUserLoc.Length, i =>
                    {
                        curUserLoc[i] = curUserLoc[i].Trim();
                    });
                    curUserObj.City = curUserLoc[0];
                    curUserObj.State = curUserLoc[1];
                    curUserObj.Country = curUserLoc[2];
                    users.Add(curUserObj);
                }
                Users = users; 
            }
            finally
            {
                reader.Close();
            }
        }
        private static void LoadBookUserRatings()
        {
            List<BookUserRating> bookUserRatings= new List<BookUserRating>();
            StreamReader reader = new StreamReader("C:\\Users\\Adnim\\source\\repos\\SearchEngine\\AIRecommendationEngine.DataLoader\\Data\\BX-Book-Ratings.csv");
            try
            {
                reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    string bookData = reader.ReadLine();
                    string[] curUser = bookData.Split(';');
                    Parallel.For(0, curUser.Length, i =>
                    {
                        curUser[i] = curUser[i].Trim('"');
                    });
                    BookUserRating bur = new BookUserRating();
                    bur.UserID = curUser[0];
                    bur.ISBN = curUser[1];
                    bur.Rating = int.Parse(curUser[2]);
                    bookUserRatings.Add(bur);
                }
                BookUserRatings = bookUserRatings;
            }
            finally
            {
                reader.Close();
            }
        }
        private static void LoadBooks()
        {
            List<Book> books = new List<Book>();
            StreamReader reader = new StreamReader("C:\\Users\\Adnim\\source\\repos\\SearchEngine\\AIRecommendationEngine.DataLoader\\Data\\BX-Books.csv");
            try
            {
                reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    string book = reader.ReadLine();
                    string[] curBook = book.Split(';');
                    Book thisBook = new Book();
                    Parallel.For(0, curBook.Length, i =>
                    {
                        curBook[i] = curBook[i].Trim('"');
                    });
                    thisBook.ISBN = curBook[0];
                    thisBook.BookTitle = curBook[1];
                    thisBook.BookAuthor = curBook[2];
                    thisBook.YearOfPublcation = curBook[3];
                    thisBook.Publisher = curBook[4];
                    thisBook.ImageUriSmall = curBook[5];
                    thisBook.ImageUriMedium = curBook[6];
                    thisBook.ImageUriLarge = curBook[7];
                    books.Add(thisBook);
                }
                Books = books;
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
