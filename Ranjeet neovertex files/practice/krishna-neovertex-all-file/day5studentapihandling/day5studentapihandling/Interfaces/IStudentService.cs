using day5studentapihandling.DTOs;
using day5studentapihandling.Models;

namespace day5studentapihandling.Interfaces
{
    public interface IStudentService
    {
            List<Student> GetAll();
            Student GetById(int id);
            Student Create(CreateStudentDto dto);
            Student Update(int id, UpdateStudentDto dto);
            bool Delete(int id);
            bool EmailExists(string email, int? excludeId = null);
            List<Student> Search(string keyword);

    }
}

