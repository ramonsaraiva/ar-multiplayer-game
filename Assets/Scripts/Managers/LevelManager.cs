using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform arena;

    [SerializeField]
    private Transform playerStartPosition;

    [SerializeField]
    private SpawnerBehaviour spawner;

    private GameObject player;

    public void StartGame()
    {
        if (PhotonNetwork.isMasterClient)
        {
            player = PhotonNetwork.Instantiate("Player", playerStartPosition.position, Quaternion.identity, 0) as GameObject;
            spawner.enabled = true;
        }
    }

    public void EndGame()
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.DestroyAll();
            spawner.enabled = false;
        }
    }
}
