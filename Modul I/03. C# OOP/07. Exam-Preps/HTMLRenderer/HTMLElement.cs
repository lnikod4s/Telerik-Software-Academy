using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
	public class HTMLElement : IElement
	{
		private readonly ICollection<IElement> childElements;
		private string content;
		protected string name;
		public HTMLElement() { }

		public HTMLElement(string name)
		{
			this.Name = name;
			this.childElements = new List<IElement>();
		}

		public HTMLElement(string name, string content)
			: this(name) { this.TextContent = content; }

		public string Name
		{
			get { return this.name; }
			private set { this.name = value; }
		}

		public virtual string TextContent
		{
			get { return this.content; }
			set { this.content = value; }
		}

		public virtual IEnumerable<IElement> ChildElements
		{
			get { return this.childElements; }
		}

		public virtual void AddElement(IElement element) { this.childElements.Add(element); }

		public virtual void Render(StringBuilder output)
		{
			if (!string.IsNullOrWhiteSpace(this.Name))
			{
				output.AppendFormat("<{0}>", this.Name);
			}

			if (!string.IsNullOrWhiteSpace(this.TextContent))
			{
				for (var i = 0; i < this.TextContent.Length; i++)
				{
					var symbol = this.TextContent[i];
					switch (symbol)
					{
						case '<':
							output.Append("&lt;");
							break;
						case '>':
							output.Append("&gt;");
							break;
						case '&':
							output.Append("&amp;");
							break;
						default:
							output.Append(symbol);
							break;
					}
				}
			}

			foreach (var childElement in this.ChildElements)
			{
				output.Append(childElement.ToString());
			}

			if (!string.IsNullOrWhiteSpace(this.Name))
			{
				output.AppendFormat("</{0}>", this.Name);
			}
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			this.Render(sb);
			return sb.ToString();
		}
	}
}