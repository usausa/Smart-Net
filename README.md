# Smart-Net

[![NuGet](https://img.shields.io/nuget/v/Usa.Smart.Core.svg)](https://www.nuget.org/packages/Usa.Smart.Core)

Foundation library for building other Smart libraries.

## Summary

### Reflection

* `IDelegateFactory` — abstraction for creating delegates from constructors/properties/fields
* `PrimitiveConvert` — fast primitive type conversion helpers

### Collections

* `ThreadsafeTypeHashArrayMap<TValue>` — lock-minimized thread-safe dictionary keyed by `Type`
* `ProjectionReadOnlyList<TSource, TResult>` — lazily converted read-only list view
* Extension methods for `ICollection`, `IDictionary`, `IEnumerable` (`ForEach`, `JoinToString` etc.)

### ComponentModel

* `ComponentContainer` / `ComponentConfig` — lightweight service locator / IoC container
* `NotificationObject` / `NotificationValue<T>` — `INotifyPropertyChanged` base implementations
* `DisposableObject` — base class with dispose pattern
* `AtomicBoolean`, `AtomicInteger`, `AtomicReference<T>` — atomic value wrappers

### IO

* `SpanReader<T>` / `SpanWriter<T>` — ref struct sequential span readers/writers
* `BufferWriterSlim<T>` — stack-friendly `IBufferWriter<T>` implementation
* `PooledBufferWriter<T>` / `PooledMemoryStream` — `ArrayPool`-backed writer and stream
* `MemoryOwner<T>` — `IMemoryOwner<T>` wrapper for `ArrayPool`
* `BufferWriterSlim<char>` string building extensions — `WriteLine` / `WriteFormattable` / interpolated `Append` / `ToStringAndClear`
* Extension methods for `Stream`, `IBufferWriter<byte>`, `TextReader`

### Text

* `SpanTokenizer` — zero-allocation span-based string tokenizer
* `Inflector` — English word inflection (pluralize / singularize / camelize etc.)
* `JsonKeyCamelCaseNamingPolicy` — `System.Text.Json` naming policy

### Threading

* `TaskExtensions` — `Forget` (fire-and-forget) and `TryWaitAsync` (timeout-aware wait) for `Task` / `ValueTask`

### Algorithms

* `BinarySearch` — binary search for `Span<T>`, arrays, `List<T>`, `IList<T>`, `IReadOnlyList<T>` with delegate comparers
