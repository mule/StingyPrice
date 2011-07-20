﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StingyPrice.DAL.Models;

namespace StingyPrice.Models
{
    public abstract class ModelBase : IModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}