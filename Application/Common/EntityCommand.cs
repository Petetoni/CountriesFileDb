namespace Application.Common
{
    public class EntityCommand<TId>
    {
        public TId CountryCode { get; set; } = default!;
    }

    public static class EntityCommandExtensions
    {
        public static TCommand SetCode<TCommand, TId>(this TCommand command, TId code)
            where TCommand : EntityCommand<TId>
        {
            command.CountryCode = code;
            return command;
        }
    }
}
