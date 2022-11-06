﻿using System;
using System.Collections.Generic;

namespace _NET_Office_Management_BackEnd.Models
{
    public partial class Leave
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public bool Approved { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint DayCount { get; set; }
        public string Comment { get; set; } = null!;
        public int ApproverId { get; set; }
        public int UserId { get; set; }

        public virtual User Approver { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
