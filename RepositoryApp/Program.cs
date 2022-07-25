using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace RepositoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"data.txt";
            Repository rep = new Repository(path);
            rep.Choose1();

        }
    }
}

