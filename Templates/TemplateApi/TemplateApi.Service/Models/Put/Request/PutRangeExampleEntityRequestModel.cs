﻿namespace TemplateApi.Service.Models.Put.Request;

public class PutRangeExampleEntityRequestModel
{
    public Guid Id { get; set; }
    public long Sequence { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime CreationDate { get; set; }
}
