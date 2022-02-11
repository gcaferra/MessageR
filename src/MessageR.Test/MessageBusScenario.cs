using Shouldly;
using Xunit;

namespace MessageR.Test;

public class MessageBusScenario
{
    [Fact]
    void the_Bus_accept_subscribers()
    {
        var sut = new MessageBus();
        sut.Subscribe("topic", () => string.Empty );
        sut._busSubscription.ShouldNotBeEmpty();
    }
}