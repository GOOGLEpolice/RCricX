using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIReady : MonoBehaviour
{
    public int playerRuns;
    public int oppRuns;

    public TMP_Text pRuns;
    public TMP_Text oRuns;
    // Start is called before the first frame update
   
        [SerializeField]
        public bool IsUIOverride { get; private set; }

        
        
        void Update()
        {
            // It will turn true if hovering any UI Elements
            IsUIOverride = EventSystem.current.IsPointerOverGameObject();

            

            pRuns.text = GameManager.instance.mScore.ToString();
            oRuns.text = oppRuns.ToString();
        }
        void OnDisable()
        {
            IsUIOverride = false;
        }
    
}

