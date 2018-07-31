using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventPrompt : MonoBehaviour {

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text description;

    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private string[] options;

    [SerializeField]
    private int offset;


    // Use this for initialization
    void Start () {

        this.updatePrompt();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void updatePrompt()
    {
        this.title.text = EventState.title;
        this.description.text = EventState.description;
        this.options = EventState.options;

       
        for (int i = 0; i < EventState.options.Length; i++)
        {
            
            Button button = Instantiate<GameObject>(buttonPrefab, this.transform).GetComponent<Button>();
            button.transform.Translate(0.0f, 75 * i, 0.0f, Space.World); ;
            button.GetComponentInChildren<Text>().text = this.options[i];
        }

    }
}
