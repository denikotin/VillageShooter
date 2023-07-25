using UnityEngine;

public class MeshCombineScript : MonoBehaviour
{
    private void Awake()
    {
        StaticBatchingUtility.Combine(this.gameObject);
    }

}
