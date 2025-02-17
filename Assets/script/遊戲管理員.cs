using UnityEngine;
using System.Collections;

public class 遊戲管理員 : MonoBehaviour {
	public GameObject 敵人A;
	public GameObject 敵人B;
	public Transform 生成點1;
	public Transform 生成點2;
	public Transform 生成點3;
	private Vector3 spawn;
	public int 敵人總數=2;
	public GameObject 勝利圖;
	public GameObject 失敗圖;
	public static bool isOver=false;
	// Use this for initialization
	void Start () {
		InvokeRepeating("生成敵人",1,8);
	}
	
	// Update is called once per frame
	void Update () {
		if(isOver){
			失敗圖.GetComponent<SpriteRenderer>().enabled=true;
		}	
	}

	void 生成敵人(){
		敵人總數--;
		//print(敵人總數);
		if(敵人總數>0){
			選擇生成敵人位置();
			GameObject ne;
			float myRnd = Random.value *33;
			int myI = Mathf.RoundToInt(myRnd) % 2;
			if(myI==0){
				ne = Instantiate(敵人A,spawn,Quaternion.identity)as GameObject;	
			}else{
				ne = Instantiate(敵人B,spawn,Quaternion.identity)as GameObject;
			}
		}else{
			CancelInvoke("生成敵人");
			InvokeRepeating("查看戰場",1,1);
		}
	}
	void 查看戰場(){
		GameObject ene;
		ene = GameObject.FindWithTag("enemy");
		if(ene==null){
			勝利圖.GetComponent<SpriteRenderer>().enabled=true;
		}
	}
	void 選擇生成敵人位置(){
		float rnd = Random.value *38;
		int sPos = Mathf.RoundToInt (rnd) % 3;
		switch(sPos){
			case 0:
				spawn = 生成點1.transform.position;
				break;
			case 1:
				spawn = 生成點2.transform.position;
				break;
			case 2:
				spawn = 生成點3.transform.position;
				break;
			default:
				spawn = 生成點2.transform.position;
				break;
		}
	}
}
