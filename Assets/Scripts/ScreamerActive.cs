using UnityEngine;
using System.Collections;

public class ScreamerActive : MonoBehaviour {

	public GameObject screamerScene;

	void  OnTriggerStay(Collider other){
		if(other.tag == "Player");
        screamerScene.active = true; 

	}
}