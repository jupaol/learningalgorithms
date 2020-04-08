using System;

namespace Core.DependencyInjection
{
	/// <summary>
	/// Scoped lifetime services are created once per client request (connection).
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class ScopedLifetimeAttribute : Attribute
	{
	}
}
