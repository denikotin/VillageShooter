using Assets.Scripts.Infrastructure.Services.ProgressServiceFolder;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.SaveLoadServiceFolder
{
    public class SaveLoadService:IService
    {
        private readonly ProgressService _progressService;

        public SaveLoadService(ProgressService progressService) 
        {
            _progressService = progressService;
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(_progressService.GetProgress());
            //PlayerPrefs.SetString("Saves", json);
            Yandex.instance.Save(json);

        }

        public PlayerProgress Load()
        {
            //string saves =  PlayerPrefs.GetString("Saves");
            string saves = Yandex.instance.Load();
            return JsonUtility.FromJson<PlayerProgress>(saves);
        }
    }
}
