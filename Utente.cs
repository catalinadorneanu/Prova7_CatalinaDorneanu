using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova7_CatalinaDorneanu
{
    class Utente
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Utente(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
