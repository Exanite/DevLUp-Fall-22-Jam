using UnityEngine;

namespace Project.Source
{
    public abstract class Ability : ScriptableObject
    {
        public Sprite Icon;
        
        public float Cooldown = 1;
        public float WaxCost = 1;
    }
}