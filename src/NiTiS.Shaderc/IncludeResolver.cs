using System;

namespace NiTiS.Shaderc;

public abstract unsafe class IncludeResolver : IDisposable
{
	internal ResolveInclude _resolve;
	internal ReleaseIncludeResult _release;

	protected IncludeResolver()
	{
		_resolve = Resolve;
		_release = ReleaseResult;
	}

	private IncludeResolver(ResolveInclude result, ReleaseIncludeResult release)
	{
		_resolve = result;
		_release = release;
	}

	public abstract IncludeResult* Resolve(void* userData, byte* requestedSource, IncludeType type, byte* requestingSource, nuint depth);

	public abstract void ReleaseResult(void* userData, IncludeResult* result);

	public static IncludeResolver Create(ResolveInclude resolve, ReleaseIncludeResult release)
	{
		return new UserProvidedResolver(resolve, release);
	}

	public void Dispose()
	{
		_resolve = null!;
		_release = null!;
	}

	private sealed class UserProvidedResolver : IncludeResolver
	{
		public UserProvidedResolver(ResolveInclude result, ReleaseIncludeResult release) : base(result, release) {}

		public override IncludeResult* Resolve(void* userData, byte* requestedSource, IncludeType type, byte* requestingSource, UIntPtr depth)
		{
			return _resolve(userData, requestedSource, type, requestingSource, depth);
		}

		public override void ReleaseResult(void* userData, IncludeResult* result)
		{
			_release(userData, result);
		}
	}
}