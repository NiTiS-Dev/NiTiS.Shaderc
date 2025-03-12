namespace NiTiS.Shaderc;

public unsafe struct IncludeResult
{
	public byte* SourceName;
	public nuint SourceNameLength;

	public byte* Content;
	public nuint ContentLength;

	public void* UserData;
}