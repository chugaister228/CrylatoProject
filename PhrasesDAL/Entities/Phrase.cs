﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhrasesDAL.Entities
{
    public class Phrase
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Likes { get; set; }

        public int Id { get; set; }

        public int TagId { get; set; }
    }
}
