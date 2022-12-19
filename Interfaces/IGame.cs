using CleanCodeLab.Enums;

namespace CleanCodeLab.Interfaces
{
    public interface IGame
    {
        public string GameTitle { get; set; }
        public GameNameEnum.GameName GameName { get; set; }

        public void Start(string playerName);
    }
}
