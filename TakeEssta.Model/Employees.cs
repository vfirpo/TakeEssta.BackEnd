using System;
using System.Collections.Generic;
using System.Text;

namespace TakeEssta.Model
{
    public class Employees
    {
        public int Id { get; set; }

        public string Nick { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime BirthDate { get; set; }

        public string Adress { get; set; }

        public int CorX { get; set; }

        public int CorY { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public Sucursal Sucursal { get; set; }



    }
}
