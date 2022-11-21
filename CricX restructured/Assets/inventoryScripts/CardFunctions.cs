using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//Goes on individual cards. Used for Subscribing and un subscribing Deck events 

public class CardFunctions : MonoBehaviour
{
    bool Add;
    bool Remove;
    public GameObject AddButton;
    public GameObject RemoveButton;
    SlotsManager slotsManager;

    public int id;
    private void Start()
    {
        DeckEventManager.instance.onAddButtonPress += AddToDeck;
        DeckEventManager.instance.onRemoveButtonPress += RemoveFromDeck;
        RemoveButton.SetActive(false);
    }

    private void Update()
    {
        DeckFull();
    }

    public void AddToDeck(int id)
    {  
        if(id == this.id)
        {
            DeckEventManager.instance.DeckT.Add(gameObject);
            
            
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


            foreach (Transform slots in DeckEventManager.instance.DeckSlots)
            {
                for (int i = 0; i < DeckEventManager.instance.DeckT.Count; i++)
                {
                    if (DeckEventManager.instance.DeckSlots[i].gameObject.GetComponent<SlotsManager>().childCard != null)
                    {
                        i++;                        
                    }
                    if (DeckEventManager.instance.DeckSlots[i].gameObject.GetComponent<SlotsManager>().childCard == null)
                    {
                        gameObject.transform.SetParent(DeckEventManager.instance.DeckSlots[i]);
                        gameObject.transform.localPosition = Vector3.zero;
                    }
                }
                
            }
            
        }
    }
    public void RemoveFromDeck(int id)
    {
        if (id == this.id)
        {
            DeckEventManager.instance.DeckT.Remove(gameObject);
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


            gameObject.GetComponentInParent<SlotsManager>().childCard = null;
            

            gameObject.transform.SetParent(DeckEventManager.instance.SpawnSlots[id]);
            gameObject.transform.localPosition = Vector3.zero;
            
        }   
    }

    public void DeckFull()
    {
        bool deckTFull;

        if (DeckEventManager.instance.DeckT.Count == 11)
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
