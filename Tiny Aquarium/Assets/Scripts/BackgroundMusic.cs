using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    GameObject[] audioPlayers;
    bool notFirst = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //find duplicate audio players and destroy
        audioPlayers = GameObject.FindGameObjectsWithTag("Music");

        foreach(GameObject player in audioPlayers) {
            if(player.scene.buildIndex == -1) {
                notFirst = true;
            }
        }

        if(notFirst) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        GetComponent<AudioSource>().Play();
    }
}
