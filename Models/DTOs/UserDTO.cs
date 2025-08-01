﻿namespace eApp.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public string? Phone { get; set; }
        public Address? Address { get; set; }
    }
}
