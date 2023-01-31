﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Categories")]
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
