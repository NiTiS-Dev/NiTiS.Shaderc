using CommunityToolkit.Diagnostics;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using NiTiS.Shaderc.LowLevel;

namespace NiTiS.Shaderc;

/// <summary>
/// Compilation result.
/// </summary>
public readonly unsafe struct CompilationResult : IDisposable, IEquatable<CompilationResult>
{
	private readonly shaderc_compilation_result* _result;

	/// <summary>
	/// Native result handle.
	/// </summary>
	public nint Handle => (nint)_result;

	public CompilationResult(shaderc_compilation_result* result)
	{
		_result = result;
	}

	/// <summary>
	/// Status of compilation.
	/// </summary>
	public CompilationStatus Status => ShadercApi.result_get_compilation_status(_result);

	/// <summary>
	/// Length of compilation output.
	/// </summary>
	public nuint Length => ShadercApi.result_get_length(_result);

	/// <summary>
	/// Amount of compilation warnings.
	/// </summary>
	public nuint WarningCount => ShadercApi.result_get_num_warnings(_result);

	/// <summary>
	/// Amount of compilation errors.
	/// </summary>
	public nuint ErrorCount => ShadercApi.result_get_num_errors(_result);

	/// <summary>
	/// Compiler error message.
	/// </summary>
	public unsafe string? ErrorMessage
	{
		get
		{
			if (ErrorCount == 0)
			{
				return null;
			}

			byte* message = (byte*)ShadercApi.result_get_error_message(_result);
			Debug.Assert(message != null);
#if NET6_0_OR_GREATER
			ReadOnlySpan<byte> messageSpan = MemoryMarshal.CreateReadOnlySpanFromNullTerminated(message);

			return Encoding.UTF8.GetString(messageSpan);
#else
			int len;
			for (byte* p = message; ; p++)
			{
				if (*p == 0)
				{
					len = (int)((nuint)message - (nuint)p);
					break;
				}
			}

			return Encoding.UTF8.GetString(message, len);
#endif
		}
	}

	/// <inheritdoc/>
	public void Dispose()
	{
		ShadercApi.result_release(_result);
	}

	/// <summary>
	/// Creates byte array of compilation result.
	/// </summary>
	/// <returns>New allocated array with compilation result, if compilation is success; otherwise <see langword="null"/>.</returns>
	public byte[]? CreateResultArray()
	{
		if (Status != CompilationStatus.Success) return null;

		byte[] result = new byte[Length];

		CopyTo(result.AsSpan());

		return null;
	}

	/// <summary>
	/// Copy result output into provided span.
	/// </summary>
	/// <param name="output">The span to store output.</param>
	public void CopyTo(Span<byte> output)
	{
		byte* src = (byte*)ShadercApi.result_get_bytes(_result);

		if ((nuint)output.Length < Length)
		{
			ThrowHelper.ThrowArgumentException(nameof(output), "Provided span is not enough to store result.");
		}

		fixed (byte* pOutput = output)
		{
			Unsafe.CopyBlockUnaligned(pOutput, src, (uint)Length);
		}
	}

	/// <summary>
	/// Copy result output into provided array with a specified offset.
	/// </summary>
	/// <param name="output">The array to store output.</param>
	/// <param name="offset">The offset in the array where copying should start.</param>
	public void CopyTo(byte[] output, int offset)
	{
		Guard.IsNotNull(output);

		if (offset < 0 || (nuint)(output.Length - offset) < Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(nameof(offset), "Provided array doesn't have enough length to store the result.");
		}

		byte* src = (byte*)ShadercApi.result_get_bytes(_result);

		fixed (byte* pOutput = output)
		{
			Unsafe.CopyBlockUnaligned(pOutput + offset, src, (uint)Length);
		}
	}

	public bool Equals(CompilationResult other)
	{
		return _result == other._result;
	}

	public override bool Equals(object? obj)
	{
		return obj is CompilationResult other && Equals(other);
	}

	public override int GetHashCode()
	{
		return unchecked((int)(long)_result);
	}
}