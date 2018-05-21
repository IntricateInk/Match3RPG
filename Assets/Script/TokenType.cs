using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TokenType : int
{
    STRENGTH       = 0,
    AGILITY        = 1,
    INTELLIGENCE   = 2,
    CHARISMA       = 3,
    LUCK           = 4,
    COUNT          = 5
}

public static class TokenTypeExtensions
{

    public static Sprite GetSprite(this TokenType token)
    {
        switch (token)
        {
            case TokenType.STRENGTH:
                return Resources.Load<Sprite>("tokens/str");
            case TokenType.AGILITY:
                return Resources.Load<Sprite>("tokens/agi");
            case TokenType.INTELLIGENCE:
                return Resources.Load<Sprite>("tokens/int");
            case TokenType.CHARISMA:
                return Resources.Load<Sprite>("tokens/cha");
            case TokenType.LUCK:
                return Resources.Load<Sprite>("tokens/luk");
            default:
                throw new ArgumentException("Token type of " + token + " not recognized.");
        }
    }
}