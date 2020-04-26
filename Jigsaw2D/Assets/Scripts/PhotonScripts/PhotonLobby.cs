using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{

    public static PhotonLobby theLobby;
    public GameObject BattleButton;
    public GameObject cancelButton;
    RoomInfo[] rooms;
    private void Awake()
    {
        theLobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Player is connected to master server");
        BattleButton.SetActive(true);
    }
    public void OnBattleButtonClick()
    {
        Debug.Log("Battel Button clicked");
        BattleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }
    public void OnCancelButtonClick()
    {
        Debug.Log("Cancel Button clicked");
        BattleButton.SetActive(true);
        cancelButton.SetActive(false);
        PhotonNetwork.LeaveRoom();

    }
    public override void OnJoinedRoom()
    {
        Debug.Log("We are now in a room");
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join random room. No room available");
        CreateRoom();
        //base.OnJoinRandomFailed(returnCode, message);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a new room. But failed, there must be a room withh same name");
        //base.OnCreateRoomFailed(returnCode, message);
        CreateRoom();
    }
    void CreateRoom()
    {
        Debug.Log("Trying to create a new room");
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room " + randomRoomName, roomOps);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
