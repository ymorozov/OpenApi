namespace OpenApiPoc
{
    public class IntegerField : BaseField
    {
        public IntegerField()
        : base(nameof(IntegerField))
        {
        }

        public int Value { get; set; }
    }
}
