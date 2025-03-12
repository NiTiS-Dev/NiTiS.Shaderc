namespace NiTiS.Shaderc;

/// <summary>
/// Target compiler semantics.
/// </summary>
public enum TargetEnvironment
{
	/// <summary>
	/// SPIR-V under Vulkan semantics.
	/// </summary>
	Vulkan,

	/// <summary>
	/// SPIR-V under OpenGL semantics.
	/// </summary>
	OpenGL,

	/// <summary>
	/// SPIR-V under OpenGL semantics, including compatibility profile functions.
	/// </summary>
	/// <remarks>
	/// SPIR-V code generation is not supported for shaders under OpenGL compatibility profile.
	/// </remarks>
	OpenGLCompatible,

	/// <summary>
	/// Deprecated, SPIR-V under WebGPU semantics.
	/// </summary>
	WebGPU,

	/// <summary>
	/// Alias for <see cref="Vulkan"/>.
	/// </summary>
	Default = Vulkan,
}