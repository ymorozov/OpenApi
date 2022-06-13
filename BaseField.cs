namespace OpenApiPoc
{
    public abstract class BaseField
    {
        protected BaseField(string implementingType)
        {
            Type = implementingType.ToLowerInvariant().Split("field")[0];
        }

        public string Type { get; }
    }
}
