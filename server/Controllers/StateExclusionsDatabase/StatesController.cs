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

  [ODataRoutePrefix("odata/StateExclusionsDatabase/States")]
  [Route("mvc/odata/StateExclusionsDatabase/States")]
  public partial class StatesController : ODataController
  {
    private Data.StateExclusionsDatabaseContext context;

    public StatesController(Data.StateExclusionsDatabaseContext context)
    {
      this.context = context;
    }
    // GET /odata/StateExclusionsDatabase/States
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.StateExclusionsDatabase.State> GetStates()
    {
      var items = this.context.States.AsQueryable<Models.StateExclusionsDatabase.State>();
      this.OnStatesRead(ref items);

      return items;
    }

    partial void OnStatesRead(ref IQueryable<Models.StateExclusionsDatabase.State> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<State> GetState(int key)
    {
        var items = this.context.States.Where(i=>i.Id == key);
        this.OnStatesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnStatesGet(ref IQueryable<Models.StateExclusionsDatabase.State> items);

    partial void OnStateDeleted(Models.StateExclusionsDatabase.State item);

    [HttpDelete("{Id}")]
    public IActionResult DeleteState(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.States
                .Where(i => i.Id == key)
                .Include(i => i.StateExclusions)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnStateDeleted(itemToDelete);
            this.context.States.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateUpdated(Models.StateExclusionsDatabase.State item);

    [HttpPut("{Id}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutState(int key, [FromBody]Models.StateExclusionsDatabase.State newItem)
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

            this.OnStateUpdated(newItem);
            this.context.States.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.States.Where(i => i.Id == key);
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
    public IActionResult PatchState(int key, [FromBody]Delta<Models.StateExclusionsDatabase.State> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.States.Where(i => i.Id == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnStateUpdated(itemToUpdate);
            this.context.States.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.States.Where(i => i.Id == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateCreated(Models.StateExclusionsDatabase.State item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.StateExclusionsDatabase.State item)
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

            this.OnStateCreated(item);
            this.context.States.Add(item);
            this.context.SaveChanges();

            return Created($"odata/StateExclusionsDatabase/States/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
