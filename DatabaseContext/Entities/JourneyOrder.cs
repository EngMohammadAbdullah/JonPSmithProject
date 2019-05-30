﻿using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class JourneyOrder : EntityBase
    {
        public Guid OrderKey { get; set; }
        public Guid JourneyKey { get; set; }
        public Journey Journey { get; set; }
        public Order Order { get; set; }

    }
}
