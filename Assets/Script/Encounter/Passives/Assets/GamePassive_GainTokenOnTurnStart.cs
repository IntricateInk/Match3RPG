using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Passive
{

    public class GamePassive_GainTokenOnTurnState :
        GamePassive, IPassive_OnTurnStart
    {
        public GamePassive_GainTokenOnTurnState
            (string name, string sprite, string tooltip, TokenType token, int amount) : base(name, sprite, tooltip)
        {
            this.token = token;
            this.amount = amount;
        }

        private readonly int amount;
        private readonly TokenType token;

        public void OnTurnStart(EncounterState encounter)
        {
            encounter.playerState.Resources[this.token.AsInt()] += this.amount;
        }
    }
}