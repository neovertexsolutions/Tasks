using day4studentwebapi.Models;
namespace day4studentwebapi.Interfaces
{
    public interface IStudentService 
    {
        List<Student> GetAllStudents();// return all the students list
        Student? GetStudentById(int id); 

        Student Create(Student student);
        Student? Update(int id, Student student);
        bool Delete(int id);
        object Update(Student student);
    }
}
