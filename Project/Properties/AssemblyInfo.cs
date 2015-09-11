using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyDescription("Enter a description")]
[assembly: CLSCompliant(true)]
[assembly: Guid("de61048d-ebd9-4b02-afd3-2b21a211a14c")]
[assembly: InternalsVisibleTo("HansKindberg.IntegrationTests")]
[assembly: InternalsVisibleTo("HansKindberg.ShimTests")]
[assembly: InternalsVisibleTo("HansKindberg.UnitTests")]

// ReSharper disable CheckNamespace
internal static class AssemblyInfo // ReSharper restore CheckNamespace
{
	#region Fields

	internal const string AssemblyName = "HansKindberg";

	#endregion
}