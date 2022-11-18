using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class addCardIcon : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, 2f).SetEase(Ease.OutBounce);
    }
}
