namespace AWS.Messaging.SerializationIssue;

public class Payload
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int SomeValue { get; set; }
}