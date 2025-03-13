using CommunityToolkit.Diagnostics;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

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
	/// Source code language.
	/// </summary>
	public SourceLanguage Language
	{
		set
		{
			shaderc_compile_options_set_source_language(this, value);
		}
	}

	/// <summary>
	/// Compiler optimization mode.
	/// </summary>
	public OptimizationLevel Optimization
	{
		set
		{
			shaderc_compile_options_set_optimization_level(this, value);
		}
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

	/// <summary>
	/// Define macros with name and value.
	/// </summary>
	/// <param name="name">UTF-8 name string.</param>
	/// <param name="value">UTF-8 value string.</param>
	public unsafe void AddMacros(string name, string value)
	{
		Guard.IsNotNull(name);
		Guard.IsNotNull(value);

		Encoding utf8 = Encoding.UTF8;

		int nameUtf8Length = utf8.GetByteCount(name);
		int valueUtf8Length = utf8.GetByteCount(value);

		byte* buffer = stackalloc byte[nameUtf8Length + valueUtf8Length];

		utf8.GetBytes(name, MemoryMarshal.CreateSpan(ref Unsafe.AsRef<byte>(buffer), nameUtf8Length));
		utf8.GetBytes(value, MemoryMarshal.CreateSpan(ref Unsafe.AsRef<byte>(buffer + nameUtf8Length), valueUtf8Length));

		shaderc_compile_options_add_macro_definition(this, buffer, (nuint)nameUtf8Length, buffer + nameUtf8Length, (nuint)valueUtf8Length);
	}

	/// <summary>
	/// Define macros with name and value.
	/// </summary>
	/// <param name="name">UTF-8 name string.</param>
	/// <param name="value">UTF-8 value string.</param>
	public unsafe void AddMacros(ReadOnlySpan<byte> name, ReadOnlySpan<byte> value)
	{
		fixed(byte* pName = name)
		fixed(byte* pValue = value)
		{
			shaderc_compile_options_add_macro_definition(this, pName, (nuint)name.Length, pValue, (nuint)value.Length);
		}
	}

	/// <summary>
	/// Define macros with name and value.
	/// </summary>
	/// <param name="name">Pointer to UTF-8 name string.</param>
	/// <param name="nameLength">Length of name string.</param>
	/// <param name="value">Pointer to UTF-8 value string.</param>
	/// <param name="valueLength">Length of value string.</param>
	public unsafe void AddMacros(byte* name, nuint nameLength, byte* value, nuint valueLength)
	{
		shaderc_compile_options_add_macro_definition(this, name, nameLength, value, valueLength);
	}

	/// <summary>
	/// Compiler will generate debug information.
	/// </summary>
	public void EnableDebugInfo()
	{
		shaderc_compile_options_set_generate_debug_info(this);
	}

	/// <summary>
	/// Forces the GLSL language version and profile to a given pair.
	/// </summary>
	/// <param name="version">The same number as would appear in the <c>#version</c> annotation in the source.</param>
	/// <param name="profile">Profile, or <see cref="Profile.None"/> for versions, that not define profiles.</param>
	public void SetForceVersion(uint version, Profile profile)
	{
		shaderc_compile_options_set_forced_version_profile(this, version, profile);
	}

	//public void RegisterIncludeResolver(object resolver)
	//{

	//}

	/// <summary>
	/// Compiler will suppress warnings.
	/// </summary>
	public void SuppressWarnings()
	{
		shaderc_compile_options_set_suppress_warnings(this);
	}

	/// <summary>
	/// Set target shader environment.
	/// </summary>
	/// <param name="environment"></param>
	public void SetTargetEnvironment(TargetEnvironment environment)
	{
		shaderc_compile_options_set_target_env(this, environment, 0u);
	}

	/// <summary>
	/// Set target shader environment and version.
	/// </summary>
	/// <param name="environment"></param>
	/// <param name="version"></param>
	public void SetTargetEnvironment(TargetEnvironment environment, EnvironmentVersion version)
	{
		shaderc_compile_options_set_target_env(this, environment, version);
	}

	/// <summary>
	/// Set SPIR-V version.
	/// </summary>
	/// <param name="version">SPIR-V version.</param>
	public void SetTargetSPV(SpirvVersion version)
	{
		shaderc_compile_options_set_target_spirv(this, version);
	}

	/// <summary>
	/// Threat all warnings as errors.
	/// </summary>
	public void ThreatWarningAsErrors()
	{
		shaderc_compile_options_set_warnings_as_errors(this);
	}
}