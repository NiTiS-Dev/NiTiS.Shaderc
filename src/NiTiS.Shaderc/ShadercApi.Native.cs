global using static NiTiS.Shaderc.ShadercApi;
global using unsafe shaderc_include_result_release_fn = delegate* unmanaged<void*, global::NiTiS.Shaderc.IncludeResult*, void>;
global using unsafe shaderc_include_resolve_fn = delegate* unmanaged<void*, byte*, global::NiTiS.Shaderc.IncludeType, byte*, nuint, global::NiTiS.Shaderc.IncludeResult*>;
using System.Runtime.InteropServices;

namespace NiTiS.Shaderc;

/// <summary>
/// Direct API for <c>shaderc</c> library.
/// </summary>
public static unsafe partial class ShadercApi
{
	private const string LibraryName = "shaderc_shared";

#pragma warning disable CA1401
#pragma warning disable CS1591

	[DllImport(LibraryName)]
	public static extern CompilerHandle shaderc_compiler_initialize();

	[DllImport(LibraryName)]
	public static extern void shaderc_compiler_release(CompilerHandle handle);

	[DllImport(LibraryName)]
	public static extern CompileOptionsHandle shaderc_compile_options_initialize();

	[DllImport(LibraryName)]
	public static extern CompileOptionsHandle shaderc_compile_options_clone(CompileOptionsHandle options);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_release(CompileOptionsHandle options);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_add_macro_definition(
		CompileOptionsHandle options,
		byte* name,
		nuint nameLength,
		byte* value,
		nuint valueLength
	);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_source_language(CompileOptionsHandle options, SourceLanguage lang);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_generate_debug_info(CompileOptionsHandle options);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_optimization_level(CompileOptionsHandle options, OptimizationLevel optimization);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_forced_version_profile(CompileOptionsHandle options, uint version, Profile profile);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_include_callbacks(
		CompileOptionsHandle options,
		shaderc_include_resolve_fn resolver,
		shaderc_include_result_release_fn resultReleaser,
		void* userData
	);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_suppress_warnings(CompileOptionsHandle options);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_target_env(CompileOptionsHandle options, TargetEnvironment environment, uint version);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_target_spirv(CompileOptionsHandle options, SpirvVersion version);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_warnings_as_errors(CompileOptionsHandle options);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_limit(CompileOptionsHandle options, Limit limit, uint value);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_auto_bind_uniforms(CompileOptionsHandle options, bool autoBind);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_auto_combined_image_sampler(CompileOptionsHandle options, bool upgrade);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_hlsl_io_mapping(CompileOptionsHandle options, bool ioMap);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_hlsl_offsets(CompileOptionsHandle options, bool offsets);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_binding_base(CompileOptionsHandle options, UniformKind kind, uint @base);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_binding_base_for_stage(CompileOptionsHandle options, ShaderKind shader, UniformKind uniform, uint @base);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_preserve_bindings(CompileOptionsHandle options, bool preserveBindings);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_auto_map_locations(CompileOptionsHandle options, bool autoMap);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage(
		CompileOptionsHandle options, ShaderKind shader,
		byte* reg,
		byte* set,
		byte* binding
	);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_hlsl_register_set_and_binding(
		CompileOptionsHandle options,
		byte* reg,
		byte* set,
		byte* binding
	);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_hlsl_functionality1(CompileOptionsHandle options, bool enabled);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_hlsl_16bit_types(CompileOptionsHandle options, bool enabled);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_vulkan_rules_relaxed(CompileOptionsHandle options, bool enabled);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_invert_y(CompileOptionsHandle options, bool inverted);

	[DllImport(LibraryName)]
	public static extern void shaderc_compile_options_set_nan_clamp(CompileOptionsHandle options, bool inverted);

	[DllImport(LibraryName)]
	public static extern CompilationResultHandle shaderc_compile_into_spv(
		CompilerHandle compiler,
		byte* sourceText,
		nuint sourceTextSize,
		ShaderKind shaderKind,
		byte* inputSourceName,
		byte* entryPointName,
		CompileOptionsHandle additionalOptions
	);

	[DllImport(LibraryName)]
	public static extern CompilationResultHandle shaderc_compile_into_spv_assembly(
		CompilerHandle compiler,
		byte* sourceText,
		nuint sourceTextSize,
		ShaderKind shaderKind,
		byte* inputSourceName,
		byte* entryPointName,
		CompileOptionsHandle additionalOptions
	);

	[DllImport(LibraryName)]
	public static extern CompilationResultHandle shaderc_compile_into_preprocessed_text(
		CompilerHandle compiler,
		byte* sourceText,
		nuint sourceTextSize,
		ShaderKind shaderKind,
		byte* inputSourceName,
		byte* entryPointName,
		CompileOptionsHandle additionalOptions
	);

	[DllImport(LibraryName)]
	public static extern CompilationResultHandle shaderc_assemble_into_spv(
		CompilerHandle compiler,
		byte* sourceAssembly,
		nuint sourceAssemblySize,
		CompileOptionsHandle additionalOptions
	);

	[DllImport(LibraryName)]
	public static extern void shaderc_result_release(CompilationResultHandle result);

	[DllImport(LibraryName)]
	public static extern nuint shaderc_result_get_length(CompilationResultHandle result);

	[DllImport(LibraryName)]
	public static extern nuint shaderc_result_get_num_warnings(CompilationResultHandle result);

	[DllImport(LibraryName)]
	public static extern nuint shaderc_result_get_num_errors(CompilationResultHandle result);

	[DllImport(LibraryName)]
	public static extern CompilationStatus shaderc_result_get_compilation_status(CompilationResultHandle result);

	[DllImport(LibraryName)]
	public static extern byte* shaderc_result_get_bytes(CompilationResultHandle result);

	[DllImport(LibraryName)]
	public static extern byte* shaderc_result_get_error_message(CompilationResultHandle result);

	[DllImport(LibraryName)]
	public static extern void shaderc_get_spv_version(uint* version, uint* revision);

	[DllImport(LibraryName)]
	public static extern bool shaderc_parse_version_profile(byte* str, int* version, Profile* profile);
#pragma warning restore
}