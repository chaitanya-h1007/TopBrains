//These are the predifened things in the program
namespace FoodDelivery.Enum
{
    public enum OrderStatus
    {
        Created, //Used when an order is creates
        PaymentPending, //Check for Payment Processing
        PaymentProcessing,
        PaymentFailed, 
        PaymentSuccessful,
        RestaurantAccepted,
        RestaurantPreparing,
        RestaurantReady,
        DriverAssigned,
        DriverPickedUp,
        OutForDelivery,
        Delivered,
        Cancelled,
        Refunded

    }

}
