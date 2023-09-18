using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class StartScenePresenter : MonoBehaviour
{
    private StartSceneModel startSceneModel;

    [SerializeField]
    private StartSceneView startSceneView;

    async void Start()
    {
        startSceneModel = new StartSceneModel();
        await startSceneModel.Load();

        await AudioManager.Instance.AudioLoad();
        await startSceneView.SetStartButtonImage();
        AudioManager.Instance.PlayBGM(AudioManager.BGMTypes.Start);
        startSceneView.SetStartButton(() => LoadSceneUtility.Instance.StartLoadScene(LoadSceneUtility.SceneTypes.InGameScene));
    }

}
