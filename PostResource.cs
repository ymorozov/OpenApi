namespace OpenApiPoc
{
    public class PostResource
    {
        public string ContentTypeId { get; set; }

        public IEnumerable<BaseField> Fields { get; set; }
    }
}
