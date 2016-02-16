using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramaApp1
{
    public class Book
    {
        private string Number;

        public string BookNumber
        {
            get { return Number; }
            set { Number = value; }
        }
        
        private string Name;

        public string BookName
        {
            get { return Name; }
            set { Name = value; }
        }
    }
}
