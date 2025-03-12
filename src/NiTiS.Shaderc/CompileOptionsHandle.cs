using System;

namespace NiTiS.Shaderc;

public readonly struct CompileOptionsHandle : IDisposable, ICloneable
{
	public readonly IntPtr Handle;

	internal CompileOptionsHandle(nint handle)
	{
		Handle = handle;
	}

	public CompileOptionsHandle()
	{
		this = shaderc_compile_options_initialize();
	}

	public object Clone()
	{
		return shaderc_compile_options_clone(this);
	}

	public void Dispose()
	{
		shaderc_compile_options_release(this);
	}
}