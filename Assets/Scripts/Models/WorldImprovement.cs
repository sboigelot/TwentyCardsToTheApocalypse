using System;

namespace Assets.Scripts.Models
{
    public class WorldImprovement
    {
        public virtual void OnStatChange(string statName, int value)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return new WorldImprovement();
        }
    }
}