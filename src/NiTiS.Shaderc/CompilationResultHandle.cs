using CommunityToolkit.Diagnostics;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

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

	/// <summary>
	/// Amount of compilation warnings.
	/// </summary>
	public nuint WarningCount
	{
		get
		{
			return shaderc_result_get_num_warnings(this);
		}
	}

	/// <summary>
	/// Amount of compilation errors.
	/// </summary>
	public nuint ErrorCount
	{
		get
		{
			return shaderc_result_get_num_errors(this);
		}
	}

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

			byte* message = shaderc_result_get_error_message(this);
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
		shaderc_result_release(this);
	}

	/// <summary>
	/// Creates byte array of compilation result.
	/// </summary>
	/// <returns>New allocated array with compilation result, if compilation is success; otherwise <see langword="null"/>.</returns>
	public byte[]? CreateResultArray()
	{
		if (Status == CompilationStatus.Success)
		{
			byte[] result = new byte[Length];

			CopyTo(result.AsSpan());
		}

		return null;
	}

	/// <summary>
	/// Copy result output into provided span.
	/// </summary>
	/// <param name="output">The span to store output.</param>
	public unsafe void CopyTo(Span<byte> output)
	{
		byte* src = shaderc_result_get_bytes(this);

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
	public unsafe void CopyTo(byte[] output, int offset)
	{
		Guard.IsNotNull(output);

		if (offset < 0 || (nuint)(output.Length - offset) < Length)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(nameof(offset), "Provided array doesn't have enough length to store the result.");
		}

		byte* src = shaderc_result_get_bytes(this);

		fixed (byte* pOutput = output)
		{
			Unsafe.CopyBlockUnaligned(pOutput + offset, src, (uint)Length);
		}
	}
}