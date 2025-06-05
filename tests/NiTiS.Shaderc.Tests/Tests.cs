using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace NiTiS.Shaderc.Tests;

public class Tests
{
	[Test]
	public void LibraryResolve()
	{
		Assert.DoesNotThrow(() =>
		{
			using var compiler = new ShaderCompiler(); // If this throw DllNotFoundException or something similar, it's critical error
		});
	}

	[Test]
	public void Parse()
	{
		bool result = ShaderCompiler.TryParseVersionProfile("450core", out int version, out Profile profile);

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.True);
			Assert.That(version, Is.EqualTo(450));
			Assert.That(profile, Is.EqualTo(Profile.Core));
		});

		result = ShaderCompiler.TryParseVersionProfile("450core"u8, out version, out profile);

		Assert.Multiple(() =>
		{
			Assert.That(result, Is.True);
			Assert.That(version, Is.EqualTo(450));
			Assert.That(profile, Is.EqualTo(Profile.Core));
		});
	}

	[Test]
	public void Compile()
	{
		using var compiler = new ShaderCompiler();
		using var options = new CompileOptions();

		ReadOnlySpan<byte> source =
			"""
			#version 330 core
			layout(location = 0) in vec3 aPos;
			void main()
			{
				gl_Position = vec4(aPos, 1.0);
			}
			"""u8;

		using var result = compiler.CompileIntoSpv(source, ShaderKind.VertexShader, "source.glsl"u8, "main"u8, options);

		Assert.That(result.Status, Is.EqualTo(CompilationStatus.Success));
	}

	[Test]
	public void CompileWithMacros()
	{
		using var compiler = new ShaderCompiler();
		using var options = new CompileOptions();
		options.AddMacro("VOID_T", "void");
		options.AddMacro("GL_POSITION"u8, "gl_Position"u8);

		ReadOnlySpan<byte> source =
			"""
			#version 330 core
			layout(location = 0) in vec3 aPos;
			VOID_T main()
			{
				GL_POSITION = vec4(aPos, 1.0);
			}
			"""u8;

		using var result = compiler.CompileIntoSpv(source, ShaderKind.VertexShader, "source.glsl"u8, "main"u8, options);

		Assert.That(result.Status, Is.EqualTo(CompilationStatus.Success));
	}

	[Test]
	public unsafe void CustomIncludeCallbacks()
	{
		using var compiler = new ShaderCompiler();
		using var options = new CompileOptions();
		using var callbacks = IncludeResolver.Create(
			(userData, requested, includeType, requestor, depth) =>
			{
				Console.WriteLine($"{(nuint)userData}, {(nuint)requested}, {(nuint)requestor}, {includeType}");
				Assert.Multiple(() =>
				{
					Assert.That(Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(requested)), Is.EqualTo("core.glsl"));
					Assert.That(Encoding.UTF8.GetString(MemoryMarshal.CreateReadOnlySpanFromNullTerminated(requestor)), Is.EqualTo("source.glsl"));
				});

				IncludeResult* result = (IncludeResult*)NativeMemory.AllocZeroed((nuint)sizeof(IncludeResult));

				ReadOnlySpan<byte> content = """
				                             layout(location = 0) in vec3 aPos;
				                             void main()
				                             {
				                             	gl_Position = vec4(aPos, 1.0);
				                             }
				                             """u8;

				result->ContentLength = (nuint)content.Length;
				result->ContentPtr = (byte*)NativeMemory.AllocZeroed(result->ContentLength);

				result->SourceNameLength = 10;
				result->SourceNamePtr = (byte*)NativeMemory.AllocZeroed((nuint)"core.glsl"u8.Length);

				fixed (byte* pContent = content)
				{
					Buffer.MemoryCopy(pContent, result->ContentPtr, result->ContentLength, result->ContentLength);
				}

				fixed (byte* pName = "core.glsl"u8)
				{
					Buffer.MemoryCopy(pName, result->SourceNamePtr, result->SourceNameLength, result->SourceNameLength);
				}

				return result;
			},
			(_, _) => {}
		);
		options.ProvideIncludeResolver(callbacks);

		ReadOnlySpan<byte> source =
			"""
			#version 330 core
			#include "core.glsl"
			"""u8;

		using var result = compiler.CompileIntoSpv(source, ShaderKind.VertexShader, "source.glsl\0"u8, "main\0"u8, options);

		if (result.ErrorCount != 0)
		{
			Assert.Warn(result.ErrorMessage ?? string.Empty);
		}

		Assert.That(result.Status, Is.EqualTo(CompilationStatus.Success));

		GC.KeepAlive(callbacks);
	}
}
