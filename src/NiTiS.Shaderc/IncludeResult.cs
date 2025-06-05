using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NiTiS.Shaderc.LowLevel;

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

	public static implicit operator shaderc_include_result(IncludeResult self)
	{
		return Unsafe.As<IncludeResult, shaderc_include_result>(ref self);
	}

	public static implicit operator IncludeResult(shaderc_include_result self)
	{
		return Unsafe.As<shaderc_include_result, IncludeResult>(ref self);
	}
}