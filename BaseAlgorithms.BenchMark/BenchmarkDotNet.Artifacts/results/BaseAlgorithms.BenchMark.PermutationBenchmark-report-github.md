``` ini

BenchmarkDotNet=v0.13.0, OS=ubuntu 20.10
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]     : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT


```
|                     Method |       Mean |    Error |   StdDev | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |-----------:|---------:|---------:|-----:|-------:|------:|------:|----------:|
| GenerateRecursiveMutations |   730.4 ns | 14.26 ns | 15.85 ns |    1 | 0.4301 |     - |     - |      1 KB |
|    GenerateLinearMutations | 1,925.2 ns | 26.03 ns | 24.35 ns |    2 | 0.7629 |     - |     - |      2 KB |
