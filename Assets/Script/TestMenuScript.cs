using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Character;
using Match3.Encounter.Passive;
using Match3.Encounter.Skill;
using Match3.Overworld;

public class TestMenuScript : MonoBehaviour {

    private void Start()
    {
        GamePassive.Init();
        GameSkill.Init();
    }

    public void Test()
    {
        EncounterObjective obj1 = new EncounterObjective
        (
            name: "Beat Up",
            sprite: "skills/bash",
            tooltip: "Beat up the bandits",
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
            tooltip: "A satisfying punch!",
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
                tooltip: "FISTS, LOTS AND LOTS OF FISTS",
                mainObjectives: new List<EncounterObjective>() { obj1 },
                bonusObjectives: new List<EncounterObjective>() { obj2 }
            );
        
        EncounterState.NewEncounter(encounter);
    }
}
