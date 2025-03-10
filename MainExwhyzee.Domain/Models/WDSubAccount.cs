﻿using static MainExwhyzee.Domain.Models.Enum;

namespace MainExwhyzee.Domain.Models
{
    public class WDSubAccount
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string MainUrl { get; set; }
        public string OtherUrl { get; set; }

        public string Email { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateExpiring { get; set; }
        public DateTime DateRenewed { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int Interval { get; set; }
        public AccontStatus AccontStatus { get; set; }
        public TypeOfAccount TypeOfAccount { get; set; }

        public long? WDAccountId { get; set; }
        public WDAccount WDAccount { get; set; }

    }
}