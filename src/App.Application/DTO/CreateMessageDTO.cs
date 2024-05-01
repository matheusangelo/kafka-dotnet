namespace App.Application
{
    public class CreateMessageDTO
    {
        public CreateMessageDTO(string body)
        {
            Body = body;
        }

        public string Body { get; set; }
    }
}