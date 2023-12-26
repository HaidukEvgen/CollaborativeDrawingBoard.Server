namespace CollaborativeDrawingBoard.Server.Models
{
    public class StrokeDrawingInfo
    {
        public string Color { get; set; }
        public int StartPointX { get; set; }
        public int StartPointY { get; set; }
        public int EndPointX { get; set; }
        public int EndPointY { get; set; }
    }
}