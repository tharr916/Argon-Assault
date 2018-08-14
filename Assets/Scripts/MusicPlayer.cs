﻿using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	void Awake()
	{
	    int numMusicPlayers =  FindObjectsOfType<MusicPlayer>().Length;

	    if (numMusicPlayers > 1)
	    {
            Destroy(gameObject);
	    }
	    else
	    {
	        DontDestroyOnLoad(this.gameObject);
        }
		
	}

}
