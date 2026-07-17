using StudentDbApiCRUDRepository.Models;

namespace StudentDbApiCRUDRepository.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();

        Student GetStudentById(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(int id);
    }
}
