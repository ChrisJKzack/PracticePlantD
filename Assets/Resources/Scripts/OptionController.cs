using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;

    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start ()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update ()
    {
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefManager.SetDifficulty((int)difficultySlider.value);

        levelManager.LoadLevel("StartMenu");
    }

    public void SetDefaults()
    {
        volumeSlider.value = .8f;
        difficultySlider.value = 2;
        

    }
}
