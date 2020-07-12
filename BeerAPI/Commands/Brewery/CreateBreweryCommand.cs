using System;
using System.Threading;
using System.Threading.Tasks;
using BeerAPI.Data;
using BeerAPI.Models.FormModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Commands.Brewery
{
    // CM 07/11/2020
    // This class defines the process to add or update an existing brewery inside the database
    public class CreateBreweryCommand : IRequest<ICommandResult>
    {
        // a statically typed form
        public AddOrUpdateBreweryForm Editor { get; set; }

        // the model state of the form
        public ModelStateDictionary ModelState { get; set; }

        #region ----- CreateBreweryCommand ctor -----

        public CreateBreweryCommand(AddOrUpdateBreweryForm editor,
            ModelStateDictionary modelState)
        {
            Editor = editor;
            ModelState = modelState;
        }

        #endregion

        public class CreateBreweryCommandHandler : IRequestHandler<CreateBreweryCommand, ICommandResult>
        {
            private readonly IApplicationDbContext _context;

            public CreateBreweryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ICommandResult> Handle(CreateBreweryCommand command, CancellationToken cancellationToken)
            {
                if (!command.ModelState.IsValid)
                    return new CommandResult();
                if (command.Editor.Id != 0)
                {
                    return await UpdateBrewery(command.Editor);
                }

                return await CreateBrewery(command.Editor);
            }

            private async Task<ICommandResult> CreateBrewery(AddOrUpdateBreweryForm commandEditor)
            {
                try
                {
                    var brewery = new Models.Entities.Brewery
                    {
                        BreweryName = commandEditor.BreweryName,
                        MasterBrewer = commandEditor.MasterBrewer,
                        Address = commandEditor.Address,
                        StateAbbr = commandEditor.StateAbbr,
                        ZipCode = commandEditor.ZipCode,
                        CreatedBy = commandEditor.CreatedBy,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = commandEditor.ModifiedBy,
                        ModifiedDate = DateTime.Now
                    };

                    _context.Breweries.Add(brewery);
                    await _context.SaveChangesAsync();
                    var result = new CommandResult()
                    {
                        IsSuccess = true,
                        Result = brewery
                    };
                    return result;
                }
                catch (Exception ex)
                {
                    return default;
                }
            }

            private async Task<CommandResult> UpdateBrewery(AddOrUpdateBreweryForm commandEditor)
            {
                try
                {
                    var breweryToUpdate = await _context.Breweries.FirstOrDefaultAsync(d => d.Id == commandEditor.Id)
                        .ConfigureAwait(false);
                    if (breweryToUpdate == null) return default;
                    breweryToUpdate.BreweryName = commandEditor.BreweryName;
                    breweryToUpdate.MasterBrewer = commandEditor.MasterBrewer;
                    breweryToUpdate.Address = commandEditor.Address;
                    breweryToUpdate.StateAbbr = commandEditor.StateAbbr;
                    breweryToUpdate.ZipCode = commandEditor.ZipCode;
                    breweryToUpdate.ModifiedBy = commandEditor.ModifiedBy;
                    breweryToUpdate.ModifiedDate = DateTime.Now;
                    if (await _context.SaveChangesAsync() <= 0) return default;
                    var result = new CommandResult()
                    {
                        IsSuccess = true,
                        Result = breweryToUpdate
                    };
                    return result;
                }
                catch (Exception ex)
                {
                    return default;
                }
            }
        }
    }
}