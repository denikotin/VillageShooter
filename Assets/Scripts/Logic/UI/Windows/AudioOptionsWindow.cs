using System;
using UnityEngine.UI;

public class AudioOptionsWindow: WindowBase
{
    public Slider SoundSlider;
    public Slider MusicSlider;
    private BackgroundAudio _backgroundAudio;

    public void Construct(BackgroundAudio backgroundAudio)
    {
        SoundSlider.onValueChanged.AddListener(ChangeSoundVolume);
        MusicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _backgroundAudio = backgroundAudio;
    }

    private void ChangeMusicVolume(float value) => _backgroundAudio.SetMusicVolume(value);
    private void ChangeSoundVolume(float value) => _backgroundAudio.SetSoundVolume(value);
}
