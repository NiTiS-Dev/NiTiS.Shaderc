namespace NiTiS.Shaderc;

/// <summary>
/// Level of optimization.
/// </summary>
public enum OptimizationLevel
{
	/// <summary>
	/// No/Default optimization.
	/// </summary>
	Zero,

	/// <summary>
	/// Optimization for lesser output size.
	/// </summary>
	Size,

	/// <summary>
	/// Optimization for better performance.
	/// </summary>
	Performance,
}