using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTeste.Application.ViewModels
{
    public class PeopleViewModel
    {
        [Key]
        public Guid Id { get; set; }

        //public Guid Id
        //{
        //    get => id;
        //    set => id = value == Guid.Empty ? Guid.NewGuid() : value;
        //}

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data in invalid format")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
