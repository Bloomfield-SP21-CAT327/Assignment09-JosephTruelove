using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]    
public class GameData
{
    public static GameData current;
    public CharacterData knight;
    public CharacterData rogue;
    public CharacterData wizard;

    public GameData()
    {
        knight = new CharacterData();
        rogue = new CharacterData();
        wizard = new CharacterData();
    }
}
