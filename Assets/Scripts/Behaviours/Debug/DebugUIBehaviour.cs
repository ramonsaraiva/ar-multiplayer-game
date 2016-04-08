using UnityEngine;
using UnityEngine.UI;

public class DebugUIBehaviour : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;

    public Text networkStatus;
    public Text networkLatency;

    public void NetworkStatus(string status)
    {
        networkStatus.text = status;
    }

    public void NetworkLatency()
    {
        networkLatency.text = PhotonNetwork.GetPing() + "ms";
    }

    public void StartGame()
    {
        levelManager.StartGame();
    }
}
