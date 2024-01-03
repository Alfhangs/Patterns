using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterns.Structural.Composite.Command
{
    public class CompositeCommand : Behaviour.Command.ICommand
    {
        private readonly List<Behaviour.Command.ICommand> _commands;

        public CompositeCommand()
        {
            _commands = new List<Behaviour.Command.ICommand>();
        }

        public void AddCommand(Behaviour.Command.ICommand command)
        {
            _commands.Add(command);
        }
        
        public async Task Execute()
        {
            var tasks = new List<Task>(_commands.Count);
            foreach (var command in _commands)
            {
                var task = command.Execute();
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
