namespace Smart.Reflection;

public static class ReflectionHelper
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Ignore")]
    static ReflectionHelper()
    {
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
    }

    public static bool IsCodegenAllowed { get; }
}
