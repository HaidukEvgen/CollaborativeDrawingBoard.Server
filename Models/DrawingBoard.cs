namespace CollaborativeDrawingBoard.Server.Models
{
    public class DrawingBoard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Stroke> Strokes { get; set; } = new List<Stroke>();
    }
}