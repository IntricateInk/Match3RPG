using System.Collections.Generic;

namespace Match3.Character
{
    public sealed class Reward
    {
        public readonly int Gold;
        public readonly int Experience;
        public readonly List<string> Trophies;

        public Reward(int gold, int experience, IEnumerable<string> trophies)
        {
            this.Gold = gold;
            this.Experience = experience;
            this.Trophies = new List<string>(trophies);
        }
    }
}