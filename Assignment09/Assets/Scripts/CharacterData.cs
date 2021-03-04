using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name;
    public int age;

    public CharacterData()
    {
        this.name = "";
        this.age = 1;
    }
}
