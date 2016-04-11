using UnityEngine;
using System.Collections;

public class AboveGroundBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform arena;

    Vector3 fixedPosition;

    private void Awake()
    {
        fixedPosition = new Vector3(transform.position.x, arena.position.y, transform.position.z);
    }

    private void Update()
    {
        fixedPosition.Set(transform.position.x, arena.position.y, transform.position.z);
        transform.position = fixedPosition;
    }
}
