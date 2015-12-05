using UnityEngine;
using System.Collections;

public class Sonic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(name + "trigger enter");

        GameObject obj = other.gameObject;

        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<Woba>())
        {
            transform.GetComponent<Animator>().SetTrigger("IsAttacking");
        }

    }
}
