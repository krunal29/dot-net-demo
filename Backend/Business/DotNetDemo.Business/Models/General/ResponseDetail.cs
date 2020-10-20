using DotNetDemo.Business.Enums.General;

namespace DotNetDemo.Business.Models.General
{
    public class ResponseDetail
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public object Data { get; set; }

        public DropMessageType MessageType { get; set; }
    }
}