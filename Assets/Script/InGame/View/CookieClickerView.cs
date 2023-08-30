
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
/// <summary>
/// 表示に関することはこのクラスに集約する
/// </summary>
public class CookieClickerView : MonoBehaviour
{
    public TextMeshProUGUI cookieCountText;
    public Button clickButton;
    public InputActionReference ClickReference;
    public void UpdateCookieCount(int count)
    {
        cookieCountText.text = "Cookies: " + count.ToString();
    }

    public void SetClickButtonAction(System.Action onClick)
    {
        clickButton.onClick.AddListener(() =>
        {
            ClickReference.action.performed += context => onClick.Invoke();
        });
    }

    public void SetButtonImage(Sprite cookieSprite)
    {
        clickButton.image.sprite = cookieSprite;
    }
}
