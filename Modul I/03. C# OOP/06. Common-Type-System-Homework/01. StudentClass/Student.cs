using System;
using System.Text;

namespace _01_03.StudentClass
{
	class Student : ICloneable, IComparable
	{
		// Constructors
		public Student() { }
		public Student(string firstName, string middleName, string lastName,
			int ssn, string permanentAddress, string mobilePhone, string email, string course,
			University university, Faculty faculty, Specialty specialty)
		{
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
			this.SSN = ssn;
			this.PermanentAddress = permanentAddress;
			this.MobilePhone = mobilePhone;
			this.Email = email;
			this.Course = course;
			this.University = university;
			this.Faculty = faculty;
			this.Specialty = specialty;
		}

		// Properties
		public string FirstName { get; private set; }
		public string MiddleName { get; private set; }
		public string LastName { get; private set; }
		public int SSN { get; private set; }
		public string PermanentAddress { get; private set; }
		public string MobilePhone { get; private set; }
		public string Email { get; private set; }
		public string Course { get; private set; }
		public University University { get; private set; }
		public Faculty Faculty { get; private set; }
		public Specialty Specialty { get; private set; }

		// Methods
		#region Overrides of Object
		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified object  is equal to the current object; otherwise, false.
		/// </returns>
		/// <param name="obj">The object to compare with the current object. </param>
		public override bool Equals(object obj)
		{
			return this.FirstName == (obj as Student).FirstName &&
			       this.MiddleName == (obj as Student).MiddleName &&
			       this.LastName == (obj as Student).LastName &&
			       this.SSN == (obj as Student).SSN;
		}
		#endregion

		public static bool operator ==(Student stud1, Student stud2)
		{
			return stud1.Equals(stud2);
		}

		public static bool operator !=(Student stud1, Student stud2)
		{
			return !(stud1 == stud2);
		}

		#region Overrides of Object
		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		public override int GetHashCode()
		{
			return Tuple.Create(this.FirstName, this.MiddleName, this.LastName).GetHashCode();
		}
		#endregion

		#region Overrides of Object
		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj"/>. Greater than zero This instance follows <paramref name="obj"/> in the sort order. 
		/// </returns>
		/// <param name="obj">An object to compare with this instance. </param>
		public int CompareTo(object obj)
		{
			if (this.FirstName != (obj as Student).FirstName)
			{
				return this.FirstName.CompareTo((obj as Student).FirstName);
			}
			if (this.MiddleName != (obj as Student).MiddleName)
			{
				return this.MiddleName.CompareTo((obj as Student).MiddleName);
			}
			if (this.LastName != (obj as Student).LastName)
			{
				return this.LastName.CompareTo((obj as Student).LastName);
			}
			if (this.SSN != (obj as Student).SSN)
			{
				return this.SSN.CompareTo((obj as Student).SSN);
			}

			return 0;
		}
		#endregion	

		#region Overrides of Object
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>
		/// A new object that is a copy of this instance.
		/// </returns>
		public object Clone()
		{
			return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress, this.MobilePhone,
			                   this.Email, this.Course, this.University, this.Faculty, this.Specialty);

		}
		#endregion

		#region Overrides of Object
		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			var result = new StringBuilder();
			result.AppendLine("Full name: " + this.FirstName + " " + this.MiddleName + " " + this.LastName);
			result.AppendLine("SSN: " + this.SSN);
			result.AppendLine("Permanent Address: " + this.PermanentAddress);
			result.AppendLine("Mobile phone: " + this.MobilePhone);
			result.AppendLine("Email: " + this.Email);
			result.AppendLine("Course: " + this.Course);
			result.AppendLine("University: " + this.University);
			result.AppendLine("Specialty: " + this.Specialty);
			return result.ToString();
		}
		#endregion
	}
}