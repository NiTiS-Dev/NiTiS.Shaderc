namespace NiTiS.Shaderc;

/// <summary>
/// Environment version.
/// </summary>
public enum EnvironmentVersion : uint
{
	/// <summary>
	/// Vulkan 1.0 version.
	/// </summary>
	Vulkan1_0 = ((1u << 22)),

	/// <summary>
	/// Vulkan 1.1 version.
	/// </summary>
	Vulkan1_1 = ((1u << 22) | (1 << 12)),

	/// <summary>
	/// Vulkan 1.2 version.
	/// </summary>
	Vulkan1_2 = ((1u << 22) | (2 << 12)),

	/// <summary>
	/// Vulkan 1.3 version.
	/// </summary>
	Vulkan1_3 = ((1u << 22) | (3 << 12)),

	/// <summary>
	/// Vulkan 1.4 version.
	/// </summary>
	Vulkan1_4 = ((1u << 22) | (4 << 12)),

	/// <summary>
	/// For OpenGL, use the number from #version in shaders.
	/// </summary>
	OpenGL4_5 = 450,

	/// <summary>
	/// Deprecated, WebGPU environment never defined versions.
	/// </summary>
	WebGPU,
}