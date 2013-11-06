using Newtonsoft.Json.Linq;
using Organibook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Organibook.Util
{
    public class BookFetcher
    {
        public String Key { get; set; }

        //Get book information from isbndb web service
        public Book getBook(String isbn)
        {
            WebClient client = new WebClient();
            String json = client.DownloadString("http://isbndb.com/api/v2/json/" + Key + "/book/" + isbn);
            dynamic bookData = JObject.Parse(json);
            return new Book
                {
                    Author = bookData.data[0].author_data[0].name,
                    Name = bookData.data[0].title,
                    Publisher = bookData.data[0].publisher_name,
                    Isbn = bookData.data[0].isbn10
                };
        }
    }
}