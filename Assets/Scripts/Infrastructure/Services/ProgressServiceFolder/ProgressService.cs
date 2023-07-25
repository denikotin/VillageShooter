using Assets.Scripts.Data.DataTypes;

namespace Assets.Scripts.Infrastructure.Services.ProgressServiceFolder
{
    public class ProgressService: IService
    {
        private PlayerProgress _progress;

        public ProgressService() 
        {

        }

        public PlayerProgress GetProgress() => _progress;
        public AudioLevelData GetAudioData() => _progress.AudioLevel;
        public LevelProgressData GetLevelProgressData() => _progress.LevelProgressData;

        public void SetProgress(PlayerProgress playerProgress)
        {
            if (playerProgress != null)
            {
                _progress = playerProgress;
            }
        }
    }
}
