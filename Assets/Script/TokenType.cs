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
    TIME           = 5,
    TURN           = 6,
    COUNT          = 7
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
            case TokenType.TURN:
                return Resources.Load<Sprite>("tokens/turn");
            case TokenType.TIME:
                return Resources.Load<Sprite>("tokens/time");
            default:
                throw new ArgumentException("Token type of " + token + " not recognized.");
        }
    }

    public static int AsInt(this TokenType token)
    {
        return (int)token;
    }

    public static int MinValue(this TokenType token)
    {
        return 0;
    }

    public static int MaxValue(this TokenType token)
    {
        if (token == TokenType.TIME) return 300;
        return 99;
    }

    public static bool IsInRange(this TokenType token, int amount)
    {
        return amount >= token.MinValue() && amount <= token.MaxValue();
    }
}