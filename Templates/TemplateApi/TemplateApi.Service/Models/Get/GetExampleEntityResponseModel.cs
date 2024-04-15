namespace TemplateApi.Service.Models.Get
{
    public class GetExampleEntityResponseModel
    {
        public Guid Id { get; set; }
        public long Sequence { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
