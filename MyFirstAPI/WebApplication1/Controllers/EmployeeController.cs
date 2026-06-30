using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DTOs;
using WebApplication1.Modules.Entities;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DBConnection _context;

        public EmployeeController(DBConnection context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] ADDEmployeeDTO dto)
        {
            // Validate incoming data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO → Entity
            var employee = new Employee
            {
                FirstName = dto.Firstname,
                LastName = dto.Lastname,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Department = dto.Department,
                Position = dto.Position
            };

            // Save to database
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Employee added successfully",
                data = employee
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] ADDEmployeeDTO dto)
        {
            // Validate incoming data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find existing employee
            var existingEmployee = await _context.Employees.FindAsync(id);

            if (existingEmployee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }

            // Map DTO → Existing Entity
            existingEmployee.FirstName = dto.Firstname;
            existingEmployee.LastName = dto.Lastname;
            existingEmployee.Email = dto.Email;
            existingEmployee.PhoneNumber = dto.PhoneNumber;
            existingEmployee.Department = dto.Department;
            existingEmployee.Position = dto.Position;

            // Save changes
            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Employee updated successfully",
                data = existingEmployee
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound(new { message = "Employee not found" });
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Employee deleted successfully"
            });
        }
    }
}
