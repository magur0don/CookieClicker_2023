using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CookieClickerButton : Button
{
    private RectTransform rectTransform => GetComponent<RectTransform>();
    
        [SerializeField]
    public AudioManager.SETypes SEType;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        //rectTransform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), 1f);
        rectTransform.DOShakePosition(
    duration: 1f,   // 演出時間
    strength: 5.5f  // シェイクの強さ
);
        //rectTransform.DOScale(new Vector3(1.2f, 1.2f, 1f),0.5f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        // rectTransform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), 1f);
        //rectTransform.DOScale(new Vector3(1f, 1, 1f), 0.5f);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySE(SEType);
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(CookieClickerButton))]
    public class CustomButtonEditor : UnityEditor.UI.ButtonEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var component = (CookieClickerButton)target;
            component.SEType =
                (AudioManager.SETypes)EditorGUILayout.EnumPopup("SEType", component.SEType);
        }
    }
#endif
}
