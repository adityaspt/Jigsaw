using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace TestMultiplayer
{
    public class InstantiatePlayer : MonoBehaviourPunCallbacks
    {

        // Start is called before the first frame update
        void Start()
        {
            if (PlayerScript.localPlayer == null)
            {
                PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
