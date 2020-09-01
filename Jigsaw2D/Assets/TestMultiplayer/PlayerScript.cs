using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace TestMultiplayer
{
    public class PlayerScript :MonoBehaviourPunCallbacks
    {
        public static GameObject localPlayer;
        // Start is called before the first frame update
        void Start()
        {
            localPlayer = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime, 0, 0);
            }
        }
    }
}
