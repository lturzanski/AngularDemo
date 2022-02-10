using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusionsDatabase
{
  [Table("States", Schema = "dbo")]
  public partial class State
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }


    public ICollection<StateExclusion> StateExclusions { get; set; }
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
