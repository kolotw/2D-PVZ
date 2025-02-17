using UnityEngine;
using System.Collections;

public class 佈署 : MonoBehaviour {
	public GameObject myPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
		if(hit.collider != null && hit.collider.tag == "roadPos"){
			if(Input.GetKeyUp(KeyCode.Mouse0)){
				GameObject myP;
				myP = Instantiate(myPlayer,hit.collider.transform.position,Quaternion.identity) as GameObject;
			}
		}
	}
}
