using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApp.ViewModels;

public class EmployeesViewModels : IValidatableObject
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    [Display(Name = "Fist name")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Max str Lenght is 100, min str length is 2.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [Display(Name = "Last name")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Max str Lenght is 100, min str length is 2.")]
    public string LastName { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (LastName == "Oq" && DateTime.UtcNow.Year - Birthday.Year <= 18)
            yield return new ValidationResult("Oq should be more than 18 years old.");
        
        yield return ValidationResult.Success!;
    }
}