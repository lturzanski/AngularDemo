using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusions
{
  [Table("StateExcl_ExclusionDate", Schema = "dbo")]
  public partial class StateExclExclusionDate
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public DateTime ExclusionDate
    {
      get;
      set;
    }
    public int StateExcl_ExclusionId
    {
      get;
      set;
    }

    public StateExclExclusion StateExclExclusion { get; set; }
  }
}
