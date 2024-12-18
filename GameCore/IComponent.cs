using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public interface IComponent
    {
        GameObject Parent { get; set; }

        void Start();
        void Update();
    }
}
