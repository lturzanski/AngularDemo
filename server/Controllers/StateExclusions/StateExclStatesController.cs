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

  [ODataRoutePrefix("odata/StateExclusions/StateExclStates")]
  [Route("mvc/odata/StateExclusions/StateExclStates")]
  public partial class StateExclStatesController : ODataController
  {
    private Data.StateExclusionsContext context;

    public StateExclStatesController(Data.StateExclusionsContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusions/StateExclStates
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusions.StateExclState> GetStateExclStates()
    {
      var items = this.context.StateExclStates.AsQueryable<Models.StateExclusions.StateExclState>();
      this.OnStateExclStatesRead(ref items);

      return items;
    }

    partial void OnStateExclStatesRead(ref IQueryable<Models.StateExclusions.StateExclState> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<StateExclState> GetStateExclState(int key)
    {
        var items = this.context.StateExclStates.Where(i=>i.Id == key);
        this.OnStateExclStatesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStateExclStatesGet(ref IQueryable<Models.StateExclusions.StateExclState> items);

    partial void OnStateExclStateDeleted(Models.StateExclusions.StateExclState item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteStateExclState(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.StateExclStates
                .Where(i => i.Id == key)
                .Include(i => i.StateExclStateExclusions)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnStateExclStateDeleted(itemToDelete);
            this.context.StateExclStates.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclStateUpdated(Models.StateExclusions.StateExclState item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStateExclState(int key, [FromBody]Models.StateExclusions.StateExclState newItem)
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

            this.OnStateExclStateUpdated(newItem);
            this.context.StateExclStates.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclStates.Where(i => i.Id == key);
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
    public IActionResult PatchStateExclState(int key, [FromBody]Delta<Models.StateExclusions.StateExclState> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.StateExclStates.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnStateExclStateUpdated(itemToUpdate);
            this.context.StateExclStates.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.StateExclStates.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateExclStateCreated(Models.StateExclusions.StateExclState item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusions.StateExclState item)
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

            this.OnStateExclStateCreated(item);
            this.context.StateExclStates.Add(item);
            this.context.SaveChanges();

            return Created($"odata/StateExclusions/StateExclStates/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
