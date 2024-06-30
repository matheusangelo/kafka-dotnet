using App.Domain.Enums;

namespace App.Domain.Entities
{
    public class Message : Base {
        
        public string? Body { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public EnumMessageStatus Status { get; set; }

        public Message()
        {
            
        }
        public Message(
                       string? body,
                       DateTime insertedDate,
                       DateTime updatedDate,
                       EnumMessageStatus status)
        {
            Body = body;
            InsertedDate = insertedDate;
            UpdatedDate = updatedDate;
            Status = status;
        }

        public Message(string? body, DateTime insertedDate, DateTime updatedDate)
        {
            Body = body;
            InsertedDate = insertedDate;
            UpdatedDate = updatedDate;
            Status = EnumMessageStatus.Created;
        }
    }
}