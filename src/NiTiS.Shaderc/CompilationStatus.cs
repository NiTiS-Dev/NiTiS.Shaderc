namespace NiTiS.Shaderc;

/// <summary>
/// Result status of the compilation.
/// </summary>
public enum CompilationStatus
{
	/// <summary>
	/// The result is success.
	/// </summary>
	Success = 0,

	/// <summary>
	/// Error stage deduction.
	/// </summary>
	InvalidStage = 1,

	/// <summary>
	/// Error during compilation.
	/// </summary>
	CompilationError = 2,

	/// <summary>
	/// Unexpected failure.
	/// </summary>
	InternalError = 3,

	/// <summary>
	/// The result is null.
	/// </summary>
	NullResultObject = 4,

	/// <summary>
	/// Input assembly is invalid.
	/// </summary>
	InvalidAssembly = 5,

	/// <summary>
	/// Error during validation.
	/// </summary>
	ValidationError = 6,

	/// <summary>
	/// Error during transformation.
	/// </summary>
	TransformationError = 7,

	/// <summary>
	/// Error during configuration.
	/// </summary>
	ConfigurationError = 8,
}