using Match3.Events.core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventDisplay : MonoBehaviour {

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text result;

    [SerializeField]
    private Text description;

    [SerializeField]
    private Image eventImage;

    [SerializeField]
    private Button[] buttons;

    [SerializeField]
    private string[] optionsText;

    
    [SerializeField]
    private int offset;



    private GameEvent _gameEvent= null;
    public GameEvent gameEvent
    {
        get { return _gameEvent; }
        set
        {
            _gameEvent = value;

            if (gameEvent != null)
            {
                this.title.text = this.gameEvent.title;
               
                this.description.text = this.gameEvent.body;
                this.optionsText = this.gameEvent.optionsText;

                this.eventImage.sprite = this.gameEvent.image;
                int optionsLength = this.optionsText.Length;

                for (int i = 0; i < this.buttons.Length; i++)
                {
                    //Debug.Log("i is " + i + " optiosnText is " + this.optionsText[i]);
                    if (i < optionsLength)
                    {
                        this.buttons[i].gameObject.SetActive(true);
                        this.buttons[i].GetComponentInChildren<Text>().text = gameEvent.optionsText[i];
                    }
                    else
                    {
                        this.buttons[i].gameObject.SetActive(false);

                    }
                }
            }
        }
    }

    // Use this for initialization
    void Start () {

        if (EventState.gameEvent == null)
        {
            throw new System.Exception("gameEvent not found in UIEventPrompt");
        }

        this.gameEvent = EventState.gameEvent;
    }
    
    public void updateGUI(string body, string[] optionsText, string result, Sprite img)
    {
        this.description.text = body;
        this.optionsText = this.gameEvent.optionsText;
        this.result.text = result;
        this.eventImage.sprite = img;

        int optionsLength = this.optionsText.Length;

        for (int i = 0; i < this.buttons.Length; i++)
        {
            //Debug.Log("i is " + i + " optiosnText is " + this.optionsText[i]);
            if (i < optionsLength)
            {
                this.buttons[i].gameObject.SetActive(true);
                this.buttons[i].GetComponentInChildren<Text>().text = gameEvent.optionsText[i];
            }
            else
            {
                this.buttons[i].gameObject.SetActive(false);

            }
        }
    }

    public void OnButtonClick(int i)
    {
        EventManager.instance.onEventChoiceClick(i);
    }
}
