using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class addCard : MonoBehaviour
{
    public Transform box;
    public CanvasGroup background;
    // Start is called before the first frame update
    public void OnEnable()
    {
        background.alpha = 0;
        background.DOFade(1, 0.5f);

        box.localPosition = new Vector2(0, -Screen.height);
        box.DOLocalMoveY(0, 1f).SetEase(Ease.OutExpo).SetDelay(0.2f);
        //setEaseOutExpo and delay missing;
    }

    public void CloseDialog()
    {
        background.DOFade(0, 0.5f);
        box.DOLocalMoveY(-Screen.height, 0.2f).SetEase(Ease.OutExpo).OnComplete(OnComplete);
        //setEaseInExpo missing
    }
    public void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
