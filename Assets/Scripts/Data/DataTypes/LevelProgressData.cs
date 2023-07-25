using System;
using System.Collections.Generic;

namespace Assets.Scripts.Data.DataTypes
{
    [Serializable]
    public class LevelProgressData
    {
        public List<Level> Levels;

        public LevelProgressData(int levelCount)
        {
            Levels = new List<Level>();
            Levels.Add(new Level(1, true, false));

            for(int i = 1; i < levelCount; i++)
            {
                Levels.Add(new Level(i + 1, false, false));
            }
        }
    }
}
