using StudentDbApiCRUDRepository.Interfaces;
using StudentDbApiCRUDRepository.Models;

namespace StudentDbApiCRUDRepository.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public List<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }

        public Student? GetStudentById(int id)
        {
            return _repository.GetStudentById(id);
        }

        public void AddStudent(Student student)
        {
            _repository.AddStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _repository.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _repository.DeleteStudent(id);
        }
    }
}