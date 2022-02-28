using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusions
{
  [Table("StateExcl_Exclusion", Schema = "dbo")]
  public partial class StateExclExclusion
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }


    public ICollection<StateExclStateExclusion> StateExclStateExclusions { get; set; }

    public ICollection<StateExclExclusionDate> StateExclExclusionDates { get; set; }
    public string ExclusionName
    {
      get;
      set;
    }
    public string ExclusionDescription
    {
      get;
      set;
    }
  }
}
