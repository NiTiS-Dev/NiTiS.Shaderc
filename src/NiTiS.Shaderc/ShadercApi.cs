global using static NiTiS.Shaderc.ShadercApi;
using System.Runtime.InteropServices;

namespace NiTiS.Shaderc;

public static unsafe partial class ShadercApi
{
	private const string LibraryName = "shaderc_shared";

	//static ShadercApi()
	//{
	//	NativeLibrary.SetDllImportResolver(typeof(ShadercApi).Assembly, DllImportResolve);
	//}

	//private static nint DllImportResolve(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
	//{
	//	if (libraryName != LibraryName)
	//		return NativeLibrary.Load(libraryName, assembly, searchPath); // There is no recursive calling


	//}

	[LibraryImport(LibraryName)]
	public static partial ShaderCompiler shaderc_compiler_initialize();

	[LibraryImport(LibraryName)]
	public static partial void shaderc_compiler_release(ShaderCompiler handle);

	[LibraryImport(LibraryName)]
	public static partial ShaderCompilerOptions shaderc_compile_options_initialize();

	[LibraryImport(LibraryName)]
	public static partial ShaderCompilerOptions shaderc_compile_options_clone(ShaderCompilerOptions options);

	[LibraryImport(LibraryName)]
	public static partial void shaderc_compile_options_release(ShaderCompilerOptions options);

	[LibraryImport(LibraryName)]
	public static partial void shaderc_compile_options_add_macro_definition(
		ShaderCompilerOptions options,
		byte* name,
		nuint nameLength,
		byte* value,
		nuint valueLength
	);

	[LibraryImport(LibraryName)]
	public static partial void shaderc_compile_options_set_source_language(ShaderCompilerOptions options, SourceLanguage lang);

	[LibraryImport(LibraryName)]
	public static partial void shaderc_compile_options_set_generate_debug_info(ShaderCompilerOptions options);

	[LibraryImport(LibraryName)]
	public static partial void shaderc_compile_options_set_optimization_level(ShaderCompilerOptions options, OptimizationLevel optimization);

	[LibraryImport(LibraryName)]
	public static partial void shaderc_compile_options_set_forced_version_profile(ShaderCompilerOptions options, int version, Profile profile);

	
}