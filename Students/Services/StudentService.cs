using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Students.Data;
using Microsoft.EntityFrameworkCore;

namespace Students.Services
{
    public class StudentService : IStudentServices
    {
        private readonly StudentDBContext _context;

        public StudentService(StudentDBContext dbContext)
        {
            _context = dbContext;
        }
        /// <summary>
        /// Gets student by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Student> GetStudentById(Guid Id)
        {
            Student studentsVm = new Student();
            return studentsVm;
        }

        /// <summary>
        /// generate/get students list from WebAPI call
        /// </summary>
        /// <returns>returns student list</returns>
        public async Task<List<Student>> GenerateStudents()
        { 
            List<Student> studentList = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://uinames.com/api/?amount=10"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studentList = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return studentList;
        }

        /// <summary>
        /// checks if phonenumber already exists
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="id"></param>
        /// <returns>return true/false</returns>
        public async Task<bool> IsPhoneNumberExists(string phone, Guid id)
        {
            return await _context.Students.AnyAsync(x => x.Phone.Trim().ToLower() == phone.Trim().ToLower() && x.Id != id);
        }
    }
}
