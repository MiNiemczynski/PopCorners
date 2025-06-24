using System.Windows.Input;

namespace PopCorners.Models.DTOs
{
    public class CommandsSetDTO
    {
        public string DisplayName { get; set; }
        public ICommand CommandSingle { get; set; }
        public ICommand CommandMany { get; set; }
        public CommandsSetDTO(string name, ICommand single, ICommand many)
        {
            DisplayName = name;
            CommandSingle = single;
            CommandMany = many;
        }
    }
}
