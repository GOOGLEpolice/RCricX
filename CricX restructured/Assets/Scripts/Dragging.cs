using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragging : MonoBehaviour
{
    private float dist;
    public static bool drag;
    private Vector3 offset;
    private Transform toDrag;
    //public GameObject objectDragged;
    
    
    void Update()
    {
        Vector3 v3;

        if (Input.touchCount != 1)
        {
            drag = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.tag == "Player") 
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    drag = true;
                    GameManager.instance.playerCardStats = hit.collider.gameObject.GetComponent<CardStats>();
                }

                if (hit.collider.tag == "Enemy")
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    v3 = new Vector3(pos.x, pos.y, dist);
                    v3 = Camera.main.ScreenToWorldPoint(v3);
                    offset = toDrag.position - v3;
                    drag = true;
                    GameManager.instance.opponentCardStats = hit.collider.gameObject.GetComponent<CardStats>();
                }
            }
        }
        if (drag&&touch.phase==TouchPhase.Moved)
        {
            v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            v3 = Camera.main.ScreenToWorldPoint(v3);
            toDrag.position = v3 + offset;
        }

        if(drag&&(touch.phase==TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            drag = false;
            
        }
    }


    public void StopDrag(PointerEventData eventData)
    {
        if (GameManager.instance.playerReady)
        {
            return;
        }
    }
}
