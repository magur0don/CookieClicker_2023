using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class StartSceneView : MonoBehaviour
{
    [SerializeField]
    private CookieClickerButton startButton;

    public void SetStartButton(UnityAction onClick)
    {
        startButton.Action = onClick;
    }

    public async UniTask SetStartButtonImage()
    { 
        await AddressableAssetLoadUtility.Instance.LoadSpriteAssetAsync("CookieImage_1");
        startButton.image.sprite = AddressableAssetLoadUtility.Instance.ResultSprite;
    }
}
