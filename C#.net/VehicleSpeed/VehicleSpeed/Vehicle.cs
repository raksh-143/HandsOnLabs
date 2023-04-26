using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSpeed
{
    internal class Vehicle
    {
        public int CurrentSpeed { get; internal set; }
        public int MaximumSpeed { get; set; }
        public Vehicle() { }
        public Vehicle(int Cur,int Max) { 
            CurrentSpeed = Cur;
            MaximumSpeed = Max;
        }
        public void IncreaseSpeed(int factor)
        {
            CurrentSpeed += factor;
            if (CurrentSpeed > MaximumSpeed)
            {
                throw new SpeedMoreThanMaximumException("Speed more than maximum speed! Slow down!");
            }
        }
    }
}
