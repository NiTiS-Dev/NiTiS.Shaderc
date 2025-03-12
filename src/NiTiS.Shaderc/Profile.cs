namespace NiTiS.Shaderc;

/// <summary>
/// Version profile.
/// </summary>
public enum Profile
{
	/// <summary>
	/// Used if and only if GLSL version did not specify profiles.
	/// </summary>
	None,

	/// <summary>
	/// Core version profile.
	/// </summary>
	Core,

	/// <summary>
	/// Compatibility version profile.
	/// </summary>
	/// <remarks>
	/// Disabled; this generates an error.
	/// </remarks>
	Compatibility,

	/// <summary>
	/// ES version profile.
	/// </summary>
	ES,
}