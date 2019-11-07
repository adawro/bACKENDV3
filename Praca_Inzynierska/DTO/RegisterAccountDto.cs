namespace Praca_Inzynierska.DTO
{
    public class RegisterAccountDto
    {
        /// <example>Swiety</example>
        public string Name { get; set; }
        /// <example>Mikolaj</example>
        public string Surname { get; set; }
        /// <example>jakis@poprawny.email</example>
        public string Email { get; set; }
        /// <example>hunter2</example>
        public string Password { get; set; }
        /// <example>hunter2</example>
        public string ConfirmPassword { get; set; }
    }
}
