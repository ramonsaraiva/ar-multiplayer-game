using UnityEngine;

public class BelongsToArenaBehaviour : MonoBehaviour
{
	private void Start ()
    {
        transform.parent = GameObject.FindGameObjectWithTag("Arena").transform;
	}
}
