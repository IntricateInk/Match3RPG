using Match3.Encounter;
using Match3.Encounter.Effect.Passive;
using System;
using UnityEngine;

namespace Match3.UI.Animation {

    public abstract class IPosition {
        internal abstract Vector3 GetPosition(UIAnimationManager manager);

        #region STATIC_CONSTANTS

        private class UIResourcePosition : IPosition
        {
            public UIResourcePosition(TokenType type)
            {
                this.type = type;
            }

            private readonly TokenType type;

            internal override Vector3 GetPosition(UIAnimationManager manager)
            {
                return manager.player.GetResourcePosition(type);
            }
        }

        public static IPosition STR_TOKEN = new UIResourcePosition(TokenType.STRENGTH);
        public static IPosition AGI_TOKEN = new UIResourcePosition(TokenType.AGILITY);
        public static IPosition INT_TOKEN = new UIResourcePosition(TokenType.INTELLIGENCE);
        public static IPosition CHA_TOKEN = new UIResourcePosition(TokenType.CHARISMA);
        public static IPosition LUK_TOKEN = new UIResourcePosition(TokenType.LUCK);
        

        #endregion STATIC_CONSTANTS
    }

    public class UIBuffPosition : IPosition
    {
        public UIBuffPosition(TargetPassive passive)
        {
            this.passive = passive;
        }

        public UIBuffPosition(CharacterPassive passive)
        {
            this.charPassive = passive;
        }

        private readonly TargetPassive passive = null;
        private readonly CharacterPassive charPassive = null;

        internal override Vector3 GetPosition(UIAnimationManager manager)
        {
            if (passive != null)
            {
                return manager.buffContainer.GetBuffPosition(passive);
            } else
            {
                return manager.buffContainer.GetBuffPosition(charPassive);
            }
        }
    }

    public class UITokenPosition : IPosition
    {
        public UITokenPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private readonly int x, y;

        internal override Vector3 GetPosition(UIAnimationManager manager)
        {
            return manager.board.tiles[x, y].transform.position;
        }
    }

    public static class IPositionExtensions
    {
        public static IPosition AsIPosition(this TokenState token) { return new UITokenPosition(token.x, token.y); }
        public static IPosition AsIPosition(this TileState tile)   { return new UITokenPosition(tile.x, tile.y); }

        public static IPosition AsIPosition(this TargetPassive passive) { return new UIBuffPosition(passive); }
        public static IPosition AsIPosition(this CharacterPassive passive) { return new UIBuffPosition(passive); }
        public static IPosition AsIPosition(this BasePassive passive)
        {
            if (passive is TargetPassive)
                return ((TargetPassive)passive).AsIPosition();
            else if (passive is CharacterPassive)
                return ((CharacterPassive)passive).AsIPosition();

            throw new ArgumentException("Passive is neither character nor target passive.");
        }

        public static IPosition AsIPosition(this TokenType type)
        {
            switch (type)
            {
                case TokenType.STRENGTH:
                    return IPosition.STR_TOKEN;

                case TokenType.AGILITY:
                    return IPosition.AGI_TOKEN;

                case TokenType.INTELLIGENCE:
                    return IPosition.INT_TOKEN;

                case TokenType.CHARISMA:
                    return IPosition.CHA_TOKEN;

                case TokenType.LUCK:
                    return IPosition.LUK_TOKEN;
            }

            throw new ArgumentException("Invalid token.");
        }
    }
}