using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Unicode;

namespace NiTiS.Shaderc;

public static unsafe class Utf8String
{
	public static byte* AllocateNullTerminated(string str)
	{
		int size = Encoding.UTF8.GetByteCount(str);
		byte* pBuffer = (byte*)Marshal.AllocHGlobal(size + 1);

		fixed (char* pStr = str)
		{
			Encoding.UTF8.GetBytes(pStr, size, pBuffer, size);
		}

		pBuffer[size] = 0;
		return pBuffer;
	}

	public static byte* AllocateNotNullTerminated(string str, out nuint size)
	{
		size = (nuint)Encoding.UTF8.GetByteCount(str);
		byte* pBuffer = (byte*)Marshal.AllocHGlobal((int)size);

		fixed (char* pStr = str)
		{
			size = (nuint)Encoding.UTF8.GetBytes(pStr, (int)size, pBuffer, (int)size);
		}

		return pBuffer;
	}

	public static void Free(byte* pointer)
	{
		Marshal.FreeHGlobal((nint)pointer);
	}
}