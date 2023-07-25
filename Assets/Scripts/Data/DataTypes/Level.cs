using System;

namespace Assets.Scripts.Data.DataTypes
{
    [Serializable]
    public class Level
    {
        public int LevelNumber;
        public bool IsOpen;
        public bool IsCompleted;

        public Level(int levelNumber, bool isOpen, bool isCompleted)
        {
            LevelNumber = levelNumber;
            IsOpen = isOpen;
            IsCompleted = isCompleted;
        }
    }
}
