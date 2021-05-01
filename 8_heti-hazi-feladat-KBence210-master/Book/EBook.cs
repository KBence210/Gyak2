using System;
using System.Collections.Generic;
using System.Text;

namespace myproducts
{
	/*
Az EBook osztály definíciója változatlan.
	bemasolni az elozo hetit
     */
	public class EBook : Book
    {
        private string url;

        public EBook(string author, string name, int price, int pages, string style, string url) : base(author, name, price, pages, style)
        {
            this.url = url;
        }

        public string Url
        {
            get => url;
            set => url = value;
        }

        public override string ToString()
        {
            return base.ToString() + $" url: {url}";
        }

    }
}
