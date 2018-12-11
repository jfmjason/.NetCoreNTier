using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BA.Core.Entity
{
    [Table("PatientType", Schema ="MASTER")]
    public class PatientType :BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }
}
