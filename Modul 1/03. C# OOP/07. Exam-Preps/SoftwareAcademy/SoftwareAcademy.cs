using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftwareAcademy
{
	public class SoftwareAcademyCommandExecutor
	{
		static void Main()
		{
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
		}

		private static string ReadInputCSharpCode()
		{
			var result = new StringBuilder();
			string line;
			while ((line = Console.ReadLine()) != string.Empty)
			{
				result.AppendLine(line);
			}

			return result.ToString();
		}

		static void CompileAndRun(string csharpCode)
		{
			// Prepare a C# program for compilation
			string[] csharpClass =
			{
				@"using System;
				  using SoftwareAcademy;

				  public class RuntimeCompiledClass
				  {
					 public static void Main()
					 {"
						+ csharpCode + @"
					 }
				  }"
			};

			// Compile the C# program
			CompilerParameters compilerParams = new CompilerParameters
												{
													GenerateInMemory = true,
													TempFiles = new TempFileCollection(".")
												};
			compilerParams.ReferencedAssemblies.Add("System.dll");
			compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
			CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
			CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
				compilerParams, csharpClass);

			// Check for compilation errors
			if (compile.Errors.HasErrors)
			{
				string errorMsg =
					compile.Errors.Cast<object>().Aggregate("Compilation error: ", (current, ce) => current + ("\r\n" + ce.ToString()));
				throw new Exception(errorMsg);
			}

			// Invoke the Main() method of the compiled class
			Assembly assembly = compile.CompiledAssembly;
			Module module = assembly.GetModules()[0];
			Type type = module.GetType("RuntimeCompiledClass");
			MethodInfo methInfo = type.GetMethod("Main");
			methInfo.Invoke(null, null);
		}
	}
}
