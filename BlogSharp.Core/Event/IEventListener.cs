using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogSharp.Core.Event
{
	public interface IEventListener<TEvent> where TEvent : IEvent
	{
		void Handle(TEvent @event);
	}
}