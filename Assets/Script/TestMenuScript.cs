using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Match3.Game;
using Match3.Game.Encounter;
using Match3.Character;

public class TestMenuScript : MonoBehaviour {

    public void Test()
    {
        EncounterObjective obj1 = new EncounterObjective
        (
            name: "Beat Up", 
            sprite: "skills/bash", 
            tooltip: "Hi!", 
            condition: new EncounterObjectiveCondition
            (
                Turn: 99999, 
                TurnCondition: EncounterObjectiveCondition.Condition.EQUAL
            ), 
            reward: null
        );

        EncounterObjective obj2 = new EncounterObjective
        (
            name: "Punch", 
            sprite: "skills/bash", 
            tooltip: "Hi!", 
            condition: new EncounterObjectiveCondition
            (
                Strength: 5, 
                StrengthCondition: EncounterObjectiveCondition.Condition.EQUAL_AND_MORE
            ), 
            reward: null
        );

        EncounterSheet encounter = new EncounterSheet
            (
                name: "Brawl",
                icon: "skills/bash",
                mainObjectives: new List<EncounterObjective>() { obj1 },
                bonusObjectives: new List<EncounterObjective>() { obj2 }
            );

        TrophySheet trophy1 = TrophySheet.Create("test1");
        TrophySheet trophy2 = TrophySheet.Create("test2");

        PlayerSheet player = new PlayerSheet(new List<TrophySheet>() { trophy1, trophy2 });

        EncounterState.NewEncounter(player, encounter);
    }
}
