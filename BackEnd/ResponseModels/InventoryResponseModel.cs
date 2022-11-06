namespace _NET_Office_Management_BackEnd.ResponseModels
{
    public class InventoryResponseModel
    {
        public int id { get; set; }
        public string name { get; set; } = String.Empty;
        public string unit { get; set; } = String.Empty;
        public uint count { get; set; }
        public string description { get; set; } = String.Empty;
    }
}
