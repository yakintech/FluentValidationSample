﻿namespace FluentValidationSample.Models.DTO
{
    public class UpdateStudentRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
