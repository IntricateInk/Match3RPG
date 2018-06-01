using System.Collections.Generic;

namespace Match3.Character
{
    public interface IReward
    {
        int GoldReward { get; }
        int ExperienceReward { get; }
        string[] TrophiesReward { get; }
        
    }
}