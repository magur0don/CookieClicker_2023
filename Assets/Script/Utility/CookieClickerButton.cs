using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class CookieClickerButton : Button
{
    private RectTransform rectTransform => GetComponent<RectTransform>();

    public override void OnPointerEnter(PointerEventData eventData)
    {
        //rectTransform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), 1f);
        rectTransform.DOShakePosition(
    duration: 1f,   // ���o����
    strength: 5.5f  // �V�F�C�N�̋���
);
        //rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f),0.5f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // rectTransform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), 1f);
        //rectTransform.DOScale(new Vector3(1f, 1, 1f), 0.5f);
    }
}
