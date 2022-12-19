using CleanCodeLab.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces
{
    public interface ITopList
    {
        public void SaveToTopList(GameNameEnum.GameName gameName, string playerName, int guesses);
        public void PrintTopList(GameNameEnum.GameName gameName);
    }
}
