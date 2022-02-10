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

  [ODataRoutePrefix("odata/StateExclusionsDatabase/StateExclusions")]
  [Route("mvc/odata/StateExclusionsDatabase/StateExclusions")]
  public partial class StateExclusionsController : ODataController
  {
    private Data.StateExclusionsDatabaseContext context;

    public StateExclusionsController(Data.StateExclusionsDatabaseContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusionsDatabase/StateExclusions
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusionsDatabase.StateExclusion> GetStateExclusions()
    {
      var items = this.context.StateExclusions.AsQueryable<Models.StateExclusionsDatabase.StateExclusion>();
      this.OnStateExclusionsRead(ref items);

      return items;
    }

    partial void OnStateExclusionsRead(ref IQueryable<Models.StateExclusionsDatabase.StateExclusion> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<StateExclusion> GetStateExclusion(int key)
    {
        var items = this.context.StateExclusions.Where(i=>i.Id == key);
        this.OnStateExclusionsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStateExclusionsGet(ref IQueryable<Models.StateExclusionsDatabase.StateExclusion> items);

    partial void OnStateExclusionDeleted(Models.StateExclusionsDatabase.StateExclusion item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteStateExclusion(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.StateExclusions
                .Where(i => i.Id == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnStateExclusionDeleted(itemToDelete);
            this.context.StateExclusions.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclusionUpdated(Models.StateExclusionsDatabase.StateExclusion item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStateExclusion(int key, [FromBody]Models.StateExclusionsDatabase.StateExclusion newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.Id != key))
            {
                return BadRequest();
            }

            this.OnStateExclusionUpdated(newItem);
            this.context.StateExclusions.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclusions.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "State,Exclusion");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchStateExclusion(int key, [FromBody]Delta<Models.StateExclusionsDatabase.StateExclusion> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.StateExclusions.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnStateExclusionUpdated(itemToUpdate);
            this.context.StateExclusions.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclusions.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "State,Exclusion");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclusionCreated(Models.StateExclusionsDatabase.StateExclusion item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusionsDatabase.StateExclusion item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnStateExclusionCreated(item);
            this.context.StateExclusions.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.StateExclusions.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "State,Exclusion");

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
