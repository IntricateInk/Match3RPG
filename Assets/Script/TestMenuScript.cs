using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Character;
using Match3.Encounter.Effect.Passive;
using Match3.Encounter.Effect.Skill;
using Match3.Overworld;

public class TestMenuScript : MonoBehaviour {
    
    public void Test()
    {
        EncounterState.NewEncounter(EncounterSheet.TEST_1);
    }
}
