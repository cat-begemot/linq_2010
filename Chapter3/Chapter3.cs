using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter3
{
    class Chapter3
    {
        static void Main(string[] args)
        {
	        IEnumerable<string> data = new[] {"First", "Second", "Third"};

            foreach(var item in data)
	            Console.WriteLine(item);

       
        }
    }
}
