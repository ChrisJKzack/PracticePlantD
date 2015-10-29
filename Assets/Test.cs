using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(PlayerPrefManager.GetDifficulty());
	}
}
