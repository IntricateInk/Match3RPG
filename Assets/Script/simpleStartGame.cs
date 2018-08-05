using Match3.Character;
using Match3.Overworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class simpleStartGame : MonoBehaviour {
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button brigandButton;

    [SerializeField]
    private Button vagabondButton;
	// Use this for initialization
	void Start () {
        playButton.onClick.AddListener(moveToCharacterScreen);
        brigandButton.onClick.AddListener(onBrigandClick);
        vagabondButton.onClick.AddListener(onVagabondClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void moveToCharacterScreen()
    {
        playButton.gameObject.SetActive(false);
        title.SetActive(false);
        brigandButton.gameObject.SetActive(true);
        vagabondButton.gameObject.SetActive(true);
    }

    void onBrigandClick()
    {
        TrophySheet[] trophies = TrophySheet.getSimpleClass("Brigand");
        foreach(TrophySheet trophy in trophies)
        {
            OverworldState.Current.player.AddTrophy(trophy);
        }
        SceneManager.LoadScene(1);
    }

    void onVagabondClick()
    {
        TrophySheet[] trophies = TrophySheet.getSimpleClass("Vagabond");
        foreach (TrophySheet trophy in trophies)
        {
            OverworldState.Current.player.AddTrophy(trophy);
        }
        SceneManager.LoadScene(1);
    }
}
