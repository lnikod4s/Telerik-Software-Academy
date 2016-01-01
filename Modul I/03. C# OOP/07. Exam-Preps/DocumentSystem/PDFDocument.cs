using System.Collections.Generic;

namespace DocumentSystem
{
	public class PDFDocument : EncryptableDocument
	{
		public long? Pages { get; private set; }

		public override void LoadProperty(string key, string value)
		{
			if (key == "pages")
			{
				this.Pages = long.Parse(value);
			}
			else
			{
				base.LoadProperty(key, value);
			}
		}

		public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
		{
			output.Add(new KeyValuePair<string, object>("pages", this.Pages));
			base.SaveAllProperties(output);
		}
	}
}