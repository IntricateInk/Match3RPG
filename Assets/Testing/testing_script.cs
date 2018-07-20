using Match3.Character;
using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Overworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testing_script : MonoBehaviour {

    [SerializeField]
    private Transform encounter_container;

    [SerializeField]
    private Transform trophy_container;

    [SerializeField]
    private GameObject prefab;

    private List<TrophySheet> trophies;
    private List<EncounterSheet> encounters;

    private void Start()
    {
        this.trophies = TrophySheet.AllTrophies;
        this.encounters = EncounterSheet.AllEncounters;
        PlayerSheet player = OverworldState.Current.player;

        for (int i = 0; i < this.trophies.Count; i++)
        {
            int j = i;
            GameObject go = Instantiate(prefab, trophy_container);
            go.GetComponentInChildren<Text>().text = trophies[i].name;
            go.GetComponentInChildren<Image>().sprite = trophies[i].GetSprite();
            go.GetComponentInChildren<Button>().onClick.AddListener(() => TrophyButtonClick(go, j));

            if (player.trophies.Contains(trophies[i]))
            {
                go.GetComponentInChildren<Image>().color = Color.white;
            }
            else
            {
                go.GetComponentInChildren<Image>().color = Color.grey;
            }
        }

        for (int i = 0; i < this.encounters.Count; i++)
        {
            int j = i;
            GameObject go = Instantiate(prefab, encounter_container);
            go.GetComponentInChildren<Text>().text = encounters[i].name;
            go.GetComponentInChildren<Image>().sprite = encounters[i].GetSprite();
            go.GetComponentInChildren<Button>().onClick.AddListener(() => EncounterButtonClick(j));
        }
    }

    public void EncounterButtonClick(int i)
    {
        EncounterState.NewEncounter(this.encounters[i]);
    }   

    public void TrophyButtonClick(GameObject btn, int i)
    {
        PlayerSheet player = OverworldState.Current.player;
        
        if (player.trophies.Contains(trophies[i]))
        {
            btn.GetComponentInChildren<Image>().color = Color.grey;
            player.trophies.Remove(trophies[i]);
        } else
        {
            btn.GetComponentInChildren<Image>().color = Color.white;
            player.trophies.Add(trophies[i]);
        }
    }
}
