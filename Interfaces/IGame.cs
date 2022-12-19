using CleanCodeLab.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces
{
    public interface IGame
    {
        public string GameTitle { get; set; }
        public GameNameEnum.GameName GameName { get; set; }

        public void Start(string playerName);
    }
}
