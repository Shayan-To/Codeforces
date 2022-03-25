using System;

namespace Infra
{
    public static class Paths
    {
        public static string ProjectRoot { get; } = PathAttribute.GetPath(nameof(ProjectRoot)) ?? throw new Exception($"Could not find path '{nameof(ProjectRoot)}'.");
        public static string GenerationRoot { get; } = PathAttribute.GetPath(nameof(GenerationRoot)) ?? throw new Exception($"Could not find path '{nameof(GenerationRoot)}'.");
    }
}
