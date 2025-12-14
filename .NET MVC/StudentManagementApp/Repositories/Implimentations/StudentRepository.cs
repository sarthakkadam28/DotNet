 using System.Collections.Generic;
 using System.Threading.Tasks;
 using Microsoft.EntityFrameworkCore;
 using System.Linq;
 using StudentManagementApp.Models;
 using StudentManagementApp.Data;
 using System;


public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        try
        {
            return await _context.Students.ToListAsync();
        }
        catch (Exception ex)
        {
            // Log exception here (ILogger or custom logging)
            throw new Exception("Error fetching students", ex);
        }
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        try
        {
            return await _context.Students.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching student with ID {id}", ex);
        }
    }

    public async Task AddStudentAsync(Student student)
    {
        try
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error adding student", ex);
        }
    }

    public async Task UpdateStudentAsync(Student student)
    {
        try
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating student", ex);
        }
    }

    public async Task DeleteStudentAsync(int id)
    {
        try
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting student", ex);
        }
    }
}