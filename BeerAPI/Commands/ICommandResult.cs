namespace BeerAPI.Commands
{
    public interface ICommandResult
    {
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        
    }
}