using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{

    [SerializeField]
    private AudioSource[] AudioSources = new AudioSource[3];

    private List<AudioClip> SEAudioClips = new List<AudioClip>();

    private List<AudioClip> BGMAudioClips = new List<AudioClip>();


    public enum AudioSourceTypes
    {
        Invalide = -1,
        BGM,
        SE_Primaly,
        SE_Secondary
    }

    public enum SETypes
    {
        Invalide = -1,
        Click,
        OK,
        Fail
    }
    public enum BGMTypes
    {
        Invalide = -1,
        Start,
        InGame,
    }

    public override void Awake()
    {
        var audioSources = this.GetComponentsInChildren<AudioSource>();
        // AudioSourcesを追加
        for (int i = 0; i < audioSources.Length; i++)
        {
            AudioSources[i] = audioSources[i];
        }
        DontDestroyOnLoad(this);
    }

    public async UniTask AudioLoad()
    {
        await AddressableAssetLoadUtility.Instance.LoadAudioAssetsAsync("SE");
        SEAudioClips.AddRange(AddressableAssetLoadUtility.Instance.AudioClips);

        await AddressableAssetLoadUtility.Instance.LoadAudioAssetsAsync("BGM");
        BGMAudioClips.AddRange(AddressableAssetLoadUtility.Instance.AudioClips);
    }

    public void PlayBGM(BGMTypes bgmType)
    {
        AudioSources[(int)AudioSourceTypes.BGM].clip = BGMAudioClips[(int)bgmType];
        AudioSources[(int)AudioSourceTypes.BGM].Play();
    }

    public void PlaySE(SETypes seType)
    {
        var se = SEAudioClips.Find(clip => clip.name == seType.ToString());

        if (se == null)
        {
            Debug.LogError("指定されたSEはありません");
            return;
        }

        if (!AudioSources[(int)AudioSourceTypes.SE_Primaly].isPlaying)
        {
            AudioSources[(int)AudioSourceTypes.SE_Primaly].clip = se;
            AudioSources[(int)AudioSourceTypes.SE_Primaly].Play();
            return;
        }
        // SE_Primalyは再生中なのでSE_Secondaryで再生する
        if (!AudioSources[(int)AudioSourceTypes.SE_Secondary].isPlaying)
        {
            AudioSources[(int)AudioSourceTypes.SE_Secondary].clip = se;
            AudioSources[(int)AudioSourceTypes.SE_Secondary].Play();
            return;
        }
        Debug.LogError("再生できるオーディオ数を超えています");
    }
}
