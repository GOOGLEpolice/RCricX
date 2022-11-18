using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fade : MonoBehaviour
{
    public CanvasGroup runcan;
    private void OnEnable()
    {
        runcan.alpha = 0;
        runcan.DOFade(1, 2.5f);
    }
    public void OnEnd()
    {
        runcan.DOFade(0, 5f);
    }
}
