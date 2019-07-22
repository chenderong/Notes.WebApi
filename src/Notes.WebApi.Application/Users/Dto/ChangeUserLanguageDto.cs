using System.ComponentModel.DataAnnotations;

namespace Notes.WebApi.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}