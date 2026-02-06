namespace FoodDelivery.Entity{
    public class OrderItem
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string RequiredStationType { get; set; } // Grill, Fryer, Salad
        public int PreparationTimeSeconds { get; set; }
    }
}
