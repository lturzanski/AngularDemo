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



namespace AngularDemo.Controllers.StateExclusions
{
  using Models;
  using Data;
  using Models.StateExclusions;

  [ODataRoutePrefix("odata/StateExclusions/StateExclExclusionDates")]
  [Route("mvc/odata/StateExclusions/StateExclExclusionDates")]
  public partial class StateExclExclusionDatesController : ODataController
  {
    private Data.StateExclusionsContext context;

    public StateExclExclusionDatesController(Data.StateExclusionsContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusions/StateExclExclusionDates
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusions.StateExclExclusionDate> GetStateExclExclusionDates()
    {
      var items = this.context.StateExclExclusionDates.AsQueryable<Models.StateExclusions.StateExclExclusionDate>();
      this.OnStateExclExclusionDatesRead(ref items);

      return items;
    }

    partial void OnStateExclExclusionDatesRead(ref IQueryable<Models.StateExclusions.StateExclExclusionDate> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<StateExclExclusionDate> GetStateExclExclusionDate(int key)
    {
        var items = this.context.StateExclExclusionDates.Where(i=>i.Id == key);
        this.OnStateExclExclusionDatesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStateExclExclusionDatesGet(ref IQueryable<Models.StateExclusions.StateExclExclusionDate> items);

    partial void OnStateExclExclusionDateDeleted(Models.StateExclusions.StateExclExclusionDate item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteStateExclExclusionDate(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.StateExclExclusionDates
                .Where(i => i.Id == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnStateExclExclusionDateDeleted(itemToDelete);
            this.context.StateExclExclusionDates.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclExclusionDateUpdated(Models.StateExclusions.StateExclExclusionDate item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStateExclExclusionDate(int key, [FromBody]Models.StateExclusions.StateExclExclusionDate newItem)
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

            this.OnStateExclExclusionDateUpdated(newItem);
            this.context.StateExclExclusionDates.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclExclusionDates.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StateExclExclusion");
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
    public IActionResult PatchStateExclExclusionDate(int key, [FromBody]Delta<Models.StateExclusions.StateExclExclusionDate> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.StateExclExclusionDates.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnStateExclExclusionDateUpdated(itemToUpdate);
            this.context.StateExclExclusionDates.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclExclusionDates.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StateExclExclusion");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclExclusionDateCreated(Models.StateExclusions.StateExclExclusionDate item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusions.StateExclExclusionDate item)
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

            this.OnStateExclExclusionDateCreated(item);
            this.context.StateExclExclusionDates.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.StateExclExclusionDates.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "StateExclExclusion");

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
