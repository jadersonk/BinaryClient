namespace BinaryClient.JSONTypes
{
    public class ForgetAllRequest
    {
        public string forget_all { get; set; }

        
    }

    public class ForgetAllResponse
    {
        public EchoReqForgetAll echo_req { get; set; }
        public string[] forget_all { get; set; }
        public string msg_type { get; set; }
    }

    public class EchoReqForgetAll
    {
        public string forget_all { get; set; }
    }
}