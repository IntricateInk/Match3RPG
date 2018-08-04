using Match3.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Overworld
{
    public class InventoryGroupController : MonoBehaviour
    {
        [SerializeField]
        private TrophyController prefab;

        [SerializeField]
        private Transform container;

        private void Awake()
        {
            PlayerSheet player = OverworldState.Current.player;

            foreach (TrophySheet trophy in player.trophies)
            {
                this.OnNewTrophy(trophy);
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
            TrophyController item = Instantiate<TrophyController>(prefab, container);
            item.ShowLearnButton(false);
            item.trophy = trophy;
        }
    }
}