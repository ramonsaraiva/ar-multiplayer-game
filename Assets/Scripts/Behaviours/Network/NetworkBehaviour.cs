using System;
using UnityEngine;

public class NetworkBehaviour : Photon.MonoBehaviour
{
    public bool AutoConnect = true;
    public byte Version = 1;

    public virtual void Start()
    {
        DebugManagerBehaviour.DebugUI.NetworkStatus("Connecting to Master Server..");
        PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
    }

    public virtual void OnConnectedToMaster()
    {
        DebugManagerBehaviour.DebugUI.NetworkStatus("Joining a random room..");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        DebugManagerBehaviour.DebugUI.NetworkStatus("Joining a random room..");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        DebugManagerBehaviour.DebugUI.NetworkStatus("No room available, creating a room..");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 4 }, null);
    }

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {

    }

    public void OnJoinedRoom()
    {
        DebugManagerBehaviour.DebugUI.NetworkStatus("Connected. Players in room: " + PhotonNetwork.playerList.Length);
    }

    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        DebugManagerBehaviour.DebugUI.NetworkStatus("Connected. Players in room: " + PhotonNetwork.playerList.Length);
    }

    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        DebugManagerBehaviour.DebugUI.NetworkStatus("Connected. Players in room: " + PhotonNetwork.playerList.Length);
    }
}
