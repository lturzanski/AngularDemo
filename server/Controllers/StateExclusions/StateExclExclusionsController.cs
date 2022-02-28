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

  [ODataRoutePrefix("odata/StateExclusions/StateExclExclusions")]
  [Route("mvc/odata/StateExclusions/StateExclExclusions")]
  public partial class StateExclExclusionsController : ODataController
  {
    private Data.StateExclusionsContext context;

    public StateExclExclusionsController(Data.StateExclusionsContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusions/StateExclExclusions
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusions.StateExclExclusion> GetStateExclExclusions()
    {
      var items = this.context.StateExclExclusions.AsQueryable<Models.StateExclusions.StateExclExclusion>();
      this.OnStateExclExclusionsRead(ref items);

      return items;
    }

    partial void OnStateExclExclusionsRead(ref IQueryable<Models.StateExclusions.StateExclExclusion> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<StateExclExclusion> GetStateExclExclusion(int key)
    {
        var items = this.context.StateExclExclusions.Where(i=>i.Id == key);
        this.OnStateExclExclusionsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStateExclExclusionsGet(ref IQueryable<Models.StateExclusions.StateExclExclusion> items);

    partial void OnStateExclExclusionDeleted(Models.StateExclusions.StateExclExclusion item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteStateExclExclusion(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.StateExclExclusions
                .Where(i => i.Id == key)
                .Include(i => i.StateExclStateExclusions)
                .Include(i => i.StateExclExclusionDates)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnStateExclExclusionDeleted(itemToDelete);
            this.context.StateExclExclusions.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclExclusionUpdated(Models.StateExclusions.StateExclExclusion item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStateExclExclusion(int key, [FromBody]Models.StateExclusions.StateExclExclusion newItem)
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

            this.OnStateExclExclusionUpdated(newItem);
            this.context.StateExclExclusions.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclExclusions.Where(i => i.Id == key);
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
    public IActionResult PatchStateExclExclusion(int key, [FromBody]Delta<Models.StateExclusions.StateExclExclusion> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.StateExclExclusions.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnStateExclExclusionUpdated(itemToUpdate);
            this.context.StateExclExclusions.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclExclusions.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclExclusionCreated(Models.StateExclusions.StateExclExclusion item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusions.StateExclExclusion item)
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

            this.OnStateExclExclusionCreated(item);
            this.context.StateExclExclusions.Add(item);
            this.context.SaveChanges();

            return Created($"odata/StateExclusions/StateExclExclusions/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
