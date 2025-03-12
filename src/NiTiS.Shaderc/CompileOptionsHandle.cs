using System;

namespace NiTiS.Shaderc;

/// <summary>
/// Compile options handle.
/// </summary>
public readonly struct CompileOptionsHandle : IDisposable, ICloneable
{
	/// <summary>
	/// Native options handle.
	/// </summary>
	public readonly IntPtr Handle;

	internal CompileOptionsHandle(nint handle)
	{
		Handle = handle;
	}

	/// <summary>
	/// Initialize new <see cref="CompileOptionsHandle"/> instance.
	/// </summary>
	public CompileOptionsHandle()
	{
		this = shaderc_compile_options_initialize();
	}

	/// <summary>
	/// Create a clone of current options instance.
	/// </summary>
	/// <returns>New separate <see cref="CompileOptionsHandle"/> instance.</returns>
	public CompileOptionsHandle Clone()
	{
		return shaderc_compile_options_clone(this);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		shaderc_compile_options_release(this);
	}
}