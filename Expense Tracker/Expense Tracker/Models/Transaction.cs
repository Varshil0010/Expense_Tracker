using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TranstionId { get; set; }

        //CategoryId
        public int CategoryId { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;  

        public Category? Category { get; set; }

        [NotMapped]
        public string? CategoryTitleWithIcon 
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }


        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense")? "-" : "+") + Amount.ToString("C0");
            }
        }

    }
}
