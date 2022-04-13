namespace OriginalCardStatementParser.Models
{
    internal class StatementEntry
    {
        public int Order { get; set; }

        public DateTime CreatedAt { get; }

        public string Description { get; }

        public decimal Amount { get; }

        public string CardDescription { get; }

        public string Category { get; }

        public StatementEntry(int order, DateTime createdAt, string description, decimal amount, string cardDescription, string category)
        {
            Order = order;
            CreatedAt = createdAt;
            Description = description;
            Amount = amount;
            CardDescription = cardDescription;
            Category = category;
        }
    }
}