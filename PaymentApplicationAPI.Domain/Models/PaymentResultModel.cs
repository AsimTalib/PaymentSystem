namespace PaymentApplicationAPI.Domain.Models
{
    public class PaymentResultModel
    {
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public PaymentResultModel() 
        {
            Success = false;
            Message = "Payment could not be processed";
        }
   
    }
}