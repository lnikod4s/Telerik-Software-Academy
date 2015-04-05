using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
	public abstract class Document : IDocument
	{
		public string Name { get; protected set; }
		public string Content { get; protected set; }

		public virtual void LoadProperty(string key, string value)
		{
			switch (key)
			{
				case "name":
					this.Name = value;
					break;
				case "content":
					this.Content = value;
					break;
			}
		}

		public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
		{
			output.Add(new KeyValuePair<string, object>("name", this.Name));
			output.Add(new KeyValuePair<string, object>("content", this.Content));
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append(this.GetType().Name);
			sb.Append("[");

			var attributes = new List<KeyValuePair<string, object>>();
			this.SaveAllProperties(attributes);
			var sortedAttributes = attributes.OrderBy(a => a.Key);
			foreach (var attribute in sortedAttributes)
			{
				if (attribute.Value != null)
				{
					sb.Append(attribute.Key);
					sb.Append("=");
					sb.Append(attribute.Value);
					sb.Append(";");
				}
			}

			sb.Length--; // Removes last ';'
			sb.Append("]");
			return sb.ToString();
		}
	}
}