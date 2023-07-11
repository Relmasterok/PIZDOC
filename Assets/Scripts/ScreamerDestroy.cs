using UnityEngine;
using System.Collections;

public class ScreamerDestroy : MonoBehaviour {

	public GameObject entity;

	void  OnTriggerStay(Collider other){
		if(other.tag == "Player");
        entity.active = false; 
		Destroy(entity); 
	}
}