using System;

namespace IntegrationTest.test.model;

public record Project
{
    public License? license { get; set; } = null;
    public Guid? id { get; set; } = null;
    public Guid licenseId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime created { get; set; }
}