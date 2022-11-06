using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _NET_Office_Management_BackEnd.Models
{
    public class Asset
    {
        public Asset()
        {
            AssetHistories = new HashSet<AssetHistory>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Serial { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }
        public ulong Warranty { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; } = null!;
        public ushort Type { get; set; }
        public ushort Status { get; set; }
        public int UserId { get; set; }
        public int? NextUserId { get; set; }
        public virtual User? NextUser { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<AssetHistory> AssetHistories { get; set; }
    }
}
