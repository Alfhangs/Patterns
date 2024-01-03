using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Behaviour.Command
{
    public class Consumer : MonoBehaviour
    {
        private List<ICommand> _commandsKey1;
        private List<ICommand> _commandsKey2;

        public void Configure(List<ICommand> commandsKey1, List<ICommand> commandsKey2)
        {
            _commandsKey1 = commandsKey1;
            _commandsKey2 = commandsKey2;
        }

        private void Update()
        {
            var commandQueue = CommandQueue.Instance;
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                foreach (var command in _commandsKey1)
                {
                    commandQueue.AddCommand(command);
                }
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                foreach (var command in _commandsKey2)
                {
                    commandQueue.AddCommand(command);
                }
            }
        }
    }
}
