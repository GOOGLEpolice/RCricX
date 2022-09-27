using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCards : MonoBehaviour
{

    public List<Vector3> playerCardPositions;

    void Start()
    {
        playerCardPositions = new List<Vector3>();
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject GO in objectsWithTag)
        {
            playerCardPositions.Add(GO.transform.position);
        }
    }

    
    void Update()
    {
        
    }
}
