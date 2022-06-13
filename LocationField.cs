namespace OpenApiPoc
{
    public class LocationField : BaseField
    {
        public LocationField()
            : base(nameof(LocationField))
        {
        }

        public Point Location { get; set; }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
