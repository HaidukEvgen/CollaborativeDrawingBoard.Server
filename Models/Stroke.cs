namespace CollaborativeDrawingBoard.Server.Models
{
    public class Stroke
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int StartPointX { get; set; }
        public int StartPointY { get; set; }
        public int EndPointX { get; set; }
        public int EndPointY { get; set; }
        public virtual DrawingBoard DrawingBoard { get; set; } = null!;
    }
}