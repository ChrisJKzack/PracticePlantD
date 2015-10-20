using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 150;
	private float shotTimer = Random.Range(.5f,3);
	public GameObject laserPrefab;
	public float projectileSpeed;

	public float shotsPerSecond = 0.5f;

	public int scoreValue = 150;

	public AudioClip laserSound;
	public AudioClip deathSound;

	private ScoreKeeper scoreKeeper;
	// Use this for initialization
	void Start () 
	{
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	float probability = Time.deltaTime * shotsPerSecond;

	if (Random.value < probability) 
		{
			Fire ();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Projectile missle = other.gameObject.GetComponent<Projectile>();
		if (missle) 
		{
			health -= missle.GetDamage();
			missle.Hit();

			if(health <=0)
			{
				scoreKeeper.AddAndUpdateScore(scoreValue);
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				Destroy(gameObject);
			}
		}
	}

	void Fire()
	{
		GameObject laser = Instantiate(laserPrefab,transform.position + new Vector3 (0,-1,0),Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-projectileSpeed,0);
		AudioSource.PlayClipAtPoint(laserSound, transform.position);
	}
}
