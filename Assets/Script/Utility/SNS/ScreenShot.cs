using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(Camera))]
public class ScreenShot : MonoBehaviour
{
    string screenShotSavedPath;
    public void TakeScreenShot(string savedPath)
    {
        screenShotSavedPath = savedPath;
    }
    void OnPostRender()
    {
        if (string.IsNullOrEmpty(screenShotSavedPath))
        {
            return;
        }
        float screenShotWidth = Screen.width;
        float screenShotHeight = Screen.height;
        if (screenShotWidth / screenShotHeight < 16f / 9)
        {
            // 縦長端末なので調整
            screenShotHeight = screenShotWidth * (9f / 16);
        }
        else
        {
            // 横長端末なので調整
            screenShotWidth = screenShotHeight * (16f / 9);
        }
        var tempTexture = new Texture2D((int)screenShotWidth, (int)screenShotHeight);
        // 画面の中心を基準に(screenShotWidth, screenShotHeight)の領域を取得
        tempTexture.ReadPixels(
            new Rect(Screen.width / 2f - screenShotWidth / 2f, Screen.height / 2f - screenShotHeight / 2f,
            screenShotWidth, screenShotHeight), 0, 0);
        tempTexture.Apply();

        // 1200*675のRenderTextureにtempTextureを投影
        var renderTexture = RenderTexture.GetTemporary(1200, 675);
        Graphics.Blit(tempTexture, renderTexture);

        // 投影したRenderTextureをアクティブに指定
        var original = RenderTexture.active;
        RenderTexture.active = renderTexture;

        // 投影したRenderTextureから1200*675で読み取り
        var resultTexture = new Texture2D(1200, 675);
        resultTexture.ReadPixels(new Rect(0, 0, 1200, 675), 0, 0);
        resultTexture.Apply();
        RenderTexture.active = original;

        // 保存
        File.WriteAllBytes(screenShotSavedPath, resultTexture.EncodeToPNG());
        screenShotSavedPath = null;

        // 一時的に使ったものの破棄
        RenderTexture.ReleaseTemporary(renderTexture);
        DestroyImmediate(tempTexture);
        DestroyImmediate(resultTexture);
    }
}