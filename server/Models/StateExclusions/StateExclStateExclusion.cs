using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusions
{
  [Table("StateExcl_StateExclusion", Schema = "dbo")]
  public partial class StateExclStateExclusion
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public int StateExcl_StateId
    {
      get;
      set;
    }

    public StateExclState StateExclState { get; set; }
    public int StateExcl_ExclusionId
    {
      get;
      set;
    }

    public StateExclExclusion StateExclExclusion { get; set; }
  }
}
