public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task CreateStudentAsync(Student student);
    Task EditStudentAsync(Student student);
    Task RemoveStudentAsync(int id);
}