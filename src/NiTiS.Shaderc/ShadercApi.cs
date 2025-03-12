namespace NiTiS.Shaderc;

public unsafe static partial class ShadercApi
{
	/// <summary>
	/// Acquire SPIR-V version.
	/// </summary>
	/// <returns>Version tuple.</returns>
	public static (uint Version, uint Revision) GetSPVVersion()
	{
		uint version, revision;
		shaderc_get_spv_version(&version, &revision);
		return (version, revision);
	}
}