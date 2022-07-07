using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Application.Exceptions
{
    public class MyException : Exception
    {
        public MyException() : base("My error occured")
        {

        }
        public MyException(string message) : base(message)
        {

        }
        public MyException(Exception exception) : this(exception.Message)
        {

        }
    }
}
