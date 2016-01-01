namespace SoftwareAcademy
{
	public interface ITeacher
	{
		string Name { get; set; }
		void AddCourse(ICourse course);
		string ToString();
	}
}