using System.Runtime.InteropServices;

namespace NiTiS.Shaderc.LowLevel;

public static unsafe partial class ShadercApi
{
    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compiler_initialize"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compiler_initialize", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compiler_t")]
    public static extern shaderc_compiler* compiler_initialize();

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compiler_release"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compiler_release", ExactSpelling = true)]
    public static extern void compiler_release([NativeTypeName("shaderc_compiler_t")] shaderc_compiler* param0);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_initialize"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_initialize", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compile_options_t")]
    public static extern shaderc_compile_options* compile_options_initialize();

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_clone"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_clone", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compile_options_t")]
    public static extern shaderc_compile_options* compile_options_clone([NativeTypeName("const shaderc_compile_options_t")] shaderc_compile_options* options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_release"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_release", ExactSpelling = true)]
    public static extern void compile_options_release([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_add_macro_definition"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_add_macro_definition", ExactSpelling = true)]
    public static extern void compile_options_add_macro_definition([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("size_t")] nuint name_length, [NativeTypeName("const char *")] sbyte* value, [NativeTypeName("size_t")] nuint value_length);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_source_language"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_source_language", ExactSpelling = true)]
    public static extern void compile_options_set_source_language([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_source_language")] SourceLanguage lang);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_generate_debug_info"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_generate_debug_info", ExactSpelling = true)]
    public static extern void compile_options_set_generate_debug_info([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_optimization_level"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_optimization_level", ExactSpelling = true)]
    public static extern void compile_options_set_optimization_level([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_optimization_level")] OptimizationLeve level);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_forced_version_profile"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_forced_version_profile", ExactSpelling = true)]
    public static extern void compile_options_set_forced_version_profile([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, int version, [NativeTypeName("shaderc_profile")] Profile profile);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_include_callbacks"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_include_callbacks", ExactSpelling = true)]
    public static extern void compile_options_set_include_callbacks([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_include_resolve_fn")] delegate* unmanaged[Cdecl]<void*, sbyte*, int, sbyte*, nuint, shaderc_include_result*> resolver, [NativeTypeName("shaderc_include_result_release_fn")] delegate* unmanaged[Cdecl]<void*, shaderc_include_result*, void> result_releaser, void* user_data);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_suppress_warnings"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_suppress_warnings", ExactSpelling = true)]
    public static extern void compile_options_set_suppress_warnings([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_target_env"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_target_env", ExactSpelling = true)]
    public static extern void compile_options_set_target_env([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_target_env")] TargetEnvironment target, [NativeTypeName("uint32_t")] uint version);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_target_spirv"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_target_spirv", ExactSpelling = true)]
    public static extern void compile_options_set_target_spirv([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_spirv_version")] SpirvVersion version);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_warnings_as_errors"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_warnings_as_errors", ExactSpelling = true)]
    public static extern void compile_options_set_warnings_as_errors([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_limit"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_limit", ExactSpelling = true)]
    public static extern void compile_options_set_limit([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_limit")] Limit limit, int value);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_auto_bind_uniforms"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_auto_bind_uniforms", ExactSpelling = true)]
    public static extern void compile_options_set_auto_bind_uniforms([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte auto_bind);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_auto_combined_image_sampler"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_auto_combined_image_sampler", ExactSpelling = true)]
    public static extern void compile_options_set_auto_combined_image_sampler([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte upgrade);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_hlsl_io_mapping"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_hlsl_io_mapping", ExactSpelling = true)]
    public static extern void compile_options_set_hlsl_io_mapping([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte hlsl_iomap);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_hlsl_offsets"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_hlsl_offsets", ExactSpelling = true)]
    public static extern void compile_options_set_hlsl_offsets([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte hlsl_offsets);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_binding_base"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_binding_base", ExactSpelling = true)]
    public static extern void compile_options_set_binding_base([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_uniform_kind")] UniformKind kind, [NativeTypeName("uint32_t")] uint @base);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_binding_base_for_stage"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_binding_base_for_stage", ExactSpelling = true)]
    public static extern void compile_options_set_binding_base_for_stage([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_shader_kind")] ShaderKind shader_kind, [NativeTypeName("shaderc_uniform_kind")] UniformKind kind, [NativeTypeName("uint32_t")] uint @base);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_preserve_bindings"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_preserve_bindings", ExactSpelling = true)]
    public static extern void compile_options_set_preserve_bindings([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte preserve_bindings);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_auto_map_locations"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_auto_map_locations", ExactSpelling = true)]
    public static extern void compile_options_set_auto_map_locations([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte auto_map);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_hlsl_register_set_and_binding_for_stage"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage", ExactSpelling = true)]
    public static extern void compile_options_set_hlsl_register_set_and_binding_for_stage([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("shaderc_shader_kind")] ShaderKind shader_kind, [NativeTypeName("const char *")] sbyte* reg, [NativeTypeName("const char *")] sbyte* set, [NativeTypeName("const char *")] sbyte* binding);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_hlsl_register_set_and_binding"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding", ExactSpelling = true)]
    public static extern void compile_options_set_hlsl_register_set_and_binding([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("const char *")] sbyte* reg, [NativeTypeName("const char *")] sbyte* set, [NativeTypeName("const char *")] sbyte* binding);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_hlsl_functionality1"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_hlsl_functionality1", ExactSpelling = true)]
    public static extern void compile_options_set_hlsl_functionality1([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte enable);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_hlsl_16bit_types"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_hlsl_16bit_types", ExactSpelling = true)]
    public static extern void compile_options_set_hlsl_16bit_types([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte enable);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_vulkan_rules_relaxed"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_vulkan_rules_relaxed", ExactSpelling = true)]
    public static extern void compile_options_set_vulkan_rules_relaxed([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte enable);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_invert_y"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_invert_y", ExactSpelling = true)]
    public static extern void compile_options_set_invert_y([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte enable);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_options_set_nan_clamp"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_options_set_nan_clamp", ExactSpelling = true)]
    public static extern void compile_options_set_nan_clamp([NativeTypeName("shaderc_compile_options_t")] shaderc_compile_options* options, [NativeTypeName("bool")] byte enable);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_into_spv"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_into_spv", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compilation_result_t")]
    public static extern shaderc_compilation_result* compile_into_spv([NativeTypeName("const shaderc_compiler_t")] shaderc_compiler* compiler, [NativeTypeName("const char *")] sbyte* source_text, [NativeTypeName("size_t")] nuint source_text_size, [NativeTypeName("shaderc_shader_kind")] ShaderKind shader_kind, [NativeTypeName("const char *")] sbyte* input_file_name, [NativeTypeName("const char *")] sbyte* entry_point_name, [NativeTypeName("const shaderc_compile_options_t")] shaderc_compile_options* additional_options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_into_spv_assembly"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_into_spv_assembly", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compilation_result_t")]
    public static extern shaderc_compilation_result* compile_into_spv_assembly([NativeTypeName("const shaderc_compiler_t")] shaderc_compiler* compiler, [NativeTypeName("const char *")] sbyte* source_text, [NativeTypeName("size_t")] nuint source_text_size, [NativeTypeName("shaderc_shader_kind")] ShaderKind shader_kind, [NativeTypeName("const char *")] sbyte* input_file_name, [NativeTypeName("const char *")] sbyte* entry_point_name, [NativeTypeName("const shaderc_compile_options_t")] shaderc_compile_options* additional_options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.compile_into_preprocessed_text"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_compile_into_preprocessed_text", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compilation_result_t")]
    public static extern shaderc_compilation_result* compile_into_preprocessed_text([NativeTypeName("const shaderc_compiler_t")] shaderc_compiler* compiler, [NativeTypeName("const char *")] sbyte* source_text, [NativeTypeName("size_t")] nuint source_text_size, [NativeTypeName("shaderc_shader_kind")] ShaderKind shader_kind, [NativeTypeName("const char *")] sbyte* input_file_name, [NativeTypeName("const char *")] sbyte* entry_point_name, [NativeTypeName("const shaderc_compile_options_t")] shaderc_compile_options* additional_options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.assemble_into_spv"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_assemble_into_spv", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compilation_result_t")]
    public static extern shaderc_compilation_result* assemble_into_spv([NativeTypeName("const shaderc_compiler_t")] shaderc_compiler* compiler, [NativeTypeName("const char *")] sbyte* source_assembly, [NativeTypeName("size_t")] nuint source_assembly_size, [NativeTypeName("const shaderc_compile_options_t")] shaderc_compile_options* additional_options);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.result_release"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_result_release", ExactSpelling = true)]
    public static extern void result_release([NativeTypeName("shaderc_compilation_result_t")] shaderc_compilation_result* result);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.result_get_length"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_result_get_length", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint result_get_length([NativeTypeName("const shaderc_compilation_result_t")] shaderc_compilation_result* result);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.result_get_num_warnings"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_result_get_num_warnings", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint result_get_num_warnings([NativeTypeName("const shaderc_compilation_result_t")] shaderc_compilation_result* result);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.result_get_num_errors"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_result_get_num_errors", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint result_get_num_errors([NativeTypeName("const shaderc_compilation_result_t")] shaderc_compilation_result* result);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.result_get_compilation_status"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_result_get_compilation_status", ExactSpelling = true)]
    [return: NativeTypeName("shaderc_compilation_status")]
    public static extern CompilationStatus result_get_compilation_status([NativeTypeName("const shaderc_compilation_result_t")] shaderc_compilation_result* param0);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.result_get_bytes"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_result_get_bytes", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* result_get_bytes([NativeTypeName("const shaderc_compilation_result_t")] shaderc_compilation_result* result);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.result_get_error_message"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_result_get_error_message", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* result_get_error_message([NativeTypeName("const shaderc_compilation_result_t")] shaderc_compilation_result* result);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.get_spv_version"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_get_spv_version", ExactSpelling = true)]
    public static extern void get_spv_version([NativeTypeName("unsigned int *")] uint* version, [NativeTypeName("unsigned int *")] uint* revision);

    /// <include file='ShadercApi.xml' path='doc/member[@name="ShadercApi.parse_version_profile"]/*' />
    [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, EntryPoint = "shaderc_parse_version_profile", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte parse_version_profile([NativeTypeName("const char *")] sbyte* str, int* version, [NativeTypeName("shaderc_profile *")] Profile* profile);
}
