using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem
{
    internal class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            return $"Book: {Name}, Author: {Author}, Genre: {Genre}, Release Date: {ReleaseDate.ToShortDateString()}";
        }
    }
}
