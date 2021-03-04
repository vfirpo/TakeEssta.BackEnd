using System.Collections.Generic;

namespace TakeEssta.Model
{
    public class Users
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string NormalizedNickName {
            get { return this.NickName.ToUpper(); }
            set { }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

		public string Password { get; set; }

        public string Sal { get; set; }

        public Sucursal Sucursal { get; set; }

        public IList<Roles> Roles { get; set; }

        public IList<Behaviours> Behaviours { get; set; }

    }
}