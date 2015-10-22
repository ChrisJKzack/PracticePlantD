using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float autLoadNextLevelAfter;


    void Start()
    {
        if(autLoadNextLevelAfter != 0)
        Invoke("LoadNextLevel", autLoadNextLevelAfter);
    }

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

}
