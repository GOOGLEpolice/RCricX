using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCards", menuName = "PlayerCards/PlayerObjects")]
public class PlayerStats : ScriptableObject
{
    public GameObject PlayerCards;
    public string PlayerType;
    public int playerBC;
    public int ball1;
    public int ball2;
    public int ball3;
    public int ball4;
    public int ball5;
    public int ball6;
}
