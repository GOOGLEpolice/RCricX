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
<<<<<<< HEAD
    bool deckTFull;

=======
>>>>>>> parent of 7ccd89b (created prefabs)

    //DeckSlotBools False = slot empty

    /*bool DSB1 = false;
    bool DSB2 = false;
    bool DSB3 = false;
    bool DSB4 = false;
    bool DSB5 = false;
    bool DSB6 = false;
    bool DSB7 = false;
    bool DSB8 = false;*/

    //CollectionSlotBools False = Slot empty

    /*bool CSB1;
    bool CSB2;
    bool CSB3;
    bool CSB4;
    bool CSB5;
    bool CSB6;
    bool CSB7;
    bool CSB8;
    bool CSB9;
    bool CSB10;*/

<<<<<<< HEAD

=======
>>>>>>> parent of 7ccd89b (created prefabs)

    public int id;
    private void Start()
    {
        DeckEventManager.instance.onAddButtonPress += AddToDeck;
        DeckEventManager.instance.onRemoveButtonPress += RemoveFromDeck;
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

            for (int i = 0; i < DeckEventManager.instance.DeckT.Count; i++)
            {
                gameObject.transform.SetParent(DeckEventManager.instance.DeckSlots[i]);
                gameObject.transform.localPosition = Vector3.zero;
                //gameObject[i+1].
                // gameObject.transform.DOMove(Vector3.zero);
<<<<<<< HEAD
=======

>>>>>>> parent of 7ccd89b (created prefabs)
            }

        }

       

       /* for (int i = 0; i <= DeckEventManager.instance.DeckSlots.Count; i++)
        {
            Debug.Log(i);
            *//*for (int j = 0; j < DeckEventManager.instance.DeckT.Count; j++)
            {
                DeckEventManager.instance.DeckT[j].transform.SetParent(DeckEventManager.instance.SpawnSlots[j]);
                DeckEventManager.instance.DeckT[j].transform.localPosition = Vector3.zero;
                //DeckEventManager.instance.DeckT[j].transform.localPosition = CardFunctions.startPos;
            }*//*
        }*/

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

<<<<<<< HEAD
            gameObject.transform.SetParent(DeckEventManager.instance.SpawnSlots[id]);
=======
            gameObject.transform.SetParent(DeckEventManager.instance.SpawnSlots[id-1]);
>>>>>>> parent of 7ccd89b (created prefabs)
            gameObject.transform.localPosition = Vector3.zero;



        //    // for (int i = 0; i <= DeckEventManager.instance.DeckT.Count; i++)
        //     for (int i = 0; i <= DeckEventManager.instance.DeckT.Count;)
        //     // {
        //     //     gameObject.transform.SetParent(DeckEventManager.instance.SpawnSlots[id]);
        //     //     gameObject.transform.localPosition = Vector3.zero;
        //     //     i++;

        //     // }



            /*for (int i = 0; i < DeckEventManager.instance.DeckT.Count; i++)
             {

                 for (int j = 0; j < DeckEventManager.instance.SpawnSlots.Count;j++)
                 {
                     DeckEventManager.instance.DeckT[i].transform.SetParent(DeckEventManager.instance.SpawnSlots[i].transform);
                     DeckEventManager.instance.DeckT[i].transform.localPosition = Vector3.zero;
                    // DeckEventManager.instance.DeckT[j].transform.localPosition = CardFunctions.startPos;
                 }
             }*/


        }   
    }

<<<<<<< HEAD
    public void DeckFull()
    {

        if (DeckEventManager.instance.DeckT.Count == 11)
        {
            deckTFull = true;
            AddButton.SetActive(false);
        }

     /*   if(deckTFull == true)
        {
            AddButton.SetActive(false);
        }*/

        else
        {
            deckTFull = false;
            AddButton.SetActive(true);
        }
    }

=======
>>>>>>> parent of 7ccd89b (created prefabs)
    // public void SortCardsByName(int id)
    // {
    //     DeckEventManager.instance.DeckT
    // }
}
