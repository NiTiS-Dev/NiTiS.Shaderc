using CommunityToolkit.Diagnostics;
using System;
using NiTiS.Shaderc.LowLevel;

namespace NiTiS.Shaderc;

/// <summary>
/// Shader compiler.
/// </summary>
public readonly unsafe struct ShaderCompiler : IDisposable, IEquatable<ShaderCompiler>
{
	private readonly shaderc_compiler* _compiler;

	/// <summary>
	/// Native compiler handle.
	/// </summary>
	public nint Handle => (nint)_compiler;

	public ShaderCompiler()
	{
		_compiler = ShadercApi.compiler_initialize();
	}

	public ShaderCompiler(shaderc_compiler* compiler)
	{
		_compiler = compiler;
	}

	public void Dispose()
	{
		ShadercApi.compiler_release(_compiler);
	}

	public bool Equals(ShaderCompiler other)
	{
		return _compiler == other._compiler;
	}

	public override bool Equals(object? obj)
	{
		return obj is ShaderCompiler other && Equals(other);
	}

	public override int GetHashCode()
	{
		return unchecked((int)(long)_compiler);
	}
}