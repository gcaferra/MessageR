using Shouldly;
using Xunit;

namespace MessageR.Test;

public class PublisherScenario
{
    [Fact]
    void TypeMap_Scan_for_methods_Handlers()
    {
        var sut = new TypeMap(typeof(PingResponder).Assembly);
        
        sut.Funcs.ShouldContainKey(typeof(Ping));
    }

    [Fact]
    void Ping_Message_can_be_published()
    {
        
        var map = new TypeMap(typeof(PingResponder).Assembly);

        var sut = new Publisher(map);
        
        var result = sut.Send(new Ping("Joe"));
        
        result.ShouldBe("Hello Joe");
        
    }
    
}