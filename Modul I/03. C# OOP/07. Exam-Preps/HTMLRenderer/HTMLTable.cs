using System;
using System.Collections.Generic;
using System.Text;

namespace HTMLRenderer
{
	public class HTMLTable : HTMLElement, ITable
	{
		private const string TABLE_NAME = "table";
		private const string TABLE_ROW_OPEN_TAG = "<tr>";
		private const string TABLE_ROW_CLOSE_TAG = "</tr>";
		private const string TABLE_CELL_OPEN_TAG = "<td>";
		private const string TABLE_CELL_CLOSE_TAG = "</td>";
		private readonly IElement[,] cellElements;
		private int cols;
		private int rows;

		public HTMLTable(int rows, int cols, string name = "table")
		{
			this.Rows = rows;
			this.Cols = cols;
			this.cellElements = new IElement[rows, cols];
		}

		public int Rows
		{
			get { return this.rows; }
			private set { this.rows = value; }
		}

		public int Cols
		{
			get { return this.cols; }
			private set { this.cols = value; }
		}

		public IElement this[int row, int col]
		{
			get { return this.cellElements[row, col]; }
			set { this.cellElements[row, col] = value; }
		}

		public override IEnumerable<IElement> ChildElements
		{
			get { throw new InvalidOperationException("HTML tables do not have child elements!"); }
		}

		public override string TextContent
		{
			get { throw new InvalidOperationException("Cannot get text content of HTML table because it does not have such!"); }

			set { throw new InvalidOperationException("Cannot set text content of HTML table because it does not have such!"); }
		}

		public override void AddElement(IElement element)
		{
			throw new InvalidOperationException("HTML tables do not have child elements so such cannot be added!");
		}

		public override void Render(StringBuilder output)
		{
			output.AppendFormat("<{0}>", this.Name);

			for (var row = 0; row < this.Rows; row++)
			{
				output.Append(TABLE_ROW_OPEN_TAG);

				for (var col = 0; col < this.Cols; col++)
				{
					output.Append(TABLE_CELL_OPEN_TAG);
					output.Append(this.cellElements[row, col].ToString());
					output.Append(TABLE_CELL_CLOSE_TAG);
				}

				output.Append(TABLE_ROW_CLOSE_TAG);
			}

			output.AppendFormat("</{0}>", this.Name);
		}
	}
}