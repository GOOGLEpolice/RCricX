using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{

    public List<Vector3> playerCardPositions;
    public List<Vector3> opponentCardPositions;
    public bool playerReady;

    void Start()
    {
        playerCardPositions = new List<Vector3>();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject GO in objectsWithTag)
        {
            playerCardPositions.Add(GO.transform.position);
        }

        opponentCardPositions = new List<Vector3>(); 
        GameObject[] enemyobjectsWithTag = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject GO in enemyobjectsWithTag)
        {
            opponentCardPositions.Add(GO.transform.position);
        }
    }

    
    

    
}
