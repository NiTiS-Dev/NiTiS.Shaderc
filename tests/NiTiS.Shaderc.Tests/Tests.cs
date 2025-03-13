using System;

namespace NiTiS.Shaderc.Tests;

public class Tests
{
	[Test]
	public void LibraryResolve()
	{
		Assert.DoesNotThrow(() =>
		{
			using var compiler = ShadercApi.shaderc_compiler_initialize(); // If this throw DllNotFoundException or something similar, it's critical error
		});
	}

	[Test]
	public void Compile()
	{
		using var compiler = new CompilerHandle();
		using var options = new CompileOptionsHandle();

		ReadOnlySpan<byte> source =
			"""
			#version 330 core
			layout(location = 0) in vec3 aPos;
			void main()
			{
				gl_Position = vec4(aPos, 1.0);
			}
			"""u8;

		using var result = compiler.CompileIntoSpv(source, ShaderKind.VertexShader, "source.glsl\0"u8, "main\0"u8, options);

		Assert.That(result.Status, Is.EqualTo(CompilationStatus.Success));
	}

	[Test]
	public void CompileNoZeroTerminatorEntryPoint()
	{
		Assert.Throws<ArgumentException>(() =>
		{
			using var compiler = new CompilerHandle();
			using var options = new CompileOptionsHandle();

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
		});
	}

	[Test]
	public void CompileNoZeroTerminatorSourceName()
	{
		Assert.Throws<ArgumentException>(() =>
		{
			using var compiler = new CompilerHandle();
			using var options = new CompileOptionsHandle();

			ReadOnlySpan<byte> source =
				"""
			#version 330 core
			layout(location = 0) in vec3 aPos;
			void main()
			{
				gl_Position = vec4(aPos, 1.0);
			}
			"""u8;

			using var result = compiler.CompileIntoSpv(source, ShaderKind.VertexShader, "source.glsl"u8, "main\0"u8, options);
		});
	}

	[Test]
	public void CompileWithMacros()
	{
		using var compiler = new CompilerHandle();
		using var options = new CompileOptionsHandle();
		options.AddMacros("VOID_T", "void");
		options.AddMacros("GL_POSITION"u8, "gl_Position"u8);

		ReadOnlySpan<byte> source =
			"""
			#version 330 core
			layout(location = 0) in vec3 aPos;
			VOID_T main()
			{
				GL_POSITION = vec4(aPos, 1.0);
			}
			"""u8;

		using var result = compiler.CompileIntoSpv(source, ShaderKind.VertexShader, "source.glsl\0"u8, "main\0"u8, options);

		Assert.That(result.Status, Is.EqualTo(CompilationStatus.Success));
	}
}
