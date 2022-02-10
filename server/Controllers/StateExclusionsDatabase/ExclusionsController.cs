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

  [ODataRoutePrefix("odata/StateExclusionsDatabase/Exclusions")]
  [Route("mvc/odata/StateExclusionsDatabase/Exclusions")]
  public partial class ExclusionsController : ODataController
  {
    private Data.StateExclusionsDatabaseContext context;

    public ExclusionsController(Data.StateExclusionsDatabaseContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusionsDatabase/Exclusions
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusionsDatabase.Exclusion> GetExclusions()
    {
      var items = this.context.Exclusions.AsQueryable<Models.StateExclusionsDatabase.Exclusion>();
      this.OnExclusionsRead(ref items);

      return items;
    }

    partial void OnExclusionsRead(ref IQueryable<Models.StateExclusionsDatabase.Exclusion> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<Exclusion> GetExclusion(int key)
    {
        var items = this.context.Exclusions.Where(i=>i.Id == key);
        this.OnExclusionsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnExclusionsGet(ref IQueryable<Models.StateExclusionsDatabase.Exclusion> items);

    partial void OnExclusionDeleted(Models.StateExclusionsDatabase.Exclusion item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteExclusion(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Exclusions
                .Where(i => i.Id == key)
                .Include(i => i.StateExclusions)
                .Include(i => i.ExclusionDates)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnExclusionDeleted(itemToDelete);
            this.context.Exclusions.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnExclusionUpdated(Models.StateExclusionsDatabase.Exclusion item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutExclusion(int key, [FromBody]Models.StateExclusionsDatabase.Exclusion newItem)
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

            this.OnExclusionUpdated(newItem);
            this.context.Exclusions.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Exclusions.Where(i => i.Id == key);
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
    public IActionResult PatchExclusion(int key, [FromBody]Delta<Models.StateExclusionsDatabase.Exclusion> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Exclusions.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnExclusionUpdated(itemToUpdate);
            this.context.Exclusions.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Exclusions.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnExclusionCreated(Models.StateExclusionsDatabase.Exclusion item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusionsDatabase.Exclusion item)
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

            this.OnExclusionCreated(item);
            this.context.Exclusions.Add(item);
            this.context.SaveChanges();

            return Created($"odata/StateExclusionsDatabase/Exclusions/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
