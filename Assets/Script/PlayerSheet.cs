using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public class PlayerSheet
    {

        public readonly List<TokenType> tokenDrawList;
        public readonly List<TrophySheet> trophies;

        public PlayerSheet()
        {
            this.tokenDrawList = new List<TokenType>()
            {
                TokenType.STRENGTH,
                TokenType.AGILITY,
                TokenType.CHARISMA,
                TokenType.INTELLIGENCE,
                TokenType.LUCK,
            };

            this.trophies = new List<TrophySheet>()
            {

            };
        }
    }
}
