namespace _NET_Office_Management_BackEnd.ResponseModels
{
    public class LeaveSummaryResponseModel
    {
        public int user { get; set; }
        public string? first_name { get; set; } = String.Empty;
        public string? last_name { get; set; } = String.Empty;
        public long? days { get; set; }
    }
}