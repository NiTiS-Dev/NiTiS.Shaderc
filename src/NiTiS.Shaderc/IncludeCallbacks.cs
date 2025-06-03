using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NiTiS.Shaderc;

/// <summary>
/// Include resolver delegate.
/// </summary>
/// <param name="userData">Custom provided data.</param>
/// <param name="requestedSource">Requested source.</param>
/// <param name="include">Include type.</param>
/// <param name="requestingSource">The caller source.</param>
/// <param name="includeDepth">Include depth.</param>
/// <returns>Unmanaged pointer to <see cref="IncludeResult"/> instance.</returns>
[UnmanagedFunctionPointer(CallingConvention.Winapi)]
public unsafe delegate IncludeResult* ResolveInclude(void* userData, byte* requestedSource, IncludeType include, byte* requestingSource, nuint includeDepth);

/// <summary>
/// Release allocated <see cref="IncludeResult"/> instance.
/// </summary>
/// <param name="result">Instance to be released.</param>
[UnmanagedFunctionPointer(CallingConvention.Winapi)]
public unsafe delegate void ReleaseIncludeResult(IncludeResult* result);