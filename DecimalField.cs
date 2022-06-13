namespace OpenApiPoc
{
    public class DecimalField : BaseField
    {
        public DecimalField()
            : base(nameof(DecimalField))
        {
        }

        public decimal Value { get; set; }
    }
}
