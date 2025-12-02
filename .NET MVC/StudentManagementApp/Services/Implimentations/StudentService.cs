public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _repository.GetAllStudentsAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _repository.GetStudentByIdAsync(id);
    }

    public async Task CreateStudentAsync(Student student)
    {
        try
        {
            if (string.IsNullOrEmpty(student.Name))
                throw new ArgumentException("Student name is required");

            await _repository.AddStudentAsync(student);
        }
        catch (Exception ex)
        {
            // Could log here or rethrow
            throw new Exception("Error creating student", ex);
        }
    }

    public async Task EditStudentAsync(Student student)
    {
        try
        {
            await _repository.UpdateStudentAsync(student);
        }
        catch (Exception ex)
        {
            throw new Exception("Error editing student", ex);
        }
    }

    public async Task RemoveStudentAsync(int id)
    {
        try
        {
            await _repository.DeleteStudentAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception("Error removing student", ex);
        }
    }
}