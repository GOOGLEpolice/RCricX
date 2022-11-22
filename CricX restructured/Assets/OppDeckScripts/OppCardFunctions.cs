using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Goes on individual cards. Used for Subscribing and un subscribing Deck events 

public class OppCardFunctions : MonoBehaviour
{
    bool Add;
    bool Remove;
    public GameObject AddButton;
    public GameObject RemoveButton;
    SlotsManager slotsManager;

    public int opId;
    private void Start()
    {
        OppDeckEventManager.instance.onAddButtonPress += AddToDeck;
        OppDeckEventManager.instance.onRemoveButtonPress += RemoveFromDeck;
        RemoveButton.SetActive(false);
    }

    private void Update()
    {
        DeckFull();
    }

    public void AddToDeck(int opId)
    {  
        if(opId == this.opId)
        {
            OppDeckEventManager.instance.opponentDeck1.Add(gameObject);
           
            
            AddButton.SetActive(false);
            Add = false;

            if (Add == false)
            {
                RemoveButton.SetActive(true);
            }

            else if (Add == true)
            {
                RemoveButton.SetActive(false);
            }


            foreach (Transform slots in OppDeckEventManager.instance.DeckSlots)
            {
                for (int i = 0; i < OppDeckEventManager.instance.opponentDeck1.Count; i++)
                {
                    if (OppDeckEventManager.instance.DeckSlots[i].gameObject.GetComponent<OppSlotsManager>().childCard != null)
                    {
                        i++;                        
                    }
                    if (OppDeckEventManager.instance.DeckSlots[i].gameObject.GetComponent<OppSlotsManager>().childCard == null)
                    {
                        gameObject.transform.SetParent(OppDeckEventManager.instance.DeckSlots[i]);
                        gameObject.transform.localPosition = Vector3.zero;
                    }
                }
                
            }
            
        }
    }
    public void RemoveFromDeck(int opId)
    {
        if (opId == this.opId)
        {
            OppDeckEventManager.instance.opponentDeck1.Remove(gameObject);
            RemoveButton.SetActive(false);
            Remove = false;

            if (Remove == false)
            {
                AddButton.SetActive(true);
            }

            else if (Remove == true)
            {
                AddButton.SetActive(false);
            }


            gameObject.GetComponentInParent<OppSlotsManager>().childCard = null;
            

            gameObject.transform.SetParent(OppDeckEventManager.instance.SpawnSlots[opId]);
            gameObject.transform.localPosition = Vector3.zero;
            
        }   
    }

    public void DeckFull()
    {
        bool deckTFull = false;

        if (OppDeckEventManager.instance.opponentDeck1.Count == 11 && deckTFull == false)
        {
            deckTFull = true;
            AddButton.SetActive(false);
        }

        else
        {
            deckTFull = false;
            AddButton.SetActive(true);
        }
    }
    
}
