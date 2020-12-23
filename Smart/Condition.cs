namespace Smart
{
    public delegate bool NullableCondition<in T>(T? obj);

    public delegate bool Condition<in T>(T obj);
}
