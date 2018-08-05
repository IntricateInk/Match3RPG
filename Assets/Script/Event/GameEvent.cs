using Match3.Overworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Events.core
{

    public abstract class GameEvent
    {
        public int screenNum = 0;
        public virtual string title { get; set; }
        public virtual string body { get; set; }
        public virtual string[] optionsText { get; set; }
        public virtual string result { get; set; }
        public Sprite image;
        public List<int> optionsSelected = new List<int>();
        private int[] weights;
        // FORMAT SHORE SEA TOWNS FOREST RUINS BOSS

        public GameEvent(string title, string body, string[] optionsText, string imgUrl, int[] weights)
        {
            
            this.title = title;
            this.body = body;
            this.image = initializeImage(imgUrl);
            this.optionsText = optionsText;
            this.weights = weights;
        }

        public int GetWeight(OverworldNodeType nodeType)
        {
            return this.weights[nodeType.AsInt()];
        }

        protected Sprite initializeImage(string url)
        {
            return Resources.Load<Sprite>(url);
        }

        public abstract void onButtonPress(int paramInt);

        public void updateDialog( string body, string[] optionsText, string result, string imgUrl)
        {
            this.body = body;
            this.image = initializeImage(imgUrl);
            this.optionsText = optionsText;
            this.result = result;
            EventManager.instance.MainDisplay.updateGUI(body, optionsText, result, this.image);
        }


        
    }
}
