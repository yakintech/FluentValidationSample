using FluentValidationSample.Models.DTO;
using FluentValidationSample.Models.ORM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        AkademiIstanbulContext _context;

        public StudentController()
        {
            _context = new AkademiIstanbulContext();
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            List<GetAllStudentsResponseDto> model = _context.Students.Select(q => new GetAllStudentsResponseDto()
            {
                ID = q.ID,
                Name = q.Name,
                Surname = q.Surname,
                Email = q.Email,
                UniversityName = q.University.Name
            }).ToList();

            return Ok(model);
        }


        [HttpPost]
        public IActionResult AddStudent(CreateStudentRequestDto requestModel)
        {

            Student student = new Student();
            student.Name = requestModel.Name;
            student.Surname = requestModel.Surname;
            student.Email = requestModel.Email;
            student.Phone = requestModel.Phone;
            student.BirthDate = requestModel.BirthDate;

            _context.Students.Add(student);
            _context.SaveChanges();

           return Ok();
        }

        // api/student/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, UpdateStudentRequestDto model)
        {
            // oncelikle update edilecek ogrenciyi bulmamiz gerekiyor
            Student student = _context.Students.FirstOrDefault(q => q.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            student.Name = model.Name;
            student.Surname = model.Surname;
            student.Email = model.Email;
            student.Phone = model.Phone;
            student.BirthDate = model.BirthDate;
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            Student student = _context.Students.FirstOrDefault(q => q.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            student.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }


    }
}
