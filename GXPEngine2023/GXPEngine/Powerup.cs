using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class Powerup
{
        private string type;
        private bool active;

        public Powerup(string type)
        {
            this.type = type;
            active = false;
        }

        public void Activate()
        {
            active = true;
        }

        public void Deactivate()
        {
            active = false;
        }

        public bool IsActive()
        {
            return active;
        }

        public new string GetType()
        {
            return type;
        }
    }

