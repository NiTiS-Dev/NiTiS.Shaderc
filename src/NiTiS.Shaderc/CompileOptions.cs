using System;
using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using NiTiS.Shaderc.LowLevel;

namespace NiTiS.Shaderc;

/// <summary>
/// Compile options.
/// </summary>
public readonly unsafe struct CompileOptions : IDisposable, IEquatable<CompileOptions>, ICloneable
{
	private readonly shaderc_compile_options* _options;

	/// <summary>
	/// Native options handle.
	/// </summary>
	public nint Handle => (nint)_options;

	public SourceLanguage Language
	{
		set => ShadercApi.compile_options_set_source_language(_options, value);
	}

	public CompileOptions()
	{
		_options = ShadercApi.compile_options_initialize();
	}

	public CompileOptions(shaderc_compile_options* options)
	{
		_options = options;
	}

	public void Dispose()
	{
		ShadercApi.compile_options_release(_options);
	}

	public bool Equals(CompileOptions other)
	{
		return _options == other._options;
	}

	public override bool Equals(object? obj)
	{
		return obj is CompileOptions other && Equals(other);
	}

	public override int GetHashCode()
	{
		return unchecked((int)(long)_options);
	}

	public CompileOptions Clone()
	{
		return new CompileOptions(ShadercApi.compile_options_clone(_options));
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public void AddMacro(ReadOnlySpan<byte> name, ReadOnlySpan<byte> value)
	{
		fixed (byte* pName = name)
		fixed (byte* pValue = value)
		{
			ShadercApi.compile_options_add_macro_definition(_options, (sbyte*)pName, (nuint)name.Length, (sbyte*)pValue, (nuint)value.Length);
		}
	}

	public void AddMacro(ReadOnlySpan<byte> name)
	{
		fixed (byte* pName = name)
		{
			ShadercApi.compile_options_add_macro_definition(_options, (sbyte*)pName, (nuint)name.Length, null, 0u);
		}
	}

	public void AddMacro(string name, string? value)
	{
		throw new NotImplementedException();
	}

	public void EnableGenerateDebugInfo()
	{
		ShadercApi.compile_options_set_generate_debug_info(_options);
	}
}