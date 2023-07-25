using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public class Factory: IService
    {
        public GameObject Create(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject go = Object.Instantiate(prefab);
            return go;
        }

        public GameObject Create(string path, Transform parent)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject go = Object.Instantiate(prefab,parent);
            return go;
        }

        public GameObject Create(string path, Vector3 position)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            GameObject go = Object.Instantiate(prefab, position, Quaternion.identity);
            return go;
        }
    }
}
