using Assets.Scripts.Data.DataTypes;
using System;

[Serializable]
public class PlayerProgress
{
    public AudioLevelData AudioLevel;
    public LevelProgressData LevelProgressData;

    public PlayerProgress(AudioLevel audioLevel, int levelCount)
    {
        AudioLevel = new AudioLevelData(audioLevel);
        LevelProgressData = new LevelProgressData(levelCount);
    }
}
