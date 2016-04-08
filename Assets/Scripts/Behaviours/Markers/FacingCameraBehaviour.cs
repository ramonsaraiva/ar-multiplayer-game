using UnityEngine;
using System.Collections;

public class FacingCameraBehaviour : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }
}
