using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {
    
	// Use this for initialization
	void Start ()
    {
        if (GameObject.Find("MusiceManager"))
        {
            GameObject.Find("MusicManager").GetComponent<MusicManager>().ChangeVolume(PlayerPrefManager.GetMasterVolume());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
