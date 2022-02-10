using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Query;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace AngularDemo.Controllers.StateExclusionsDatabase
{
  using Models;
  using Data;
  using Models.StateExclusionsDatabase;

  [ODataRoutePrefix("odata/StateExclusionsDatabase/StateExclusionViews")]
  [Route("mvc/odata/StateExclusionsDatabase/StateExclusionViews")]
  public partial class StateExclusionViewsController : ODataController
  {
    private Data.StateExclusionsDatabaseContext context;

    public StateExclusionViewsController(Data.StateExclusionsDatabaseContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusionsDatabase/StateExclusionViews
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusionsDatabase.StateExclusionView> GetStateExclusionViews()
    {
      var items = this.context.StateExclusionViews.AsNoTracking().AsQueryable<Models.StateExclusionsDatabase.StateExclusionView>();
      this.OnStateExclusionViewsRead(ref items);

      return items;
    }

    partial void OnStateExclusionViewsRead(ref IQueryable<Models.StateExclusionsDatabase.StateExclusionView> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{StateName}")]
    public SingleResult<StateExclusionView> GetStateExclusionView(string key)
    {
        var items = this.context.StateExclusionViews.AsNoTracking().Where(i=>i.StateName == key);
        this.OnStateExclusionViewsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStateExclusionViewsGet(ref IQueryable<Models.StateExclusionsDatabase.StateExclusionView> items);

  }
}
