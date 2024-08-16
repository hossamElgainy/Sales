using System.ComponentModel.DataAnnotations;

namespace SalesProject.VM
{
    public class AddProductDto
    {
        [Required(ErrorMessage ="برجاء إدخال إسم المنتج ")]
        [Display(Name ="إسم المنتج")]
        public string Name { get; set; }

        [Required(ErrorMessage = "برجاء إدخال سعر المنتج ")]
        [Display(Name = "سعر المنتج")]
        [DataType(DataType.Currency,ErrorMessage ="سعر المنج يجب أن يكون رقم")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "برجاء إدخال الكميه المتاحه  ")]
        [Display(Name = "الكميه المتاحه")]
        public int Quentity { get; set; }

    }
}
