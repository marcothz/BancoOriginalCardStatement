namespace OriginalCardStatementParser.Models
{
    internal class StatementEntry
    {
        public StatementEntry(int order, DateTime createdAt, string description, decimal amount, bool isRefund, string cardDescription, string category)
        {
            Order = order;
            CreatedAt = createdAt;
            Description = description;
            Amount = amount;
            IsRefund = isRefund;
            CardDescription = cardDescription;
            Category = category;
        }

        public decimal Amount { get; }

        public string CardDescription { get; }

        public string Category { get; }

        public DateTime CreatedAt { get; }

        public string Description { get; }

        public bool IsRefund { get; set; }

        public int Order { get; set; }
    }
}