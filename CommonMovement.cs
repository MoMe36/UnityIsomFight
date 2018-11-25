using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonMovement : MonoBehaviour {

	// // Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }
	public static void FromForwardToVec(Transform t, Vector3 v, out float angle, out Quaternion quat)
	{
		angle = Vector3.SignedAngle(t.forward, v, Vector3.up); 
		quat = Quaternion.AngleAxis(angle, Vector3.up); 
	}

	public static Vector3 CamToPlayerOnPlane(Transform t, Camera cam)
	{
		Vector3 v = Vector3.ProjectOnPlane(t.position - cam.transform.position, Vector3.up); 
		return v.normalized;  
	}

	public static Vector2 DeltaDirectionToCosSin(Transform t, Vector2 v)
	{
		float current_angle = Vector3.SignedAngle(t.forward, v, Vector3.up); 
		current_angle *= Mathf.Deg2Rad; 

		float x = Mathf.Sin(current_angle); 
		float y = Mathf.Cos(current_angle); 

		return new Vector2(x,y);
	}
}
