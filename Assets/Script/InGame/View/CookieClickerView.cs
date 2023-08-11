using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 表示に関することはこのクラスに集約する
/// </summary>
public class CookieClickerView : MonoBehaviour
{
    public Text cookieCountText;
    public Button clickButton;

    public void UpdateCookieCount(int count)
    {
        cookieCountText.text = "Cookies: " + count.ToString();
    }

    public void SetClickButtonAction(System.Action onClick)
    {
        clickButton.onClick.AddListener(() => onClick.Invoke());
    }
}
