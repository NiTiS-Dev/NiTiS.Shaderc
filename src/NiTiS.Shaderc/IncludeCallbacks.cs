using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NiTiS.Shaderc;

/// <summary>
/// Prevent managed delegates from being collected during garbage collecting.
/// </summary>
/// <remarks>
/// This instance shall have shared lifetime with <see cref="CompileOptionsHandle"/> instance. THIS INSTANCE SHALL LIVE AT ANY COST.
/// </remarks>
public struct IncludeCallbacks : IDisposable
{
	/// <summary>
	/// Resolve handle.
	/// </summary>
	public ResolveInclude Resolve { get; set; }

	/// <summary>
	/// Release handle.
	/// </summary>
	public ReleaseIncludeResult Release { get; set; }

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.NoInlining)]
	public readonly void Dispose() { }
}

/// <summary>
/// Include resolver delegate.
/// </summary>
/// <param name="userData">Custom provided data.</param>
/// <param name="requestedSource">Requested source.</param>
/// <param name="include">Include type.</param>
/// <param name="requestingSource">The caller source.</param>
/// <param name="includeDepth">Include depth.</param>
/// <returns>Unmanaged pointer to <see cref="IncludeResult"/> instance.</returns>
[UnmanagedFunctionPointer(CallingConvention.StdCall)]
public unsafe delegate IncludeResult* ResolveInclude(void* userData, byte* requestedSource, IncludeType include, byte* requestingSource, nuint includeDepth);

/// <summary>
/// Release allocated <see cref="IncludeResult"/> instance.
/// </summary>
/// <param name="result">Instance to be released.</param>
[UnmanagedFunctionPointer(CallingConvention.StdCall)]
public unsafe delegate void ReleaseIncludeResult(IncludeResult* result);