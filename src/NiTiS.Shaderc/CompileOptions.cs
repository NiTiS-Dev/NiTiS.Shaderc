using System;
using System.Runtime.InteropServices;
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


	public void SetSourceLanguage(SourceLanguage language)
	{
		ShadercApi.compile_options_set_source_language(_options, language);
	}

	public void SetOptimization(OptimizationLevel level)
	{
		ShadercApi.compile_options_set_optimization_level(_options, level);
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

	public void ForceVersion(int version, [Optional] Profile profile)
	{
		ShadercApi.compile_options_set_forced_version_profile(_options, version, profile);
	}

	public void SuppressWarnings()
	{
		ShadercApi.compile_options_set_suppress_warnings(_options);
	}

	public void SetTargetVersion(TargetEnvironment target, [Optional] EnvironmentVersion version)
	{
		ShadercApi.compile_options_set_target_env(_options, target, (uint)version);
	}

	public void SetTargetSpirvVersion(SpirvVersion version)
	{
		ShadercApi.compile_options_set_target_spirv(_options, version);
	}

	public void ThreatWarningsAsErrors()
	{
		ShadercApi.compile_options_set_warnings_as_errors(_options);
	}

	public void SetLimit(Limit limit, int limitation)
	{
		ShadercApi.compile_options_set_limit(_options, limit, limitation);
	}

	public void SetAutoBindUniforms(bool autoBind)
	{
		ShadercApi.compile_options_set_auto_bind_uniforms(_options, autoBind);
	}

	public void SetAutoCombinedImageSampler(bool upgrade)
	{
		ShadercApi.compile_options_set_auto_combined_image_sampler(_options, upgrade);
	}

	public void SetHlslIOMapping(bool iomap)
	{
		ShadercApi.compile_options_set_hlsl_io_mapping(_options, iomap);
	}

	public void SetHlslIOMapping(bool offsets)
	{
		ShadercApi.compile_options_set_hlsl_offsets(_options, offsets);
	}

	public void SetBindingBase(UniformKind kind, uint @base)
	{
		ShadercApi.compile_options_set_binding_base(_options, kind, @base);
	}

	public void SetBindingBaseForStage(ShaderKind stage, UniformKind kind, uint @base)
	{
		ShadercApi.compile_options_set_binding_base_for_stage(_options, stage, kind, @base);
	}

	public void SetPreserveBindings(bool preserve)
	{
		ShadercApi.compile_options_set_preserve_bindings(_options, preserve);
	}

	public void SetAutomapLocations(bool autoMap)
	{
		ShadercApi.compile_options_set_auto_map_locations(_options, autoMap);
	}
}