using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 1*Time.deltaTime*10f,0);        
    }
}
