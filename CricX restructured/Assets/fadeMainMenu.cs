using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class fadeMainMenu : MonoBehaviour
{
    public CanvasGroup logo;
    public CanvasGroup buttons;
    private void OnEnable()
    {
        logo.alpha=0;
        logo.DOFade(1, 3f);

        buttons.alpha = 0;
        buttons.DOFade(1, 6f);
    }
}
