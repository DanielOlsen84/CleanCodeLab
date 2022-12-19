using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces
{
    public interface ITopList
    {
        public void SaveToTopList(string playerName, int guesses);
        public void PrintTopList();
    }
}
