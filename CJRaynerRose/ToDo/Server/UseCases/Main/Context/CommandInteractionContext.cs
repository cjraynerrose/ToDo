using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CJRaynerRose.ToDo.Common.Context;

namespace CJRaynerRose.ToDo.Server.UseCases.Main.Context
{
    public class CommandInteractionContext : InteractionContext<bool?>
    {
        public override bool? GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
