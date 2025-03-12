namespace NiTiS.Shaderc;

/// <summary>
/// Result of include directive.
/// </summary>
public unsafe struct IncludeResult
{
	/// <summary>
	/// Utf8 source name.
	/// </summary>
	public byte* SourceName;

	/// <summary>
	/// Source name length in bytes.
	/// </summary>
	public nuint SourceNameLength;

	/// <summary>
	/// Utf8 source content.
	/// </summary>
	public byte* Content;

	/// <summary>
	/// Source content length in bytes.
	/// </summary>
	public nuint ContentLength;

	/// <summary>
	/// Custom data.
	/// </summary>
	public void* UserData;
}