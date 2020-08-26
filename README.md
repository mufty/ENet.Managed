[![Discord](https://img.shields.io/discord/728246944765313075?label=discord)](https://discord.gg/38UqCVC)
[![ENet version](https://img.shields.io/badge/enet-1.3.15-green)](https://github.com/lsalzman/enet/commit/e55d226969300fbd3f1308afd8bf69e423012f2e)
[![Nuget](https://img.shields.io/nuget/dt/ENet.Managed?label=downloads)][nuget]
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/ENet.Managed?label=version)][nuget]
[![Build status](https://ci.appveyor.com/api/projects/status/p8v29k0jxaud33ec/branch/master?svg=true)](https://ci.appveyor.com/project/moien007/enet-managed/branch/master)

## ENet.Managed
**ENet** is cross-platform reliable UDP networking library written in C and **ENet.Managed** is an unofficial, managed wrapper for ENet available for specific set of platforms. You can checkout ENet's repo [here][enet-repo].

# Quick start (Usage)
Take a look at **examples** folder.

# Features
* Supports **AnyCPU** targets
* It's cross-platform via .NET Standard
* It's available via NuGet package manager. ([Here][nuget])
* You can set custom
  * compression method (not enabled by default, recommended to specify a compressor using <code>CompressWith*</code>)
  * checksum algorithm (not enabled by default, recommended to specify a checksum using <code>ChecksumWith*</code>)
  * heap allocator (by default ManagedENet forces ENet to use a custom allocator which is faster than malloc, take a look at <code>ENetManagedAllocator.cs</code>)
* Takes advantage of <code>Span\<byte></code> and friends to reduce GC allocations.
* Provides nearly all features of ENet via managed API.

# Benchmarks
You can see how ENet performs compared to other libraries by taking look at [here][benchmark].<br/>
Benchmarks for the wrapper itself are not available yet but it should have near native performance when optimizations are enabled.

# Supported frameworks
### .NET Framework
* [X] 4.5
### .NET Standard
* [X] 2.0
* [X] 2.1

# Supported platfroms
### Windows 
* [X] X86
* [X] X86_64
* [X] ARM32
### Linux 
* [X] X86
* [X] X86_64
* [X] ARM32
* [X] ARM64
### MacOS
* [ ] X64

> You can contribute by providing **clean** binaries for unsupported platforms. 

> Linux binaries are statically linked with **[MUSL](https://www.musl-libc.org/faq.html)**

# Notes
* This wrapper deploys ENet binaries to OS's temp folder and dynamically loads them, you can alter this behavior by manually initializing ENet using <code>LibENet</code> class.
* ENet's checksum feature is disabled by default, it is highly recommended to use checksum to avoid receiving damaged packets. 
  * <code>ChecksumWithCRC32</code> enables ENet's builtin checksum feature.
* In case of consuming custom version of ENet you have to sync the data structures offsets with the wrapper. 
* <code>ENetPeer.DisconnectNow</code> method will not generate <code>ENetEventType.Disconnect</code>.
* If you use <code>SetUserData</code> extension methods you have to call <code>UnsetUserData</code> when you done, otherwise memory leak will happen.

# Contribution
You can contribute by reporting bugs and making pull requests.

# License
MIT open-source license.

[enet-repo]: http://www.github.com/lsalzman/enet
[benchmark]: http://www.github.com/nxrighthere/BenchmarkNet/wiki/Benchmark-Results
[nuget]: http://www.nuget.org/packages/ENet.Managed

