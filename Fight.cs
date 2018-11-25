using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Isom; 

namespace Isom
{



public class Fight : MonoBehaviour {

	// public PodFight pod; 
	// public NierTimeControl TimeManager; 
	// public NierCam camera_control; 
	// public Transform [] Targets; 

	// public WeaponControl weapon_control;
	public Hitbox [] Hitboxes; 

	// public Vector3 CanonOffset; 
	// public GameObject SpellPrefab;
	// public float DestroyTime;  
	

	[Header("Changing target parameters")]
	public float ChangingCooldown = 0.5f; 
	float changing_cooldown; 

	[HideInInspector] public Transform Target;
	int CurrentTargetIndex = 0;  



	Dictionary <string, Hitbox> hitboxes; 
	Dictionary <string, Hitbox> hurtboxes;

	Animator anim; 
	Rigidbody rb; 
	Modular mothership; 	


	// Use this for initialization
	void Start () {
		Initialization(); 
		// FindTargets(); 
	}
	
	// Update is called once per frame
	void Update () {

		UpdateTimers(); 

	}

	void UpdateTimers()
	{
		changing_cooldown = changing_cooldown >= 0f ? changing_cooldown - Time.deltaTime : changing_cooldown; 
	}

	public void SetTrigger(string s)
	{
		anim.SetTrigger(s); 
	}

	public void Hit()
	{
		SetTrigger("Hit"); 
	}

	public void Combo()
	{
		anim.SetBool("Combo", true); 
	}

	public void StartHeavyCombo()
	{
		anim.SetTrigger("StartSwordCombo"); 
		anim.SetBool("Hit", true); 
	}

	// public void GetWeapon(string state)
	// {
	// 	weapon_control.ChangeParent(state); 
	// }

	public void StartCombo()
	{
		anim.SetTrigger("StartCombo"); 
		anim.SetBool("Hit", true); 
	}

	public void Activation(HitData data, bool state)
	{
		hitboxes[data.HitboxName].SetState(data, state); 
	}

	// public void Shoot()
	// {
	// 	pod.Shoot(); 
	// }

	public void Dodge()
	{	
		anim.SetTrigger("Dodge"); 
	}

	public void Impacted()
	{
		anim.SetTrigger("Impact"); 
	}

	// public void StopEnnemyTime()
	// {
	// 	float factor = TimeManager.StopTime(); 
	// 	anim.speed = 1f/factor; 
	// }

	// public void ResetTime()
	// {
	// 	anim.speed = 1f; 
	// 	TimeManager.ResetTime(); 
	// }

	// public void ChangeState()
	// {
	// 	Camera.main.GetComponent<NierCam>().SetNewTarget(Target); 
	// 	Camera.main.GetComponent<NierCam>().ChangeState(); 
	// }

	// public void ChangeTarget(float x)
	// {
	// 	if(Mathf.Abs(x) > 0.5f && changing_cooldown <= 0f)
	// 	{

	// 		Targets = Globals.CleanArray(Targets); 
	// 		if(Targets.Length > 0)
	// 		{
				
	// 			CurrentTargetIndex += (int)(Mathf.Sign(x)); 
	// 			CurrentTargetIndex = CurrentTargetIndex < 0 ? Targets.Length - 1 : CurrentTargetIndex%Targets.Length; 

	// 			Target = Targets[CurrentTargetIndex]; 

	// 			camera_control.SetNewTarget(Target);

	// 		}
			
	// 		changing_cooldown = ChangingCooldown;  
	// 	}
	// }

	void Initialization()
	{
		anim = GetComponent<Animator>(); 
		rb = GetComponent<Rigidbody>(); 
		mothership = GetComponent<Modular>(); 

		// Target = Targets[0]; 
		GlobalUtils.FillAllBoxes(Hitboxes, out hitboxes, out hurtboxes); 
		// hitboxes = Globals.FillHitboxes(Hitboxes); 
	}


	// void FindTargets()
	// {
	// 	NierShortRangeEnnemy [] ennemies = FindObjectsOfType(typeof(NierShortRangeEnnemy)) as NierShortRangeEnnemy []; 
	// 	Transform [] target_placeholder = new Transform [ennemies.Length];
	// 	for(int i = 0; i<ennemies.Length; i++)
	// 	{
	// 		target_placeholder[i] = ennemies[i].gameObject.transform; 
	// 	}

	// 	Targets = target_placeholder;  
	// }


}

}
