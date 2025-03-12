using System;

namespace NiTiS.Shaderc;

/// <summary>
/// Compiler handle.
/// </summary>
public readonly struct CompilerHandle : IDisposable
{
	/// <summary>
	/// Native compiler handle.
	/// </summary>
	public readonly IntPtr Handle;

	internal CompilerHandle(nint handle)
	{
		Handle = handle;
	}

	/// <summary>
	/// Initialize a new <see cref="CompilerHandle"/> instance.
	/// </summary>
	public CompilerHandle()
	{
		this = shaderc_compiler_initialize();
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		shaderc_compiler_release(this);
	}
}