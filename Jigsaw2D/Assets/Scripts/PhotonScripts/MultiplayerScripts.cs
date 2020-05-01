using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerScripts : MonoBehaviour
{
    public static MultiplayerScripts multiplayerSettings;
    public bool delayStart;
    public int maxPlayers;
    public int MenuScene;
    public int multiplayerScene;

    // Start is called before the first frame update
    private void Awake()
    {if(MultiplayerScripts.multiplayerSettings== null)
        {
            MultiplayerScripts.multiplayerSettings = this;
        }
        else
        {
            if(MultiplayerScripts.multiplayerSettings != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
        
    }
}
