namespace Smart
{
    public delegate bool Condition<in T>(T? obj);

    public delegate bool NotNullCondition<in T>(T obj);
}
