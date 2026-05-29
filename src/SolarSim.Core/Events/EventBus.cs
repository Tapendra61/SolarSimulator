using System;
using System.Collections.Generic;

namespace SolarSim.Core.Events;

public sealed class EventBus
{
	private readonly Dictionary<Type, List<Delegate>> _handlers = new();

	private delegate void SomeDelegate(int a);

	public void Subscribe<TEvent>(Action<TEvent> handler)
	{
		Type eventType = typeof(TEvent);

		if (!_handlers.TryGetValue(eventType, out List<Delegate>? handlers))
		{
			handlers = [];
			_handlers[eventType] = handlers;
		}

		handlers.Add(handler);
	}

	public void Unsubscribe<TEvent>(Action<TEvent> handler)
	{
		Type eventType = typeof(TEvent);
		if (_handlers.TryGetValue(eventType, out List<Delegate>? handlers))
		{
			handlers.Remove(handler);
		}
	}

	public void Publish<TEvent>(in TEvent evt)
	{
		Type eventType = typeof(TEvent);
		if (!_handlers.TryGetValue(eventType, out List<Delegate>? handlers)) return;

		foreach (Delegate handler in handlers.ToArray())
		{
			((Action<TEvent>)handler)(evt);
		}
	}
}
