using UnityEngine;
using System.Collections;

public class 手裡劍 : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		GetComponent<Rigidbody2D>().AddForce(Vector2.right*80);
		Destroy(this.gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "enemy"){
			//print("hit");
			anim.SetTrigger("touch");
			Destroy(this.gameObject,0.8f);
			GetComponent<Rigidbody2D>().AddForce(Vector2.right*-70);
			//GetComponent<Rigidbody2D>().AddForce(Vector2.up*-10);
		}
	}
}
