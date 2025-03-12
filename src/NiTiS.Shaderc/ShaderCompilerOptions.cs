namespace NiTiS.Shaderc;

public readonly struct ShaderCompilerOptions : IDisposable, ICloneable
{
	public readonly IntPtr Handle;

	internal ShaderCompilerOptions(nint handle)
	{
		Handle = handle;
	}

	public ShaderCompilerOptions()
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