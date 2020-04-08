using System;

namespace Core.DependencyInjection
{
	/// <summary>
	/// Transient lifetime services are created each time they're requested from the service container.
	/// This lifetime works best for lightweight, stateless services.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class TransientLifetimeAttribute : Attribute
	{
	}
}
