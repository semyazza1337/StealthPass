using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StealthPass.Classes
{
    public class Credentials
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public override string ToString()
        {
            return $"| {Site} | {Email} | {Pass} |";
        }
    }
}
