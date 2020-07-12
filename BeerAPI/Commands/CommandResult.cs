namespace BeerAPI.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
    }
}