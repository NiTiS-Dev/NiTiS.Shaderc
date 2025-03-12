using System;
using System.Runtime.CompilerServices;

namespace NiTiS.Shaderc;

/// <summary>
/// Compilation result handle.
/// </summary>
public readonly struct CompilationResultHandle : IDisposable
{
	/// <summary>
	/// Native result handle.
	/// </summary>
	public readonly IntPtr Handle;

	internal CompilationResultHandle(nint handle)
	{
		Handle = handle;
	}

	/// <summary>
	/// Status of compilation.
	/// </summary>
	public CompilationStatus Status
	{
		get
		{
			return shaderc_result_get_compilation_status(this);
		}
	}

	/// <summary>
	/// Length of compilation output.
	/// </summary>
	public nuint Length
	{
		get
		{
			return shaderc_result_get_length(this);
		}
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		shaderc_result_release(this);
	}

	/// <summary>
	/// Copy result output into provided span.
	/// </summary>
	/// <param name="output">The span to store output.</param>
	/// <returns>Amount of copied bytes.</returns>
	public unsafe nuint CopyTo(Span<byte> output)
	{
		byte* src = shaderc_result_get_bytes(this);

		nuint length = (ulong)output.Length > Length ? (nuint)output.Length : Length;

		fixed (byte* pOutput = output)
		{
			Unsafe.CopyBlockUnaligned(pOutput, src, (uint)length);
		}

		return length;
	}
}