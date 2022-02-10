using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDemo.Models.StateExclusionsDatabase
{
  [Table("StateExclusionView", Schema = "dbo")]
  public partial class StateExclusionView
  {
    [Key]
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
    public int StateExclusionId
    {
      get;
      set;
    }
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
    public DateTime Date
    {
      get;
      set;
    }
    public int StateId
    {
      get;
      set;
    }
    public int ExclusionId
    {
      get;
      set;
    }
    public int ExclusionDateId
    {
      get;
      set;
    }
  }
}
