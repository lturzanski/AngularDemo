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

  [ODataRoutePrefix("odata/StateExclusionsDatabase/ExclusionDates")]
  [Route("mvc/odata/StateExclusionsDatabase/ExclusionDates")]
  public partial class ExclusionDatesController : ODataController
  {
    private Data.StateExclusionsDatabaseContext context;

    public ExclusionDatesController(Data.StateExclusionsDatabaseContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusionsDatabase/ExclusionDates
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusionsDatabase.ExclusionDate> GetExclusionDates()
    {
      var items = this.context.ExclusionDates.AsQueryable<Models.StateExclusionsDatabase.ExclusionDate>();
      this.OnExclusionDatesRead(ref items);

      return items;
    }

    partial void OnExclusionDatesRead(ref IQueryable<Models.StateExclusionsDatabase.ExclusionDate> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<ExclusionDate> GetExclusionDate(int key)
    {
        var items = this.context.ExclusionDates.Where(i=>i.Id == key);
        this.OnExclusionDatesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnExclusionDatesGet(ref IQueryable<Models.StateExclusionsDatabase.ExclusionDate> items);

    partial void OnExclusionDateDeleted(Models.StateExclusionsDatabase.ExclusionDate item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteExclusionDate(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.ExclusionDates
                .Where(i => i.Id == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnExclusionDateDeleted(itemToDelete);
            this.context.ExclusionDates.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnExclusionDateUpdated(Models.StateExclusionsDatabase.ExclusionDate item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutExclusionDate(int key, [FromBody]Models.StateExclusionsDatabase.ExclusionDate newItem)
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

            this.OnExclusionDateUpdated(newItem);
            this.context.ExclusionDates.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.ExclusionDates.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Exclusion");
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
    public IActionResult PatchExclusionDate(int key, [FromBody]Delta<Models.StateExclusionsDatabase.ExclusionDate> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.ExclusionDates.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnExclusionDateUpdated(itemToUpdate);
            this.context.ExclusionDates.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.ExclusionDates.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Exclusion");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnExclusionDateCreated(Models.StateExclusionsDatabase.ExclusionDate item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusionsDatabase.ExclusionDate item)
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

            this.OnExclusionDateCreated(item);
            this.context.ExclusionDates.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.ExclusionDates.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Exclusion");

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
