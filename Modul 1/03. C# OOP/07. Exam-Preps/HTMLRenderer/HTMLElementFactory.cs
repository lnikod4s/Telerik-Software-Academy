namespace HTMLRenderer
{
	public class HTMLElementFactory : IElementFactory
	{
		public IElement CreateElement(string name) { return new HTMLElement(name); }
		public IElement CreateElement(string name, string content) { return new HTMLElement(name, content); }
		public ITable CreateTable(int rows, int cols) { return new HTMLTable(rows, cols); }
	}
}