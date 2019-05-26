namespace MoqDemo_001
{
    public interface IOrderService
    {
        SubmitOrderResponse Submit(SubmitOrderRequest request);
    }
}