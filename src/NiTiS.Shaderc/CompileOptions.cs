using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NiTiS.Shaderc.LowLevel;

namespace NiTiS.Shaderc;

/// <summary>
/// Compile options.
/// </summary>
public readonly unsafe struct CompileOptions : IDisposable, IEquatable<CompileOptions>, ICloneable
{
	internal readonly shaderc_compile_options* _options;

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

	public void AddMacro(string name, [Optional] string? value)
	{
		byte* pName = null;
		byte* pValue = null;
		try
		{
			nuint pValueLength = 0;
			pName = Utf8String.AllocateNotNullTerminated(name, out nuint pNameLength);
			pValue = value is null ? null : Utf8String.AllocateNotNullTerminated(value, out pValueLength);

			ShadercApi.compile_options_add_macro_definition(_options, (sbyte*)pName, pNameLength, (sbyte*)pValue, pValueLength);
		}
		finally
		{
			Utf8String.Free(pName);
			Utf8String.Free(pValue);
		}
	}

	public void ProvideIncludeResolver(IncludeResolver resolver, [Optional] nint userData)
	{
		nint resolve = Marshal.GetFunctionPointerForDelegate(resolver._resolve);
		nint release = Marshal.GetFunctionPointerForDelegate(resolver._release);
		ShadercApi.compile_options_set_include_callbacks(_options,
			(delegate* unmanaged[Cdecl]<void*, sbyte*, int, sbyte*, nuint, shaderc_include_result*>)resolve,
			(delegate* unmanaged[Cdecl]<void*, shaderc_include_result*, void>)release,
			(void*)userData
			);
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
		ShadercApi.compile_options_set_auto_bind_uniforms(_options, autoBind.ToByte());
	}

	public void SetAutoCombinedImageSampler(bool upgrade)
	{
		ShadercApi.compile_options_set_auto_combined_image_sampler(_options, upgrade.ToByte());
	}

	public void SetHlslIOMapping(bool iomap)
	{
		ShadercApi.compile_options_set_hlsl_io_mapping(_options, iomap.ToByte());
	}

	public void SetHlslOffects(bool offsets)
	{
		ShadercApi.compile_options_set_hlsl_offsets(_options, offsets.ToByte());
	}

	public void SetBindingBase(UniformKind kind, uint @base)
	{
		ShadercApi.compile_options_set_binding_base(_options, kind, @base);
	}

	public void SetBindingBase(ShaderKind stage, UniformKind kind, uint @base)
	{
		ShadercApi.compile_options_set_binding_base_for_stage(_options, stage, kind, @base);
	}

	public void SetPreserveBindings(bool preserve)
	{
		ShadercApi.compile_options_set_preserve_bindings(_options, preserve.ToByte());
	}

	public void SetAutomapLocations(bool autoMap)
	{
		ShadercApi.compile_options_set_auto_map_locations(_options, autoMap.ToByte());
	}

	public void SetHlslRegisterSetAndBinding(ShaderKind kind, ReadOnlySpan<byte> reg, ReadOnlySpan<byte> set, ReadOnlySpan<byte> binding)
	{
		fixed (byte* pReg = reg)
		fixed (byte* pSet = set)
		fixed (byte* pBinding = binding)
		{
			ShadercApi.compile_options_set_hlsl_register_set_and_binding_for_stage(_options, kind, (sbyte*)pReg,
				(sbyte*)pSet, (sbyte*)pBinding);
		}
	}

	public void SetHlslRegisterSetAndBinding(ReadOnlySpan<byte> reg, ReadOnlySpan<byte> set, ReadOnlySpan<byte> binding)
	{
		fixed (byte* pReg = reg)
		fixed (byte* pSet = set)
		fixed (byte* pBinding = binding)
		{
			ShadercApi.compile_options_set_hlsl_register_set_and_binding(_options, (sbyte*)pReg, (sbyte*)pSet,
				(sbyte*)pBinding);
		}
	}

	public void SetHlslFunctionality1(bool enable)
	{
		ShadercApi.compile_options_set_hlsl_functionality1(_options, enable.ToByte());
	}

	public void SetHlsl16BitTypes(bool enable)
	{
		ShadercApi.compile_options_set_hlsl_16bit_types(_options, enable.ToByte());
	}

	public void SetVulkanRulesRelaxed(bool enabled)
	{
		ShadercApi.compile_options_set_vulkan_rules_relaxed(_options, enabled.ToByte());
	}

	public void SetInvertY(bool enable)
	{
		ShadercApi.compile_options_set_invert_y(_options, enable.ToByte());
	}

	public void SetNanClamp(bool enable)
	{
		ShadercApi.compile_options_set_nan_clamp(_options, enable.ToByte());
	}
}