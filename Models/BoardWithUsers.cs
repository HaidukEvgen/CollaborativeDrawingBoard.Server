namespace CollaborativeDrawingBoard.Server.Models
{
    public class BoardWithUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Usernames { get; set; }
    }
}
