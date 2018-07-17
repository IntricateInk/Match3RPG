﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter;
using System;
using Match3.Encounter.Encounter;
using Match3.Character;

namespace Match3.UI
{
    public class UIFactory : MonoBehaviour
    {

        private static UIFactory Instance;
        
        [SerializeField]
        private UITokenController tokenControllerPrefab;
        
        [SerializeField]
        private UISkillIcon skillIconPrefab;

        [SerializeField]
        private UIBuffIcon uiBuffIconPrefab;

        [SerializeField]
        private UIObjectiveController objectivePrefab;

        [SerializeField]
        private UITrophyController objectiveTrophyPrefab;

        [SerializeField]
        private UIResourceBarController resourceBarPrefab;
        
        internal static UIObjectiveController CreateObjective(UIObjectiveListController uiObjectiveListController, EncounterObjective objective)
        {
            UIObjectiveController uiObjective = Instantiate(UIFactory.Instance.objectivePrefab);
            uiObjective.transform.SetParent(uiObjectiveListController.transform);

            uiObjective.objective = objective;

            return uiObjective;
        }

        internal static UITrophyController CreateTrophy(TrophySheet trophy, Transform parent)
        {
            UITrophyController uiTrophy = Instantiate(UIFactory.Instance.objectiveTrophyPrefab, parent);

            uiTrophy.tooltip = trophy;

            return uiTrophy;
        }

        internal static UISkillIcon CreateSkillIcon(ITooltip tooltip, string resource_cost, int index, UISkillContainer uISkillBar)
        {
            UISkillIcon skillIcon = Instantiate(UIFactory.Instance.skillIconPrefab);
            skillIcon.transform.SetParent(uISkillBar.transform);

            skillIcon.tooltip = tooltip;
            skillIcon.resourceCost = resource_cost;
            skillIcon.index = index;

            return skillIcon;
        }

        internal static UITokenController Create(int x, int y, TokenType type, UIBoardController board)
        {
            UITokenController tokenController = Instantiate(UIFactory.Instance.tokenControllerPrefab);

            tokenController.transform.SetParent(board.transform);
            tokenController.board = board;
            board.SetPosition(tokenController, x, y);
            tokenController.SetType(type);

            return tokenController;
        }

        internal static UIResourceBarController CreateResourceBar(UIObjectiveController controller, TokenType field, int min, int max)
        {
            UIResourceBarController resourceBar = Instantiate(UIFactory.Instance.resourceBarPrefab);

            resourceBar.transform.SetParent(controller.transform);
            resourceBar.field = field;
            resourceBar.SetRange(min, max);

            return resourceBar;
        }

        internal static UIBuffIcon Create(ITooltip buff, UIBuffContainer uiBuffContainer)
        {
            UIBuffIcon icon = Instantiate(UIFactory.Instance.uiBuffIconPrefab);

            icon.transform.SetParent(uiBuffContainer.transform);
            icon.tooltip = buff;

            return icon;
        }

        private void Awake()
        {
            UIFactory.Instance = this;
        }
    }
}
