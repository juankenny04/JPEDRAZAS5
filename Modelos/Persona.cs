using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana5.Modelos
{
   
        [Table("persona")]
        public class Persona
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
        public int ID { get; internal set; }
        [MaxLength(25), Unique]
            public string Name { get; set; }
        }
    
}
