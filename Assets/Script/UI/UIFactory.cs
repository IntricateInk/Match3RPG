using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Game;
using System;

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
        private UIObjectiveController objectivePrefab;

        [SerializeField]
        private UITrophyController trophyPrefab;

        internal static UITrophyController Create(ITooltip tooltip, UITrophyListController uiTrophyListController)
        {
            UITrophyController trophy = Instantiate(UIFactory.Instance.trophyPrefab);


            return trophy;
        }

        internal static UIObjectiveController Create(ITooltip tooltip, UIObjectiveListController uiObjectiveListController)
        {
            UIObjectiveController objective = Instantiate(UIFactory.Instance.objectivePrefab);
            objective.transform.SetParent(uiObjectiveListController.transform);

            objective.tooltip = tooltip;

            return objective;
        }


        internal static UISkillIcon Create(ITooltip tooltip, int index, UISkillBar uISkillBar)
        {
            UISkillIcon skillIcon = Instantiate(UIFactory.Instance.skillIconPrefab);
            skillIcon.transform.SetParent(uISkillBar.transform);

            skillIcon.tooltip = tooltip;
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


        private void Awake()
        {
            UIFactory.Instance = this;
        }
    }
}
