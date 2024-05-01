namespace App.Domain.Entities
{
    public class Message : Base {
        public Message()
        {
            
        }
        public Message(string body, DateTime insertedDate)
        {
            Body = body;
            InsertedDate = insertedDate;
        }

        public string? Body { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}