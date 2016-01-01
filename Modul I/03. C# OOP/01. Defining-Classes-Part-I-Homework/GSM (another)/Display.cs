namespace DefineClasses
{
	public class Display
	{
		private double? size; // in inches
		private int? numberOfColors;

		public Display() { }
		public Display(double size, int numberOfColors)
		{
			this.Size = size;
			this.NumberOfColors = numberOfColors;
		}

		public int? NumberOfColors
		{
			get { return this.numberOfColors; }
			set { this.numberOfColors = value; }
		}

		public double? Size
		{
			get { return this.size; }
			set { this.size = value; }
		}

		public override string ToString()
		{
			return string.Format("Display: [{0}/{1}]", this.Size, this.NumberOfColors);
		}
	}
}