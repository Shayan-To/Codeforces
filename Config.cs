using System;

namespace Infra
{
    public static class Config
    {
        public static readonly Type Solution = typeof(C282.A);
        public static readonly Mode Mode = Mode.GenerateAndRun;
        public static class Generation
        {
            public static readonly bool ClearRoot = true;
            public static string GetFileName(Type sol) => $"{sol.Namespace}-{sol.Name}";
        }
    }

    public enum Mode
    {
        Run = 1,
        Generate = 2,
        GenerateAndRun = Generate | Run,
        GenerateAll = Generate | 4,
    }
}
