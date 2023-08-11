using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 表示に関することはこのクラスに集約する
/// </summary>
public class CookieClickerView : MonoBehaviour
{
    public TextMeshProUGUI cookieCountText;
    public Button clickButton;

    public void UpdateCookieCount(int count)
    {
        cookieCountText.text = "Cookies: " + count.ToString();
    }

    public void SetClickButtonAction(System.Action onClick)
    {
        clickButton.onClick.AddListener(() => onClick.Invoke());
    }

    public void SetButtonImage(Sprite cookieSprite)
    {
        clickButton.image.sprite = cookieSprite;
    }
}
