namespace BinaryClient.JSONTypes
{
    public class Ping
    {
        public int ping
        {
            get { return 1; }
        }

        public class PingResponse
        {
            public EchoReqPing echo_req { get; set; }
            public string msg_type { get; set; }
            public string ping { get; set; }
            
        }

        public class EchoReqPing
        {
            public int ping { get; set; }
        }
    }

}