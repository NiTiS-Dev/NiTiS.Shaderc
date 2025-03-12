namespace NiTiS;

/// <summary>
/// Resource limits.
/// </summary>
public enum Limit
{
	/// <summary>
	/// Maximum number of lights.
	/// </summary>
	MaxLights,
	/// <summary>
	/// Maximum number of clip planes.
	/// </summary>
	MaxClipPlanes,
	/// <summary>
	/// Maximum number of texture units.
	/// </summary>
	MaxTextureUnits,
	/// <summary>
	/// Maximum number of texture coordinates.
	/// </summary>
	MaxTextureCoordinates,
	/// <summary>
	/// Maximum number of vertex attributes.
	/// </summary>
	MaxVertexAttributes,
	/// <summary>
	/// Maximum number of vertex uniform components.
	/// </summary>
	MaxVertexUniformComponents,
	/// <summary>
	/// Maximum number of varying floats.
	/// </summary>
	MaxVaryingFloats,
	/// <summary>
	/// Maximum number of vertex texture image units.
	/// </summary>
	MaxVertexTextureImageUnits,
	/// <summary>
	/// Maximum number of combined texture image units.
	/// </summary>
	MaxCombinedTextureImageUnits,
	/// <summary>
	/// Maximum number of texture image units.
	/// </summary>
	MaxTextureImageUnits,
	/// <summary>
	/// Maximum number of fragment uniform components.
	/// </summary>
	MaxFragmentUniformComponents,
	/// <summary>
	/// Maximum number of draw buffers.
	/// </summary>
	MaxDrawBuffers,
	/// <summary>
	/// Maximum number of vertex uniform vectors.
	/// </summary>
	MaxVertexUniformVectors,
	/// <summary>
	/// Maximum number of varying vectors.
	/// </summary>
	MaxVaryingVectors,
	/// <summary>
	/// Maximum number of fragment uniform vectors.
	/// </summary>
	MaxFragmentUniformVectors,
	/// <summary>
	/// Maximum number of vertex output vectors.
	/// </summary>
	MaxVertexOutputVectors,
	/// <summary>
	/// Maximum number of fragment input vectors.
	/// </summary>
	MaxFragmentInputVectors,
	/// <summary>
	/// Minimum program texel offset.
	/// </summary>
	MinProgramTexelOffset,
	/// <summary>
	/// Maximum program texel offset.
	/// </summary>
	MaxProgramTexelOffset,
	/// <summary>
	/// Maximum number of clip distances.
	/// </summary>
	MaxClipDistances,
	/// <summary>
	/// Maximum number of compute work group count x.
	/// </summary>
	MaxComputeWorkGroupCountX,
	/// <summary>
	/// Maximum number of compute work group count y.
	/// </summary>
	MaxComputeWorkGroupCountY,
	/// <summary>
	/// Maximum number of compute work group count z.
	/// </summary>
	MaxComputeWorkGroupCountZ,
	/// <summary>
	/// Maximum number of compute work group size x.
	/// </summary>
	MaxComputeWorkGroupSizeX,
	/// <summary>
	/// Maximum number of compute work group size y.
	/// </summary>
	MaxComputeWorkGroupSizeY,
	/// <summary>
	/// Maximum number of compute work group size z.
	/// </summary>
	MaxComputeWorkGroupSizeZ,
	/// <summary>
	/// Maximum number of compute uniform components.
	/// </summary>
	MaxComputeUniformComponents,
	/// <summary>
	/// Maximum number of compute texture image units.
	/// </summary>
	MaxComputeTextureImageUnits,
	/// <summary>
	/// Maximum number of compute image uniforms.
	/// </summary>
	MaxComputeImageUniforms,
	/// <summary>
	/// Maximum number of compute atomic counters.
	/// </summary>
	MaxComputeAtomicCounters,
	/// <summary>
	/// Maximum number of compute atomic counter buffers.
	/// </summary>
	MaxComputeAtomicCounterBuffers,
	/// <summary>
	/// Maximum number of varying components.
	/// </summary>
	MaxVaryingComponents,
	/// <summary>
	/// Maximum number of vertex output components.
	/// </summary>
	MaxVertexOutputComponents,
	/// <summary>
	/// Maximum number of geometry input components.
	/// </summary>
	MaxGeometryInputComponents,
	/// <summary>
	/// Maximum number of geometry output components.
	/// </summary>
	MaxGeometryOutputComponents,
	/// <summary>
	/// Maximum number of fragment input components.
	/// </summary>
	MaxFragmentInputComponents,
	/// <summary>
	/// Maximum number of image units.
	/// </summary>
	MaxImageUnits,
	/// <summary>
	/// Maximum number of combined image units and fragment outputs.
	/// </summary>
	MaxCombinedImageUnitsAndFragmentOutputs,
	/// <summary>
	/// Maximum number of combined shader output resources.
	/// </summary>
	MaxCombinedShaderOutputResources,
	/// <summary>
	/// Maximum number of image samples.
	/// </summary>
	MaxImageSamples,
	/// <summary>
	/// Maximum number of vertex image uniforms.
	/// </summary>
	MaxVertexImageUniforms,
	/// <summary>
	/// Maximum number of tessellation control image uniforms.
	/// </summary>
	MaxTessControlImageUniforms,
	/// <summary>
	/// Maximum number of tessellation evaluation image uniforms.
	/// </summary>
	MaxTessEvaluationImageUniforms,
	/// <summary>
	/// Maximum number of geometry image uniforms.
	/// </summary>
	MaxGeometryImageUniforms,
	/// <summary>
	/// Maximum number of fragment image uniforms.
	/// </summary>
	MaxFragmentImageUniforms,
	/// <summary>
	/// Maximum number of combined image uniforms.
	/// </summary>
	MaxCombinedImageUniforms,
	/// <summary>
	/// Maximum number of geometry texture image units.
	/// </summary>
	MaxGeometryTextureImageUnits,
	/// <summary>
	/// Maximum number of geometry output vertices.
	/// </summary>
	MaxGeometryOutputVertices,
	/// <summary>
	/// Maximum number of geometry total output components.
	/// </summary>
	MaxGeometryTotalOutputComponents,
	/// <summary>
	/// Maximum number of geometry uniform components.
	/// </summary>
	MaxGeometryUniformComponents,
	/// <summary>
	/// Maximum number of geometry varying components.
	/// </summary>
	MaxGeometryVaryingComponents,
	/// <summary>
	/// Maximum number of tessellation control input components.
	/// </summary>
	MaxTessControlInputComponents,
	/// <summary>
	/// Maximum number of tessellation control output components.
	/// </summary>
	MaxTessControlOutputComponents,
	/// <summary>
	/// Maximum number of tessellation control texture image units.
	/// </summary>
	MaxTessControlTextureImageUnits,
	/// <summary>
	/// Maximum number of tessellation control uniform components.
	/// </summary>
	MaxTessControlUniformComponents,
	/// <summary>
	/// Maximum number of tessellation control total output components.
	/// </summary>
	MaxTessControlTotalOutputComponents,
	/// <summary>
	/// Maximum number of tessellation evaluation input components.
	/// </summary>
	MaxTessEvaluationInputComponents,
	/// <summary>
	/// Maximum number of tessellation evaluation output components.
	/// </summary>
	MaxTessEvaluationOutputComponents,
	/// <summary>
	/// Maximum number of tessellation evaluation texture image units.
	/// </summary>
	MaxTessEvaluationTextureImageUnits,
	/// <summary>
	/// Maximum number of tessellation evaluation uniform components.
	/// </summary>
	MaxTessEvaluationUniformComponents,
	/// <summary>
	/// Maximum number of tessellation patch components.
	/// </summary>
	MaxTessPatchComponents,
	/// <summary>
	/// Maximum number of patch vertices.
	/// </summary>
	MaxPatchVertices,
	/// <summary>
	/// Maximum number of tessellation gen level.
	/// </summary>
	MaxTessGenLevel,
	/// <summary>
	/// Maximum number of viewports.
	/// </summary>
	MaxViewports,
	/// <summary>
	/// Maximum number of vertex atomic counters.
	/// </summary>
	MaxVertexAtomicCounters,
	/// <summary>
	/// Maximum number of tessellation control atomic counters.
	/// </summary>
	MaxTessControlAtomicCounters,
	/// <summary>
	/// Maximum number of tessellation evaluation atomic counters.
	/// </summary>
	MaxTessEvaluationAtomicCounters,
	/// <summary>
	/// Maximum number of geometry atomic counters.
	/// </summary>
	MaxGeometryAtomicCounters,
	/// <summary>
	/// Maximum number of fragment atomic counters.
	/// </summary>
	MaxFragmentAtomicCounters,
	/// <summary>
	/// Maximum number of combined atomic counters.
	/// </summary>
	MaxCombinedAtomicCounters,
	/// <summary>
	/// Maximum number of atomic counter bindings.
	/// </summary>
	MaxAtomicCounterBindings,
	/// <summary>
	/// Maximum number of vertex atomic counter buffers.
	/// </summary>
	MaxVertexAtomicCounterBuffers,
	/// <summary>
	/// Maximum number of tessellation control atomic counter buffers.
	/// </summary>
	MaxTessControlAtomicCounterBuffers,
	/// <summary>
	/// Maximum number of tessellation evaluation atomic counter buffers.
	/// </summary>
	MaxTessEvaluationAtomicCounterBuffers,
	/// <summary>
	/// Maximum number of geometry atomic counter buffers.
	/// </summary>
	MaxGeometryAtomicCounterBuffers,
	/// <summary>
	/// Maximum number of fragment atomic counter buffers.
	/// </summary>
	MaxFragmentAtomicCounterBuffers,
	/// <summary>
	/// Maximum number of combined atomic counter buffers.
	/// </summary>
	MaxCombinedAtomicCounterBuffers,
	/// <summary>
	/// Maximum number of atomic counter buffer size.
	/// </summary>
	MaxAtomicCounterBufferSize,
	/// <summary>
	/// Maximum number of transform feedback buffers.
	/// </summary>
	MaxTransformFeedbackBuffers,
	/// <summary>
	/// Maximum number of transform feedback interleaved components.
	/// </summary>
	MaxTransformFeedbackInterleavedComponents,
	/// <summary>
	/// Maximum number of cull distances.
	/// </summary>
	MaxCullDistances,
	/// <summary>
	/// Maximum number of combined clip and cull distances.
	/// </summary>
	MaxCombinedClipAndCullDistances,
	/// <summary>
	/// Maximum number of samples.
	/// </summary>
	MaxSamples,
	/// <summary>
	/// Maximum number of mesh output vertices (NVIDIA extension).
	/// </summary>
	MaxMeshOutputVerticesNv,
	/// <summary>
	/// Maximum number of mesh output primitives (NVIDIA extension).
	/// </summary>
	MaxMeshOutputPrimitivesNv,
	/// <summary>
	/// Maximum number of mesh work group size x (NVIDIA extension).
	/// </summary>
	MaxMeshWorkGroupSizeXNv,
	/// <summary>
	/// Maximum number of mesh work group size y (NVIDIA extension).
	/// </summary>
	MaxMeshWorkGroupSizeYNv,
	/// <summary>
	/// Maximum number of mesh work group size z (NVIDIA extension).
	/// </summary>
	MaxMeshWorkGroupSizeZNv,
	/// <summary>
	/// Maximum number of task work group size x (NVIDIA extension).
	/// </summary>
	MaxTaskWorkGroupSizeXNv,
	/// <summary>
	/// Maximum number of task work group size y (NVIDIA extension).
	/// </summary>
	MaxTaskWorkGroupSizeYNv,
	/// <summary>
	/// Maximum number of task work group size z (NVIDIA extension).
	/// </summary>
	MaxTaskWorkGroupSizeZNv,
	/// <summary>
	/// Maximum number of mesh view count (NVIDIA extension).
	/// </summary>
	MaxMeshViewCountNv,
	/// <summary>
	/// Maximum number of mesh output vertices (EXT extension).
	/// </summary>
	MaxMeshOutputVerticesExt,
	/// <summary>
	/// Maximum number of mesh output primitives (EXT extension).
	/// </summary>
	MaxMeshOutputPrimitivesExt,
	/// <summary>
	/// Maximum number of mesh work group size x (EXT extension).
	/// </summary>
	MaxMeshWorkGroupSizeXExt,
	/// <summary>
	/// Maximum number of mesh work group size y (EXT extension).
	/// </summary>
	MaxMeshWorkGroupSizeYExt,
	/// <summary>
	/// Maximum number of mesh work group size z (EXT extension).
	/// </summary>
	MaxMeshWorkGroupSizeZExt,
	/// <summary>
	/// Maximum number of task work group size x (EXT extension).
	/// </summary>
	MaxTaskWorkGroupSizeXExt,
	/// <summary>
	/// Maximum number of task work group size y (EXT extension).
	/// </summary>
	MaxTaskWorkGroupSizeYExt,
	/// <summary>
	/// Maximum number of task work group size z (EXT extension).
	/// </summary>
	MaxTaskWorkGroupSizeZExt,
	/// <summary>
	/// Maximum number of mesh view count (EXT extension).
	/// </summary>
	MaxMeshViewCountExt,
	/// <summary>
	/// Maximum number of dual source draw buffers (EXT extension).
	/// </summary>
	MaxDualSourceDrawBuffersExt,
}