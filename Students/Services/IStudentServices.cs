using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Students.Models;

namespace Students.Services
{
    public interface IStudentServices
    {
        /// <summary>
        /// Makes api call to "https://uinames.com/api/?amount=10" and returns 10 random person names
        /// </summary>
        /// <returns></returns>
        Task<List<Student>> GenerateStudents();
        
        /// <summary>
        /// Gets student details by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Student> GetStudentById(Guid Id);
        
        /// <summary>
        /// checks if the phone number already exists or not
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<bool> IsPhoneNumberExists(string phone, Guid id);
    }
}
