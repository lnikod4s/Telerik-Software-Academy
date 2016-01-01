using System;

namespace _09._16.StudentGroups
{
	public class Group
	{
		private int groupNumber;
		private string departmentName;

		public Group(int groupNumber, string departmentName)
		{
			this.GroupNumber = groupNumber;
			this.DepartmentName = departmentName;
		}

		public Group()
			: this(1, "Unknown department")
		{

		}

		public int GroupNumber
		{
			get { return this.groupNumber; }
			set
			{
				if (value <= 0)
				{
					throw new ApplicationException("Group number must be a positive number.");
				}

				this.groupNumber = value;
			}
		}

		public string DepartmentName
		{
			get { return this.departmentName; }
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ApplicationException("Department name can not be null or empty !");
				}

				this.departmentName = value;
			}
		}
		
		
	}
}
