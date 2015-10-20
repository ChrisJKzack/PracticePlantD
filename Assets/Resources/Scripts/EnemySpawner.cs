using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;

	public float width = 10;
	public float height = 5;

	public float speed = 5;

	Vector3 leftMost;
	Vector3 rightMost;

	public bool right =true;
	public float spawnDelay = 0.5f;

	// Use this for initialization
	void Start () 
	{

		float distance = transform.position.z - Camera.main.transform.position.z;
		
		leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

		SpawnEnemiesToEachPosition ();
		
	}

	public void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (right) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		} else {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		}

		if (right) 
		{
			if ((width/2)+transform.position.x >= rightMost.x)
				right = !right;
		}
		else
		{
			if (transform.position.x - (width/2) <= leftMost.x)
				right = !right;
		}


		if (AllMembersDead ()) {
			SpawnUntilFull();
		}
	
	}

	bool AllMembersDead()
	{
		foreach (Transform childPositionGameObject in transform) 
		{
			if (childPositionGameObject.childCount > 0)
				return false;
		}
		return true;
	}

	Transform NextFreePosition()
	{
		foreach (Transform childPositionGameObject in transform) 
		{
			if (childPositionGameObject.childCount == 0)
				return childPositionGameObject;
		}
		return null;
	}

	void SpawnEnemiesToEachPosition()
	{
		foreach (Transform position in transform) 
		{
			GameObject enemy = Instantiate (enemyPrefab, position.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.SetParent(position);
		}
	}

	void SpawnUntilFull()
	{
		Transform freePosition = NextFreePosition ();

		if (freePosition) 
		{
			GameObject enemy = Instantiate (enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.SetParent (freePosition);
		}

		if(NextFreePosition())
		{
		Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
}
