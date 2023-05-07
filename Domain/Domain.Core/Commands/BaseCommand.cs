using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Events;

namespace Domain.Core.Commands
{
    public abstract class BaseCommand : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected BaseCommand()
        {
            Timestamp = DateTime.Now;
        }
    }
}