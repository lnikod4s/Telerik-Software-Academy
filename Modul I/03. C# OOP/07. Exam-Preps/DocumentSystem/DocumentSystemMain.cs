using System;
using System.Collections.Generic;

namespace DocumentSystem
{
	public class DocumentSystemMain
	{
		private static readonly List<Document> documents = new List<Document>();

		private static void Main()
		{
			var allCommands = ReadAllCommands();
			ExecuteCommands(allCommands);
		}

		private static IList<string> ReadAllCommands()
		{
			var commands = new List<string>();
			while (true)
			{
				var commandLine = Console.ReadLine();
				if (commandLine == "")
				{
					// End of commands
					break;
				}
				commands.Add(commandLine);
			}
			return commands;
		}

		private static void ExecuteCommands(IList<string> commands)
		{
			foreach (var commandLine in commands)
			{
				var paramsStartIndex = commandLine.IndexOf("[");
				var cmd = commandLine.Substring(0, paramsStartIndex);
				var paramsEndIndex = commandLine.IndexOf("]");
				var parameters = commandLine.Substring(
					paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
				ExecuteCommand(cmd, parameters);
			}
		}

		private static void ExecuteCommand(string cmd, string parameters)
		{
			var cmdAttributes = parameters.Split(
				new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
			if (cmd == "AddTextDocument")
			{
				AddTextDocument(cmdAttributes);
			}
			else if (cmd == "AddPDFDocument")
			{
				AddPdfDocument(cmdAttributes);
			}
			else if (cmd == "AddWordDocument")
			{
				AddWordDocument(cmdAttributes);
			}
			else if (cmd == "AddExcelDocument")
			{
				AddExcelDocument(cmdAttributes);
			}
			else if (cmd == "AddAudioDocument")
			{
				AddAudioDocument(cmdAttributes);
			}
			else if (cmd == "AddVideoDocument")
			{
				AddVideoDocument(cmdAttributes);
			}
			else if (cmd == "ListDocuments")
			{
				ListDocuments();
			}
			else if (cmd == "EncryptDocument")
			{
				EncryptDocument(parameters);
			}
			else if (cmd == "DecryptDocument")
			{
				DecryptDocument(parameters);
			}
			else if (cmd == "EncryptAllDocuments")
			{
				EncryptAllDocuments();
			}
			else if (cmd == "ChangeContent")
			{
				ChangeContent(cmdAttributes[0], cmdAttributes[1]);
			}
			else
			{
				throw new InvalidOperationException("Invalid command: " + cmd);
			}
		}

		private static void AddDocument(Document doc, string[] attributes)
		{
			foreach (var attribute in attributes)
			{
				var tokens = attribute.Split('=');
				var propName = tokens[0];
				var propValue = tokens[1];
				doc.LoadProperty(propName, propValue);
			}

			if (doc.Name != null)
			{
				documents.Add(doc);
				Console.WriteLine("Document added: {0}", doc.Name);
			}
			else
			{
				Console.WriteLine("Document has no name");
			}
		}

		private static void AddTextDocument(string[] attributes) { AddDocument(new TextDocument(), attributes); }
		private static void AddPdfDocument(string[] attributes) { AddDocument(new PDFDocument(), attributes); }
		private static void AddWordDocument(string[] attributes) { AddDocument(new WordDocument(), attributes); }
		private static void AddExcelDocument(string[] attributes) { AddDocument(new ExcelDocument(), attributes); }
		private static void AddAudioDocument(string[] attributes) { AddDocument(new AudioDocument(), attributes); }
		private static void AddVideoDocument(string[] attributes) { AddDocument(new VideoDocument(), attributes); }

		private static void ListDocuments()
		{
			if (documents.Count == 0)
			{
				Console.WriteLine("No documents found");
			}
			else
			{
				foreach (var document in documents)
				{
					Console.WriteLine(document);
				}
			}
		}

		private static void EncryptDocument(string name)
		{
			var isFound = false;
			foreach (var document in documents)
			{
				if (document.Name == name)
				{
					isFound = true;
					if (document is IEncryptable)
					{
						((IEncryptable) document).Encrypt();
						Console.WriteLine("Document encrypted: {0}", document.Name);
					}
					else
					{
						Console.WriteLine("Document does not support encryption: {0}", document.Name);
					}
				}
			}

			if (!isFound)
			{
				Console.WriteLine("Document not found: {0}", name);
			}
		}

		private static void DecryptDocument(string name)
		{
			var isFound = false;
			foreach (var document in documents)
			{
				if (document.Name == name)
				{
					isFound = true;
					if (document is IEncryptable)
					{
						((IEncryptable) document).Decrypt();
						Console.WriteLine("Document decrypted: {0}", document.Name);
					}
					else
					{
						Console.WriteLine("Document does not support decryption: {0}", document.Name);
					}
				}
			}

			if (!isFound)
			{
				Console.WriteLine("Document not found: {0}", name);
			}
		}

		private static void EncryptAllDocuments()
		{
			var isFound = false;
			foreach (var document in documents)
			{
				if (document is IEncryptable)
				{
					isFound = true;
					((IEncryptable) document).Encrypt();
				}
			}

			Console.WriteLine(!isFound ? "No encryptable documents found" : "All documents encrypted");
		}

		private static void ChangeContent(string name, string content)
		{
			var isFound = false;
			foreach (var document in documents)
			{
				if (document.Name == name)
				{
					isFound = true;
					if (document is IEditable)
					{
						((IEditable) document).ChangeContent(content);
						Console.WriteLine("Document content changed: {0}", document.Name);
					}
					else
					{
						Console.WriteLine("Document is not editable: {0}", document.Name);
					}
				}
			}

			if (!isFound)
			{
				Console.WriteLine("Document not found: {0}", name);
			}
		}
	}
}