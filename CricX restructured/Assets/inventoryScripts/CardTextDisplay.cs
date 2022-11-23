using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardTextDisplay : MonoBehaviour
{   
    //goes on individual card prefabs. those Prefabs must contain PCard tag on them.

    public Card_SO card_SO;
    public Text nameText;
    
    public Text statText1;
    public Text statText2;
    public Text statText3;
    public Text statText4;
    public Text statText5;
    public Text statText6;
    public static Vector3 startPos;

    public int id;

    
    void Start()
    {
        nameText.text = card_SO.cardName;
        statText1.text = card_SO.stat1.ToString();
        statText2.text = card_SO.stat2.ToString();
        statText3.text = card_SO.stat3.ToString();
        statText4.text = card_SO.stat4.ToString();
        statText5.text = card_SO.stat5.ToString();
        statText6.text = card_SO.stat6.ToString();
        startPos = transform.position;
        Debug.Log(startPos);
    }

    public void OnAddButtonClicked()
    {   
        DeckEventManager.instance.AddButtonPressed(id);
    }

    public void OnRemoveButtonClicked()
    {   
        DeckEventManager.instance.RemoveButtonPressed(id);
    }
}


