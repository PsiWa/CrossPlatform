using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SereginLab1.Models
{
    public class DbEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public decimal Age { get; set; }
    }
}
