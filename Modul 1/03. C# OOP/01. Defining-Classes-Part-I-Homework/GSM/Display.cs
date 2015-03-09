using System;

/// <summary>
/// Defines a class Display that holds display characteristics: size and number of colors
/// </summary>
class Display
{
	// default const values
	private const uint DEFAULT_HEIGHT = 180;
	private const uint DEFAULT_WIDTH = 80;
	private const long DEFAULT_NUMBER_OF_COLORS = 16000000;

	// fields
	private uint height;
	private uint width;
	private long numberOfColors;

	// constructors
	public Display()
		: this(DEFAULT_HEIGHT, DEFAULT_WIDTH, DEFAULT_NUMBER_OF_COLORS) // default constructor with default values
	{
	}

	public Display(uint height, uint width, long numberOfColors) // constructor with parameters
	{
		this.Height = height;
		this.Width = width;
		this.NumberOfColors = numberOfColors;
	}

	// properties
	public uint Height
	{
		get { return this.height; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Display height must be at least zero.");
			}
			
			this.height = value;
		}
	}

	public uint Width
	{
		get { return this.width; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Display width must be at least zero.");
			}
			
			this.width = value;
		}
	}

	public long NumberOfColors
	{
		get { return numberOfColors; }
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Display colors must be at least zero.");
			}
			
			this.numberOfColors = value;
		}
	}
}