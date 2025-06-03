namespace NiTiS.Shaderc.LowLevel;

/// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version"]/*' />
public enum shaderc_env_version
{
    /// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version.shaderc_env_version_vulkan_1_0"]/*' />
    shaderc_env_version_vulkan_1_0 = ((1U << 22)),

    /// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version.shaderc_env_version_vulkan_1_1"]/*' />
    shaderc_env_version_vulkan_1_1 = ((1U << 22) | (1 << 12)),

    /// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version.shaderc_env_version_vulkan_1_2"]/*' />
    shaderc_env_version_vulkan_1_2 = ((1U << 22) | (2 << 12)),

    /// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version.shaderc_env_version_vulkan_1_3"]/*' />
    shaderc_env_version_vulkan_1_3 = ((1U << 22) | (3 << 12)),

    /// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version.shaderc_env_version_vulkan_1_4"]/*' />
    shaderc_env_version_vulkan_1_4 = ((1U << 22) | (4 << 12)),

    /// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version.shaderc_env_version_opengl_4_5"]/*' />
    shaderc_env_version_opengl_4_5 = 450,

    /// <include file='shaderc_env_version.xml' path='doc/member[@name="shaderc_env_version.shaderc_env_version_webgpu"]/*' />
    shaderc_env_version_webgpu,
}
