using Syncfusion.Maui.DataForm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ValidateEditors
{
    public class DataFormModel : IDataErrorInfo
    {
        public DataFormModel()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Password = string.Empty;
            this.RetypePassword = string.Empty;
            this.Address = string.Empty;
            this.City = string.Empty;
            this.Country = string.Empty;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
        [StringLength(20, ErrorMessage = "First name should not exceed 20 characters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
        [StringLength(20, ErrorMessage = "First name should not exceed 20 characters")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [DataFormDisplayOptions(ColumnSpan = 2, ValidMessage = "Password strength is good")]
        [Required(ErrorMessage = "Please enter the password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])[a-zA-Z\d]{8,}$", ErrorMessage = "A minimum 8-character password should contain a combination of uppercase and lowercase letters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm the password")]
        [DataFormDisplayOptions(ColumnSpan = 2)]
        public string RetypePassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address")]
        public string City { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        [Display(AutoGenerateField = false)]
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        [Display(AutoGenerateField = false)]
        public string this[string name]
        {
            get
            {
                string result = string.Empty;
                if (name == nameof(RetypePassword) && Password != RetypePassword)
                {
                    result = string.IsNullOrEmpty(this.RetypePassword) ? string.Empty : "The passwords do not match";
                }

                return result;
            }
        }
    }
}