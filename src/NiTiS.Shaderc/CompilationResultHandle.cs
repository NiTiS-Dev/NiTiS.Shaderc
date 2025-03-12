using System;

namespace NiTiS.Shaderc;

/// <summary>
/// Compilation result handle.
/// </summary>
public readonly struct CompilationResultHandle
{
	/// <summary>
	/// Native result handle.
	/// </summary>
	public readonly IntPtr Handle;

	internal CompilationResultHandle(nint handle)
	{
		Handle = handle;
	}
}