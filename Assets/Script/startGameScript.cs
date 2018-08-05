using Match3.Character;
using Match3.Overworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGameScript : MonoBehaviour
{

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button classButtonPrefab;

    [SerializeField]
    private  List<Button> characters;

    [SerializeField]
    private GridLayoutGroup grid;
	// Use this for initialization
	void Start () {
        characters = new List<Button>();
        playButton.onClick.AddListener(this.transitionToCharacterScreen);

        
        
	}
	

    void transitionToCharacterScreen()
    {
        this.playButton.gameObject.SetActive(false);

        List<KeyValuePair<string, TrophySheet>> baseClasses = TrophySheet.getAllClasses();

        foreach (KeyValuePair<string, TrophySheet> pair in baseClasses)
        {
            Button b = Instantiate<Button>(classButtonPrefab);
            b.GetComponentInChildren<Text>().text = pair.Key;
            b.transform.SetParent(grid.transform, false);
            b.onClick.AddListener(() =>
            {
                TrophySheet baseTrophy = pair.Value;
                OverworldState.Current.player.AddTrophy(baseTrophy);
               
            });
        }
    }

    void proceed()
    {
        SceneManager.LoadScene(1);
    }



    
}
