namespace BeerAPI.Commands
{
    public interface ICommandResult
    {
        public bool IsSuccess { get; }
        public bool IsFailure { get; }
        public object Result { get; set; }
        
    }
}