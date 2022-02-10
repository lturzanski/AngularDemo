using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusionsDatabase
{
  [Table("ExclusionDates", Schema = "dbo")]
  public partial class ExclusionDate
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public DateTime Date
    {
      get;
      set;
    }
    public int ExclusionId
    {
      get;
      set;
    }

    public Exclusion Exclusion { get; set; }
  }
}
