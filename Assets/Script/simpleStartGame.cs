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

    [SerializeField]
    private Button VikingButton;

    [SerializeField]
    private Button UndeadTamerButton;

    // Use this for initialization
    void Start () {
        playButton.onClick.AddListener(moveToCharacterScreen);
        brigandButton.onClick.AddListener(onBrigandClick);
        vagabondButton.onClick.AddListener(onVagabondClick);
        VikingButton.onClick.AddListener(onSpiritualistClick);
        UndeadTamerButton.onClick.AddListener(onUndeadTamerClick);


        playButton.gameObject.SetActive(true);
        title.SetActive(true);
        brigandButton.gameObject.SetActive(false);
        vagabondButton.gameObject.SetActive(false);
        VikingButton.gameObject.SetActive(false);
        UndeadTamerButton.gameObject.SetActive(false);

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
        VikingButton.gameObject.SetActive(true);
        UndeadTamerButton.gameObject.SetActive(true);
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

    void onSpiritualistClick()
    {
        TrophySheet[] trophies = TrophySheet.getSimpleClass("Spiritualist");
        foreach (TrophySheet trophy in trophies)
        {
            OverworldState.Current.player.AddTrophy(trophy);
        }
        SceneManager.LoadScene(1);
    }

    void onUndeadTamerClick()
    {
        TrophySheet[] trophies = TrophySheet.getSimpleClass("UndeadTamer");
        foreach (TrophySheet trophy in trophies)
        {
            OverworldState.Current.player.AddTrophy(trophy);
        }
        SceneManager.LoadScene(1);
    }
}
