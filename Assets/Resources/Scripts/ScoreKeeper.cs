using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public static float score = 0;

	public void AddAndUpdateScore(float ScoreAmount)
	{	
		score += ScoreAmount;
		UpdateScoreText ();
	}

	public static void Reset()
	{
		score = 0;
	}

	private void UpdateScoreText()
	{
		transform.GetComponent<Text> ().text = "Score :" + score;
	}
}
