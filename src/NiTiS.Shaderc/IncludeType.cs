namespace NiTiS.Shaderc;

public enum IncludeType
{
	/// <summary>
	/// e.g. <c>#include "source" </c>
	/// </summary>
	Relative,
	/// <summary>
	/// e.g. <c>#include &lt;source&gt; </c>
	/// </summary>
	Standard,
}