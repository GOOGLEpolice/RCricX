using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
[CreateAssetMenu(fileName = "PlayerCard", menuName = "PlayerCard_SO")]

public class Card_SO : ScriptableObject,IComparable<Card_SO>
{   public GameObject cardPrefab;
    public string cardName;
    public int stat1;
    public int stat2;
    public int stat3;
    public int stat4;
    public int stat5;
    public int stat6;

    public int CompareTo(Card_SO other)
    {
        return cardName.CompareTo(other.cardName);
        
    }

}


