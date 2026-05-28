using SolarSim.Core.Events;
using Xunit;

namespace SolarSim.Core.Tests.Events;

public class EventBusTests
{
	[Fact]
	public void PublishDeliversEventToSubscriber()
	{
		EventBus bus = new();
		int receivedValue = 0;
		bus.Subscribe<TestEvent>(evt => receivedValue = evt.Value);

		bus.Publish(new TestEvent(44));

		Assert.Equal(44, receivedValue);
	}

	[Fact]
	public void PublishDoesNotDeliverToUnSubscribed()
	{
		EventBus bus = new();
		int callCount = 0;
		bus.Subscribe<TestEvent>(Handler);

		bus.Unsubscribe<TestEvent>(Handler);
		bus.Publish(new TestEvent(1));

		Assert.Equal(0, callCount);
		return;
		void Handler(TestEvent evt) => callCount++;
	}

	[Fact]
	public void PublishDeliversToMultipleSubscribers()
	{
		EventBus bus = new();

		int firstCalls = 0;
		int secondCalls = 0;

		bus.Subscribe<TestEvent>(_ => firstCalls++);
		bus.Subscribe<TestEvent>(_ => secondCalls++);

		bus.Publish(new TestEvent(1));
		Assert.Equal(1, firstCalls);
		Assert.Equal(1, secondCalls);
	}
}
