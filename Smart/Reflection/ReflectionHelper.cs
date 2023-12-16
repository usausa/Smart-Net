namespace Smart.Reflection;

public static class ReflectionHelper
{
    static ReflectionHelper()
    {
#pragma warning disable CA1031
        try
        {
            var type = Type.GetType("System.Reflection.Emit.DynamicMethod");
            if (type is not null)
            {
                Activator.CreateInstance(type, string.Empty, typeof(object), Type.EmptyTypes, true);
                IsCodegenAllowed = true;
            }
        }
        catch
        {
            // Ignore
        }
#pragma warning restore CA1031
    }

    public static bool IsCodegenAllowed { get; }
}
