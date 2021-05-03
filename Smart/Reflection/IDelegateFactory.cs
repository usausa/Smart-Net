namespace Smart.Reflection
{
    using System;
    using System.Reflection;

    public interface IDelegateFactory
    {
        bool IsCodegenRequired { get; }

        // Array

        Func<int, Array> CreateArrayAllocator(Type type);

        // Factory

        Func<object> CreateFactory(Type type);

        Func<object?[]?, object> CreateFactory(Type type, Type[] argumentTypes);

        Func<object?[]?, object> CreateFactory(ConstructorInfo ci);

        Func<object> CreateFactory0(ConstructorInfo ci);

        Func<object?, object> CreateFactory1(ConstructorInfo ci);

        Func<object?, object?, object> CreateFactory2(ConstructorInfo ci);

        Func<object?, object?, object?, object> CreateFactory3(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object> CreateFactory4(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object> CreateFactory5(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object> CreateFactory6(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object> CreateFactory7(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory8(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory9(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory10(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory11(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory12(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory13(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory14(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory15(ConstructorInfo ci);

        Func<object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object?, object> CreateFactory16(ConstructorInfo ci);

        // Factory

        Func<T> CreateFactory<T>();

        Func<TP1?, T> CreateFactory<TP1, T>();

        Func<TP1?, TP2?, T> CreateFactory<TP1, TP2, T>();

        Func<TP1?, TP2?, TP3?, T> CreateFactory<TP1, TP2, TP3, T>();

        Func<TP1?, TP2?, TP3?, TP4?, T> CreateFactory<TP1, TP2, TP3, TP4, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, TP10?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, TP10?, TP11?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, TP10?, TP11?, TP12?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, TP10?, TP11?, TP12?, TP13?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, TP10?, TP11?, TP12?, TP13?, TP14?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, TP10?, TP11?, TP12?, TP13?, TP14?, TP15?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, T>();

        Func<TP1?, TP2?, TP3?, TP4?, TP5?, TP6?, TP7?, TP8?, TP9?, TP10?, TP11?, TP12?, TP13?, TP14?, TP15?, TP16?, T> CreateFactory<TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8, TP9, TP10, TP11, TP12, TP13, TP14, TP15, TP16, T>();

        // Accessor

        Func<object?, object?>? CreateGetter(PropertyInfo pi);

        Func<object?, object?>? CreateGetter(PropertyInfo pi, bool extension);

        Action<object?, object?>? CreateSetter(PropertyInfo pi);

        Action<object?, object?>? CreateSetter(PropertyInfo pi, bool extension);

        // Accessor

        Func<T?, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi);

        Func<T?, TMember?>? CreateGetter<T, TMember>(PropertyInfo pi, bool extension);

        Action<T?, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi);

        Action<T?, TMember?>? CreateSetter<T, TMember>(PropertyInfo pi, bool extension);

        // Etc

        Type GetExtendedPropertyType(PropertyInfo pi);
    }
}
