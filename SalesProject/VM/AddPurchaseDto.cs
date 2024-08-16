using System.ComponentModel.DataAnnotations;

namespace SalesProject.VM
{
    public class AddPurchaseDto
    {
        [Required(ErrorMessage = "برجاء إختيار المنتج ")]
        [Display(Name = "المنتج")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "برجاء إدخال سعر البيع ")]
        [Display(Name = "سعر البيع")]
        [DataType(DataType.Currency, ErrorMessage = "سعر البيع يجب أن يكون رقم")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "برجاء إدخال الكميه   ")]
        [Display(Name = "الكميه ")]
        public int Quentity { get; set; }
    }
}
