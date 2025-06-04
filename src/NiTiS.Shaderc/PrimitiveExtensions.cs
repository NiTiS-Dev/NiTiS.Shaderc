using System.Runtime.CompilerServices;

namespace NiTiS.Shaderc;

internal static class PrimitiveExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ToBool(this byte b)
	{
#if NET9_0_OR_GREATER
		return Unsafe.BitCast<byte, bool>(b);
#else
		return Unsafe.As<byte, bool>(ref b);
#endif
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte ToByte(this bool b)
	{
#if NET9_0_OR_GREATER
		return Unsafe.BitCast<bool, byte>(b);
#else
		return Unsafe.As<bool, byte>(ref b);
#endif
	}
}