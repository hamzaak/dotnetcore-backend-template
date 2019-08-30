using Ponente.Entity.Enums;
using System;
using System.Collections.Generic;

namespace Ponente.Entity.DTO
{
    public class TransactionRequestDTO
    {
        public int AccountId { get; set; }
        public List<DateTime> Date { get; set; }
        public List<decimal> Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
