using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace TestMultiplayer
{
    public class MenuScript : MonoBehaviourPunCallbacks
    {
        bool IsConnecting;
        public void PlayButton()
        {
            IsConnecting = true;
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = "1";
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        private void Start()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            if (IsConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            base.OnJoinRandomFailed(returnCode, message);
            PhotonNetwork.CreateRoom(null,new RoomOptions {MaxPlayers=3 });
            IsConnecting = false;
        }
        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
        }
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            PhotonNetwork.LoadLevel(1);
        }
    }
}
