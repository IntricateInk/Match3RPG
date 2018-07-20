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
using UnityEngine.UI;

public class TestMenuScript : MonoBehaviour {

    [SerializeField]
    private Text goldLabel;

    [SerializeField]
    private Text expLabel;

    public void Update()
    {
        PlayerSheet player = OverworldState.Current.player;

        this.goldLabel.text = player.Gold.ToString();
        this.expLabel.text  = player.Experience.ToString();
    } 

    public void Test()
    {
        EncounterState.NewEncounter(EncounterSheet.AllEncounters[0]);
    }
}
