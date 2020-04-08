using System;

namespace Core.DependencyInjection
{
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public sealed class ManualContainerInjectionAttribute : Attribute
	{
	}
}
