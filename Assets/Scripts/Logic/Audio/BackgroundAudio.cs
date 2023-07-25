using UnityEngine;
using UnityEngine.Audio;
using Assets.Scripts.Data.DataTypes;
using Assets.Scripts.Infrastructure.Services.ProgressServiceFolder;

public class BackgroundAudio : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] AudioSource _music;
    [SerializeField] AudioSource _sound;

    private AudioLevelData _audioLevelData; 

    public void Construct(ProgressService progressService)
    {
        _audioLevelData = progressService.GetAudioData();
        SetSoundVolume(_audioLevelData.Sound);
        SetMusicVolume(_audioLevelData.Music);
        Yandex.instance.OnAdvOpenEvent += SwitchOffMusic;
        Yandex.instance.OnAdvCloseEvent += SwitchOnMusic;
    }


    public AudioSource GetMusic() => _music;
    public AudioSource GetSound() => _sound;

    public void SetMusic(AudioClip audioClip) => _music.clip = audioClip;
    public void PlaySound(AudioClip audioClip) => _sound.PlayOneShot(audioClip);

    public void SetSoundVolume(float value) => _mixer.SetFloat("Sound", value);
    public void SetMusicVolume(float value)
    {
        _audioLevelData.Music = value;
        _mixer.SetFloat("Music", value);
    }

    private void SwitchOffMusic()
    {
        _mixer.SetFloat("Master", -80);
    }

    private void SwitchOnMusic()
    {
        _mixer.SetFloat("Master", 0);
    }
}
