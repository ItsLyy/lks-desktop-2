namespace TodoApi.Dto
{
    public class TodoDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeleteAt { get; set;}
    }
}
