using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 1;
	public float padding =.5f;
	public GameObject laserPrefab;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 1000;

	public AudioClip laserSound;

	float xmin;
	float xmax;

	void Start()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.position += Vector3.left * Time.deltaTime * speed;
		}
		else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.position += Vector3.right * Time.deltaTime * speed;
		}

		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);

		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);


		if (Input.GetKeyDown (KeyCode.Space)) 
		{
				InvokeRepeating("Fire",0.000001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
				CancelInvoke("Fire");
		}
	}

	void Fire()
	{
		GameObject laser = Instantiate(laserPrefab,transform.position + new Vector3 (0,1,0),Quaternion.identity) as GameObject;

		AudioSource.PlayClipAtPoint (laserSound, transform.position);

		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed,0);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Projectile missle = other.gameObject.GetComponent<Projectile>();
		if (missle) 
		{
			print ("hit");

			health -= missle.GetDamage();
			missle.Hit();
			
			if(health <=0)
			{
				LevelManager mang = GameObject.Find("LevelManager").GetComponent<LevelManager>();
				mang.LoadLevel("Win Screen");
				Die ();
			}

		}
	}

	void Die()
	{
		Destroy(gameObject);
	}

}
