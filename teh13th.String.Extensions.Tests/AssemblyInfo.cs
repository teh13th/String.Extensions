using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: ComVisible(false)]

[assembly: Guid("fe40b1df-1dc8-44ae-876c-b8a8f105d663")]

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]