namespace NiTiS.Shaderc;

public readonly struct ShaderCompiler : IDisposable
{
	public readonly IntPtr Handle;

	internal ShaderCompiler(nint handle)
	{
		Handle = handle;
	}

	public ShaderCompiler()
	{
		this = shaderc_compiler_initialize();
	}

	public void Dispose()
	{
		shaderc_compiler_release(this);
	}
}