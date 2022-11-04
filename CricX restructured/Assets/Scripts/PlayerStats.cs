using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity { Common, Uncommon, Rare, VeryRare, Legendary }
public enum PlayerType { Batsman, Bowler }

[CreateAssetMenu(fileName = "PlayerCards", menuName = "PlayerCards/PlayerObjects")]

public class PlayerStats : ScriptableObject
{
    public GameObject PlayerCards;
    public string playerName;
    public PlayerType playerType;
    public  Rarity rarity;
    public int playerBC;
    public int ball1;
    public int ball2;
    public int ball3;
    public int ball4;
    public int ball5;
    public int ball6;
}
