using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiTiS;

/// <summary>
/// Uniform resource kinds.
/// </summary>
/// <remarks>
/// In Vulkan, uniform resources are bound to the pipeline via descriptors with numbered bindings and sets.
/// </remarks>
public enum UniformKind
{
	/// <summary>
	/// Image and image buffer.
	/// </summary>
	Image,
	/// <summary>
	/// Pure sampler.
	/// </summary>
	Sampler,
	/// <summary>
	/// Sampled texture in GLSL, and Shader Resource View in HLSL.
	/// </summary>
	Texture,
	/// <summary>
	/// Uniform Buffer Object (UBO) in GLSL. Cbuffer in HLSL.
	/// </summary>
	Buffer,
	/// <summary>
	/// Shader Storage Buffer Object (SSBO) in GLSL.
	/// </summary>
	StorageBuffer,
	/// <summary>
	/// Unordered Access View, in HLSL; (Writable storage image or storage buffer).
	/// </summary>
	UnorderedAccessView,
}