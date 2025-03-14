using System.Runtime.InteropServices;

namespace NiTiS.Shaderc;

/// <summary>
/// Result of include directive.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IncludeResult
{
	/// <summary>
	/// Pointer to Utf8 source name.
	/// </summary>
	public byte* SourceNamePtr;

	/// <summary>
	/// Source name length in bytes.
	/// </summary>
	public nuint SourceNameLength;

	/// <summary>
	/// Pointer to Utf8 source content.
	/// </summary>
	public byte* ContentPtr;

	/// <summary>
	/// Source content length in bytes.
	/// </summary>
	public nuint ContentLength;

	/// <summary>
	/// Custom data.
	/// </summary>
	public void* UserData;
}