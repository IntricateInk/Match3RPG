using Match3.Character;
using Match3.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match3.Overworld
{
    public class OverworldState
    {
        public static OverworldState Current = new OverworldState();
        
        private OverworldState()
        {
            this.player = new PlayerSheet(
                name:    "Thief",
                sprite:  "tokens/agi",
                tooltip: "Swift and silent",
                trophies: new string[0]
            );
        }
        
        public void GoToOverworld()
        {
            SceneManager.LoadScene("overworld");
        }

        public readonly PlayerSheet player;
    }
}