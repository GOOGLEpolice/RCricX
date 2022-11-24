using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppSlotsManager : MonoBehaviour
{
    public GameObject childCard;

    void Start()
    {
        
    }

    
    void Update()
    {
        FindCards();
    }

    public void FindCards()
    {
        childCard = GetComponentInChildren<OppCardFunctions>().gameObject;
    }
}
