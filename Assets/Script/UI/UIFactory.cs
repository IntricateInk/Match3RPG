using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter;
using System;
using Match3.Encounter.Encounter;
using Match3.Character;
using Match3.Encounter.Effect.Skill;
using Match3.Encounter.Effect.Passive;

namespace Match3.UI
{
    public class UIFactory : MonoBehaviour
    {

        private static UIFactory Instance;
        
        [SerializeField]
        private UITokenController tokenControllerPrefab;

        [SerializeField]
        private UITileController tileControllerPrefab;

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

        [SerializeField]
        private UIFloatingText floatingTextPrefab;

        [SerializeField]
        private Canvas canvas;

        internal static UIFloatingText CreateFloatingText(string text, Vector3 position, UIBoardController board)
        {
            UIFloatingText floating_text = Instantiate<UIFloatingText>(UIFactory.Instance.floatingTextPrefab, board.transform);

            floating_text.transform.position = position;
            floating_text.text = text;

            return floating_text;
        }

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
        
        internal static UISkillIcon CreateSkillIcon(GameSkill skill, int index, UISkillContainer uISkillBar)
        {
            UISkillIcon skillIcon = Instantiate(UIFactory.Instance.skillIconPrefab);
            skillIcon.transform.SetParent(uISkillBar.transform);

            skillIcon.skill = skill;
            skillIcon.energyCost = skill.energyCost.ToString();
            skillIcon.index = index;

            return skillIcon;
        }

        internal static UITileController CreateTile(int x, int y, UIBoardController board)
        {
            UITileController tileController = Instantiate(UIFactory.Instance.tileControllerPrefab, board.transform);

            tileController.board = board;
            tileController.transform.position = board.GetPosition(x, y);

            return tileController;
        }

        internal static UITokenController CreateToken(int x, int y, TokenState token, UIBoardController board)
        {
            UITokenController tokenController = Instantiate(UIFactory.Instance.tokenControllerPrefab);

            board.SetLayer(tokenController.transform, 0);
            tokenController.board = board;
            board.SetPosition(tokenController, x, y);
            tokenController.uid = token.uid;
            tokenController.SetType(token.type);

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

        internal static UIBuffIcon CreateTargetBuffIcon(TargetPassive buff, UIBuffContainer uiBuffContainer)
        {
            UIBuffIcon icon = Instantiate(UIFactory.Instance.uiBuffIconPrefab);

            icon.transform.SetParent(uiBuffContainer.transform);
            icon.target_buff = buff;

            return icon;
        }

        internal static UIBuffIcon CreateCharBuffIcon(CharacterPassive buff, UIBuffContainer uiBuffContainer)
        {
            UIBuffIcon icon = Instantiate(UIFactory.Instance.uiBuffIconPrefab);

            icon.transform.SetParent(uiBuffContainer.transform);
            icon.buff = buff;

            return icon;
        }

        private void Awake()
        {
            UIFactory.Instance = this;
        }
    }
}
