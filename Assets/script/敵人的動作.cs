using UnityEngine;
using System.Collections;

public class 敵人的動作 : MonoBehaviour {
	private Animator anim;
	public GameObject 敵人的氣功;
	public Transform 敵人的發射點;
	public int HP=5;
	public bool 可發氣功=false;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		InvokeRepeating("攻擊動作",3,5);
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * -8);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.transform.position.x<-3){
			遊戲管理員.isOver=true;
		}
//		if(Input.GetKeyUp(KeyCode.Mouse0)){
//			anim.SetTrigger("attack");
//		}
//		if(Input.GetKeyUp(KeyCode.Mouse1)){
//			anim.SetTrigger("die");
//		}
	}
	void 攻擊動作(){
		anim.SetTrigger("attack");
		if(可發氣功){
			Invoke("發氣功",1);	
		}
	}
	void 發氣功(){
		GameObject eb;
		eb = Instantiate(敵人的氣功,敵人的發射點.transform.position,Quaternion.identity) as GameObject;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "手裡劍"){
			HP--;
			if(HP<=0){
				anim.SetTrigger("die");
				Destroy(this.gameObject,1);
			}
		}
	}
}
