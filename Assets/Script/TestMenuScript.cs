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

    private static bool isInit = false;

    private void Start()
    {
        if (isInit) return;
         
        GamePassive.Init();
        GameSkill.Init();

        isInit = true;
    }

    public void Test()
    {
        EncounterState.NewEncounter(EncounterSheet.TEST_1);
    }
}
