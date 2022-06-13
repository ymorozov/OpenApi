namespace OpenApiPoc
{
    public class StringField : BaseField
    {
        public StringField()
            : base(nameof(StringField))
        {
        }

        public string Value { get; set; }
    }
}
