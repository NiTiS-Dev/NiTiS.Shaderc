using System;

namespace NiTiS.Shaderc;

public readonly struct CompilerHandle : IDisposable
{
	public readonly IntPtr Handle;

	internal CompilerHandle(nint handle)
	{
		Handle = handle;
	}

	public CompilerHandle()
	{
		this = shaderc_compiler_initialize();
	}

	public void Dispose()
	{
		shaderc_compiler_release(this);
	}
}