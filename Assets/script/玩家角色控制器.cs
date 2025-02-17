using UnityEngine;
using System.Collections;

public class 玩家角色控制器 : MonoBehaviour {
	private Animator anim;
	public GameObject 子彈;
	public Transform 發射點;
	private float myTime=0;
	public int HP = 10;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myTime += 1.0f * Time.deltaTime;
		if(myTime>3){
			偵測敵人();
			myTime=0;
		}


//		if(Input.GetKeyUp(KeyCode.Mouse0)){
//			anim.SetTrigger("attack");
//			Invoke("發射",1.0f);
//		}
//		if(Input.GetKeyUp(KeyCode.Mouse1)){
//			anim.SetTrigger("die");
//		}
	}

	void 發射(){
		GameObject newBullet;
		newBullet = Instantiate(子彈,this.transform.position,Quaternion.identity)as GameObject;
	}

	void 偵測敵人(){
		RaycastHit2D hit = Physics2D.Raycast(發射點.transform.position,Vector2.right,2.8f,1);
		if(hit.collider != null && hit.transform.tag == "enemy"){
			print("hit: " + hit.transform.name);
			anim.SetTrigger("attack");
			Invoke("發射",1.0f);
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "敵人的氣功"){
			HP--;
			if(HP<=0){
				anim.SetTrigger("die");
				Destroy(this.gameObject,1);
			}
		}
	}
}
