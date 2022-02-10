using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusionsDatabase
{
  [Table("Exclusions", Schema = "dbo")]
  public partial class Exclusion
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }


    public ICollection<StateExclusion> StateExclusions { get; set; }

    public ICollection<ExclusionDate> ExclusionDates { get; set; }
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
