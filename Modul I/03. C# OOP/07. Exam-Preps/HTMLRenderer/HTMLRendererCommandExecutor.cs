using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace HTMLRenderer
{
	public class HTMLRendererCommandExecutor
	{
		private static void Main()
		{
			var csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
		}

		private static string ReadInputCSharpCode()
		{
			var result = new StringBuilder();
			string line;
			while ((line = Console.ReadLine()) != "")
			{
				result.AppendLine(line);
			}
			return result.ToString();
		}

		private static void CompileAndRun(string csharpCode)
		{
			// Prepare a C# program for compilation
			string[] csharpClass =
			{
				@"using System;
				  using HTMLRenderer;

				  public class RuntimeCompiledClass
				  {
					 public static void Main()
					 {"
				+ csharpCode + @"
					 }
				  }"
			};

			// Compile the C# program
			var compilerParams = new CompilerParameters();
			compilerParams.GenerateInMemory = true;
			compilerParams.TempFiles = new TempFileCollection(".");
			compilerParams.ReferencedAssemblies.Add("System.dll");
			compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
			var csharpProvider = new CSharpCodeProvider();
			var compile = csharpProvider.CompileAssemblyFromSource(
				compilerParams, csharpClass);

			// Check for compilation errors
			if (compile.Errors.HasErrors)
			{
				var errorMsg = "Compilation error: ";
				foreach (CompilerError ce in compile.Errors)
				{
					errorMsg += "\r\n" + ce;
				}
				throw new Exception(errorMsg);
			}

			// Invoke the Main() method of the compiled class
			var assembly = compile.CompiledAssembly;
			var module = assembly.GetModules()[0];
			var type = module.GetType("RuntimeCompiledClass");
			var methInfo = type.GetMethod("Main");
			methInfo.Invoke(null, null);
		}
	}
}