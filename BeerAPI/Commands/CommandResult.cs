namespace BeerAPI.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool IsSuccess { get; } = true;
        public bool IsFailure { get; } = false;
        public object Result { get; set; }
    }
}