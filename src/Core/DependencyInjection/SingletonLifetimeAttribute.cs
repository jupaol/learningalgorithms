using System;

namespace Core.DependencyInjection
{
	/// <summary>
	/// Singleton lifetime services are created the first time they're requested
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class SingletonLifetimeAttribute : Attribute
	{
	}
}
