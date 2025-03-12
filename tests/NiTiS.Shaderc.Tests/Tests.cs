namespace NiTiS.Shaderc.Tests;

public class Tests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void LibraryLoading()
	{
		Assert.DoesNotThrow(() =>
		{
			using var compiler = ShadercApi.shaderc_compiler_initialize();
		});
	}
}
