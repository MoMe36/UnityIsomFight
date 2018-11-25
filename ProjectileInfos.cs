using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Isom; 

namespace Isom
{


public class ProjectileInfos : MonoBehaviour {

	public float Speed; 
	public HitData HitInfo; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += transform.forward*Speed*Time.deltaTime; 

	}
}

}
