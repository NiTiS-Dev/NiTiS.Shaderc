using CommunityToolkit.Diagnostics;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

	public CompilationResult CompileIntoSpv(string source, ShaderKind shaderKind, string path, string entry, CompileOptions compileOptions)
	{
		byte* pSource = null;
		byte* pPath = null;
		byte* pEntry = null;
		try
		{
			pSource = Utf8String.AllocateNotNullTerminated(source, out nuint pSourceLength);
			pPath = Utf8String.AllocateNullTerminated(path);
			pEntry = Utf8String.AllocateNullTerminated(entry);

			return new(ShadercApi.compile_into_spv(_compiler, (sbyte*)pSource, pSourceLength, shaderKind, (sbyte*)pPath,
				(sbyte*)pEntry, compileOptions._options));
		}
		finally
		{
			Utf8String.Free((byte*)pSource);
			Utf8String.Free(pPath);
			Utf8String.Free(pEntry);
		}
	}

	public CompilationResult CompileIntoSpv(ReadOnlySpan<byte> source, ShaderKind shaderKind, ReadOnlySpan<byte> path,
		ReadOnlySpan<byte> entryPoint, CompileOptions options)
	{
		fixed (byte* pSource = source)
		fixed (byte* pPath = path)
		fixed (byte* pEntry = entryPoint)
		{
			return new(ShadercApi.compile_into_spv(_compiler, (sbyte*)pSource, (nuint)source.Length, shaderKind,
				(sbyte*)pPath, (sbyte*)pEntry, options._options));
		}
	}

	public static (uint Version, uint Revision) GetSpvVersion()
	{
		GetSpvVersion(out uint version, out uint revision);
		return (version, revision);
	}

	public static void GetSpvVersion(out uint version, out uint revision)
	{
		fixed (uint* pVersion = &version)
		fixed (uint* pRevision = &revision)
		{
			ShadercApi.get_spv_version(pVersion, pRevision);
		}
	}

	public static bool TryParseVersionProfile(string str, out int version, out Profile profile)
	{
		byte* pUtf8Str = null;
		try
		{
			pUtf8Str = Utf8String.AllocateNullTerminated(str);

			fixed (Profile* pProfile = &profile)
			fixed (int* pVersion = &version)
			{
				return ShadercApi.parse_version_profile((sbyte*)pUtf8Str, pVersion, pProfile).ToBool();
			}
		}
		finally
		{
			Utf8String.Free(pUtf8Str);
		}
	}

	public static bool TryParseVersionProfile(ReadOnlySpan<byte> str, out int version, out Profile profile)
	{
		fixed (Profile* pProfile = &profile)
		fixed (int* pVersion = &version)
		fixed (byte* pStr = str)
		{
			return ShadercApi.parse_version_profile((sbyte*)pStr, pVersion, pProfile).ToBool();
		}
	}
}