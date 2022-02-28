using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusions
{
  [Table("StateExcl_State", Schema = "dbo")]
  public partial class StateExclState
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }


    public ICollection<StateExclStateExclusion> StateExclStateExclusions { get; set; }
    public string StateName
    {
      get;
      set;
    }
    public string StateAbbreviation
    {
      get;
      set;
    }
  }
}
