namespace PaymentApplicationAPI.Domain.Models
{
    public class MemberResultModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public MemberResultModel() 
        {
            Success = false;
            Message = "Member could not be processed";
        }
   
    }
}