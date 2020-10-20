using DotNetDemo.Business.Enums.General;

namespace DotNetDemo.Business.Models.General
{
    public class DropMessage
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of message.
        /// </summary>
        public DropMessageType DropMessageType { get; set; }
    }
}
