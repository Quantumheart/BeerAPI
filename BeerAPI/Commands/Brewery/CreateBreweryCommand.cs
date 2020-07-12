using System.Threading;
using System.Threading.Tasks;
using BeerAPI.Data;
using BeerAPI.Models.FormModels;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Commands.Brewery
{
    public class CreateBreweryCommand : IRequest<ICommandResult>
    {
        private AddOrUpdateBreweryForm Editor { get; set; }
        private ModelStateDictionary ModelState { get; set; }

        public CreateBreweryCommand(AddOrUpdateBreweryForm editor,
            ModelStateDictionary modelState)
        {
            Editor = editor;
            ModelState = modelState;
        }

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

                return new CommandResult();
            }

            private async Task<ICommandResult> CreateBrewery(AddOrUpdateBreweryForm commandEditor)
            {
                var brewery = new Models.Entities.Brewery
                {
                    BreweryName = commandEditor.BreweryName,
                    MasterBrewer = commandEditor.MasterBrewer,
                    Address = commandEditor.Address,
                    StateAbbr = commandEditor.StateAbbr,
                    ZipCode = commandEditor.ZipCode,
                    Beers = commandEditor.Beers
                };

                _context.Breweries.Add(brewery);
                await _context.SaveChangesAsync();
                var result = new CommandResult() { Result = brewery};
                return result;
            }

            private async Task<CommandResult> UpdateBrewery(AddOrUpdateBreweryForm commandEditor)
            {
                var breweryToUpdate = await _context.Breweries.FirstOrDefaultAsync(d => d.Id == commandEditor.Id)
                    .ConfigureAwait(false);
                if (breweryToUpdate == null) return default;
                breweryToUpdate.BreweryName = commandEditor.BreweryName;
                breweryToUpdate.MasterBrewer = commandEditor.MasterBrewer;
                breweryToUpdate.Address = commandEditor.Address;
                breweryToUpdate.StateAbbr = commandEditor.StateAbbr;
                breweryToUpdate.ZipCode = commandEditor.ZipCode;
                breweryToUpdate.Beers = commandEditor.Beers;
                if (await _context.SaveChangesAsync() <= 0) return default;
                var result = new CommandResult()
                {
                    Result = breweryToUpdate
                };
                return result;

            }
        }
    }
}