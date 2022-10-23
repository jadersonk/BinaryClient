namespace BinaryClient.JSONTypes
{
    public class TickStreamRequest
    {
        public string ticks { get; set; }
        public int subscribe { get { return 1; }}

        
    }

    public class TickStreamResponse
    {
        public EchoReqTickStream echo_req { get; set; }
        public string msg_type { get; set; }
        public TickSubscriptionInformation subscription { get; set; }

        public TickSpotData ticks { get; set; }

    }

    public class TickSubscriptionInformation
    {
        public string id { get; set; }

    }

    public class TickSpotData
    {
        public decimal ask { get; set; }

        public decimal bid { get; set; }

        public decimal epoch { get; set; }
        public string id { get; set; }
        public decimal pip_size { get; set; }
        public decimal quote { get; set; }
        public string symbol { get; set; }

    }

    public class EchoReqTickStream
    {
        public int ticks { get; set; }
        public int subscribe { get; set; }
    }
}