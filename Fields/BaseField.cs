namespace OpenApiPoc
{
    public abstract class BaseField
    {
        protected BaseField(string implementingType)
        {
            Type = implementingType.ToLowerInvariant().Split("field")[0];
        }

        protected BaseField()
        {

        }

        public string Type { get; set;  }
    }
}
