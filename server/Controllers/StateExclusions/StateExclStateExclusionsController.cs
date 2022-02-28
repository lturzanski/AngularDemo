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

  [ODataRoutePrefix("odata/StateExclusions/StateExclStateExclusions")]
  [Route("mvc/odata/StateExclusions/StateExclStateExclusions")]
  public partial class StateExclStateExclusionsController : ODataController
  {
    private Data.StateExclusionsContext context;

    public StateExclStateExclusionsController(Data.StateExclusionsContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusions/StateExclStateExclusions
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusions.StateExclStateExclusion> GetStateExclStateExclusions()
    {
      var items = this.context.StateExclStateExclusions.AsQueryable<Models.StateExclusions.StateExclStateExclusion>();
      this.OnStateExclStateExclusionsRead(ref items);

      return items;
    }

    partial void OnStateExclStateExclusionsRead(ref IQueryable<Models.StateExclusions.StateExclStateExclusion> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<StateExclStateExclusion> GetStateExclStateExclusion(int key)
    {
        var items = this.context.StateExclStateExclusions.Where(i=>i.Id == key);
        this.OnStateExclStateExclusionsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStateExclStateExclusionsGet(ref IQueryable<Models.StateExclusions.StateExclStateExclusion> items);

    partial void OnStateExclStateExclusionDeleted(Models.StateExclusions.StateExclStateExclusion item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteStateExclStateExclusion(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.StateExclStateExclusions
                .Where(i => i.Id == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnStateExclStateExclusionDeleted(itemToDelete);
            this.context.StateExclStateExclusions.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclStateExclusionUpdated(Models.StateExclusions.StateExclStateExclusion item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStateExclStateExclusion(int key, [FromBody]Models.StateExclusions.StateExclStateExclusion newItem)
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

            this.OnStateExclStateExclusionUpdated(newItem);
            this.context.StateExclStateExclusions.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclStateExclusions.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StateExclState,StateExclExclusion");
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
    public IActionResult PatchStateExclStateExclusion(int key, [FromBody]Delta<Models.StateExclusions.StateExclStateExclusion> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.StateExclStateExclusions.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnStateExclStateExclusionUpdated(itemToUpdate);
            this.context.StateExclStateExclusions.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclStateExclusions.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StateExclState,StateExclExclusion");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclStateExclusionCreated(Models.StateExclusions.StateExclStateExclusion item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusions.StateExclStateExclusion item)
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

            this.OnStateExclStateExclusionCreated(item);
            this.context.StateExclStateExclusions.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.StateExclStateExclusions.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "StateExclState,StateExclExclusion");

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
