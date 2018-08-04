using Match3.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Overworld
{
    public class ExperienceGroupController : MonoBehaviour
    {
        [SerializeField]
        private TrophyController prefab;

        [SerializeField]
        private Transform container;

        private List<TrophyController> items = new List<TrophyController>();

        private void Awake()
        {
            PlayerSheet player = OverworldState.Current.player;

            foreach (TrophySheet trophy in player.GetUpgrades())
            {
                this.CreateTrophy(trophy);
            }

            player.OnNewTrophy += OnNewTrophy;
        }

        private void OnDestroy()
        {
            PlayerSheet player = OverworldState.Current.player;

            player.OnNewTrophy -= OnNewTrophy;
        }

        private void OnNewTrophy(TrophySheet trophy)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                TrophyController item = this.items[i];
                if (item.trophy == trophy)
                {
                    this.items.Remove(item);
                    Destroy(item.gameObject);
                    break;
                }
            }
            
            foreach (TrophySheet upgrade in TrophySheet.GetTrophy(trophy.upgrades))
            {
                this.CreateTrophy(upgrade);
            }
        }

        private void CreateTrophy(TrophySheet trophy)
        {
            PlayerSheet player = OverworldState.Current.player;

            if (player.trophies.Contains(trophy)) return;
            foreach (TrophyController item in this.items)
            {
                if (item.trophy == trophy) return;
            }

            TrophyController new_item = Instantiate<TrophyController>(prefab, container);
            new_item.trophy = trophy;
            this.items.Add(new_item);
        }
    }
}