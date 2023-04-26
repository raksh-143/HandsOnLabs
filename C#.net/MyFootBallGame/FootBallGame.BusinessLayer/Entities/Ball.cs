using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallGame.BusinessLayer.Entities
{
    public abstract class Ball
    {
        public Observer Subject { get; set; }
        public virtual void Attach(Observer O) { 
            throw new NotImplementedException();
        }
        public virtual void Detach(Observer O)
        {
            throw new NotImplementedException();
        }
        public virtual void Notify()
        {
            throw new NotImplementedException();
        }

    }
}
