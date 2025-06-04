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
		throw new NotImplementedException();
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