using CommunityToolkit.Diagnostics;
using System;

namespace NiTiS.Shaderc;

/// <summary>
/// Compiler handle.
/// </summary>
public readonly unsafe struct CompilerHandle : IDisposable
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

	/// <summary>
	/// Compile source shader code into SPIR-V bytecode.
	/// </summary>
	/// <param name="utf8Source">Source bytes.</param>
	/// <param name="sourceLength">Source length.</param>
	/// <param name="kind">Shader kind.</param>
	/// <param name="utf8SourceName">Source name bytes (null terminated).</param>
	/// <param name="utf8EntryPointName">Shader entry point name (null terminated).</param>
	/// <param name="options">Compilation options</param>
	/// <returns>Compilation result handle.</returns>
	public CompilationResultHandle CompileIntoSpv(byte* utf8Source, nuint sourceLength, ShaderKind kind, byte* utf8SourceName, byte* utf8EntryPointName, CompileOptionsHandle options)
	{
		return shaderc_compile_into_spv(this, utf8Source, sourceLength, kind, utf8SourceName, utf8EntryPointName, options);
	}
}