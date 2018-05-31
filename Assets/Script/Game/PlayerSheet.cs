using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public class PlayerSheet
    {
        public int Gold;
        public int Experience;

        public readonly List<TokenType> tokenDrawList;
        public readonly List<TrophySheet> trophies;

        public PlayerSheet(IEnumerable<TrophySheet> trophies)
        {
            this.Gold = 0;
            this.Experience = 0;

            this.tokenDrawList = new List<TokenType>()
            {
                TokenType.STRENGTH,
                TokenType.AGILITY,
                TokenType.CHARISMA,
                TokenType.INTELLIGENCE,
                TokenType.LUCK,
            };

            this.trophies = new List<TrophySheet>(trophies);
        }

        public void GainReward(Reward reward)
        {
            this.Gold += reward.Gold;
            this.Experience += reward.Experience;

            foreach (string trophyName in reward.Trophies)
            {

            }
        }
    }
}
