using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusionsDatabase
{
  [Table("StateExclusions", Schema = "dbo")]
  public partial class StateExclusion
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public int StateId
    {
      get;
      set;
    }

    public State State { get; set; }
    public int ExclusionId
    {
      get;
      set;
    }

    public Exclusion Exclusion { get; set; }
  }
}
