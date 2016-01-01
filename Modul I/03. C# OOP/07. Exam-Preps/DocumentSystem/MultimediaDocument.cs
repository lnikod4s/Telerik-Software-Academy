﻿using System.Collections.Generic;

namespace DocumentSystem
{
	public abstract class MultimediaDocument : BinaryDocument
	{
		public long? Length { get; protected set; }

		public override void LoadProperty(string key, string value)
		{
			if (key == "length")
			{
				this.Length = long.Parse(value);
			}
			else
			{
				base.LoadProperty(key, value);
			}
		}

		public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
		{
			output.Add(new KeyValuePair<string, object>("length", this.Length));
			base.SaveAllProperties(output);
		}
	}
}