﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCHCL.Day1.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public short Duration { get; set; }
        public double Signupfee { get; set; }
        public short Discount { get; set; }
    }
}