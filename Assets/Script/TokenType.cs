using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TokenType : int
{
    NULL           = -1,
    STRENGTH       = 0,
    AGILITY        = 1,
    INTELLIGENCE   = 2,
    CHARISMA       = 3,
    LUCK           = 4,
    BLANK          = 5,
    TURN           = 6
}

public static class TokenTypeHelper
{
    public static int ResourceCount() { return 5; }
    public static int Count() { return 7; }

    public static TokenType RandomResource()
    {
        return (TokenType) UnityEngine.Random.Range(0, ResourceCount());
    }

    public static TokenType[] AllResource()
    {
        return new TokenType[] { TokenType.STRENGTH, TokenType.AGILITY, TokenType.INTELLIGENCE, TokenType.CHARISMA, TokenType.LUCK };
    }
}

public static class TokenTypeExtensions
{

    public static string GetSpritePath(this TokenType token)
    {
        switch (token)
        {
            case TokenType.STRENGTH:
                return "tokens/str";
            case TokenType.AGILITY:
                return "tokens/agi";
            case TokenType.INTELLIGENCE:
                return "tokens/int";
            case TokenType.CHARISMA:
                return "tokens/cha";
            case TokenType.LUCK:
                return "tokens/luk";
            case TokenType.BLANK:
                return "tokens/blank";
            case TokenType.TURN:
                return "tokens/turn";
            default:
                throw new ArgumentException("Token type of " + token + " not recognized.");
        }
    }

    public static Sprite GetSprite(this TokenType token)
    {
        return Resources.Load<Sprite>(token.GetSpritePath());
    }

    public static string AsStr(this TokenType token)
    {
        switch (token)
        {
            case TokenType.STRENGTH:
                return "S";
            case TokenType.AGILITY:
                return "A";
            case TokenType.INTELLIGENCE:
                return "I";
            case TokenType.CHARISMA:
                return "C";
            case TokenType.LUCK:
                return "L";
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
        return 99;
    }

    public static bool IsInRange(this TokenType token, int amount)
    {
        return amount >= token.MinValue() && amount <= token.MaxValue();
    }
}