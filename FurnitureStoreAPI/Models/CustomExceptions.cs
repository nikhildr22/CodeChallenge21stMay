using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Models
{
    public class DuplicatePhoneNumberException : Exception
    {
        public DuplicatePhoneNumberException() : base("Phone number Already Exists")
        {

        }
        public DuplicatePhoneNumberException(string phone) : base($"Phone number - [{phone}] Already Exists in Database\nTry with Other Phone number!!")
        {

        }


    }
}
