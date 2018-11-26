using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Isom; 

namespace Isom{


[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]
public class Modular : MonoBehaviour {

	public enum States {idle, run, jump, fight, dash};
	public enum NierSubStates {idle, fire}; 

	public States current_state = States.idle; 
	public NierSubStates current_sub_state = NierSubStates.idle; 


	Vector2 player_direction; 
	Vector2 player_cam_direction; 

	Inputs inputs; 
	Move move; 
	Fight fight; 
	Rigidbody rb; 
	Animator anim; 


	float camera_change_state_cooldown; 

	// Use this for initialization
	void Start () {

		Initialization(); 
		
	}
	
	// Update is called once per frame
	void Update () {


		

		RelativeToMove(); 
		RelativeToFight(); 
		UpdateTimers(); 

		
	}

	void UpdateTimers()
	{
		camera_change_state_cooldown = camera_change_state_cooldown <= 0f ? camera_change_state_cooldown : camera_change_state_cooldown - Time.deltaTime; 
	}

	void RelativeToMove()
	{
		player_direction = inputs.GetDirection(); 
		player_cam_direction = inputs.GetCamDirection(); 

		// if(Input.GetKeyDown(KeyCode.Space))
		// {
		// 	inputs.Dash = true;
		// 	player_direction = transform.right;  
		// }

		move.PlayerMove(player_direction); 

		if(inputs.Dash)
			move.Dash(); 

		if(inputs.Jump)
			move.Jump(); 

		// if(inputs.Shoot)
		// 	fight.Shoot(); 
	}

	void RelativeToFight()
	{
	// 	if(inputs.ChangeState && camera_change_state_cooldown <= 0f)
	// 	{
	// 		fight.ChangeState();
	// 		camera_change_state_cooldown = 0.5f;  
	// 	}

		if(inputs.Hit)
		{
			if(current_state == States.fight)
				fight.Combo();
			else
				fight.Hit();  
		}

	// 	if(inputs.HeavyHit)
	// 	{
	// 		if(current_state == States.fight)
	// 			fight.Hit(); 
	// 		else
	// 			fight.StartHeavyCombo(); 
	// 	}

	// 	fight.ChangeTarget(player_cam_direction.x); 
	}


	// public bool IsNormal()
	// {
	// 	return current_state == States.normal; 
	// }

	// public bool IsFighting()
	// {
	// 	return	current_state == States.fight; 
	// }

	// public bool IsDashing()
	// {
	// 	return current_state == States.dash; 
	// }

	// public bool IsSprinting()
	// {
	// 	return current_state == States.sprint; 
	// }

	// public bool IsImpacted()
	// {
	// 	return current_state == States.impact; 
	// }

	public bool IsFighting()
	{
		return current_state == States.fight; 
	}

	public bool IsIdle()
	{
		return current_state == States.idle; 
	}

	public bool IsRunning()
	{
		return current_state == States.run; 
	}

	public bool IsJumping()
	{
		return current_state == States.jump; 
	}

	public bool IsDashing()
	{
		return current_state == States.dash; 
	}


	// public bool IsDodging()
	// {
	// 	return current_state == States.dodge; 
	// }

	public void InformHit(string info, bool state)
	{

	}

	public void Inform(string info, bool state)
	{
		if(info == "Idle")
		{
			if(state)
			{
				current_state = States.idle; 
				move.EnterIdle(); 
			}
		}

		else if(info == "Run")
		{
			if(state)
			{
				current_state = States.run; 
				move.EnterRun(); 
			}
		}

		else if(info == "Jump")
		{
			if(state)
			{
				current_state = States.jump; 
				move.EnterJump(); 
			}
		}
		else if(info == "Hit")
		{
			if(state)
			{
				current_state = States.fight; 
			}
		}
		else if(info == "Dash")
		{
			if(state)
			{
				current_state = States.dash; 
				move.EnterDash(player_direction); 
			}
		}

	}

	// 	if(info == "Move")
	// 	{
	// 		if(state)
	// 		{
	// 			current_state = States.normal; 
	// 		}
	// 	}

	// 	else if(info == "FightMode")
	// 	{
	// 		if(state)
	// 		{
	// 			current_state = States.fight; 
	// 			move.EnterFight(); 
	// 		}
	// 	}

	// 	else if(info == "Dash")
	// 	{
	// 		if(state)
	// 		{
	// 			current_state = States.dash; 
	// 			move.EnterDash(); 
	// 		}
	// 	}

	// 	else if(info == "Sprint")
	// 	{
	// 		if(state)
	// 			current_state = States.sprint; 
	// 		else
	// 			move.SetWasSprinting(true); 
	// 	}

	// 	else if(info == "Dodge")
	// 	{
	// 		if(state)
	// 		{
	// 			fight.StopEnnemyTime(); 
	// 			current_state = States.dodge; // Makes NierMove push the character transform
	// 			move.EnterDodge(); 
	// 		}
	// 		else
	// 		{
	// 			fight.ResetTime(); 
	// 		}
	// 	}
	// 	else if(info == "Jump")
	// 	{
	// 		if(state)
	// 		{
	// 			move.JumpAction(); 
	// 			move.EnterJump(); 
	// 			current_state = States.jump; 
	// 		}
	// 	}
	// 	else if(info == "Drop")
	// 	{
	// 		if(state)
	// 		{
	// 			move.EnterDrop(); 
	// 			current_state = States.jump; 
	// 		}
	// 	}
	// 	else if(info == "RunStop")
	// 	{
	// 		if(state)
	// 		{
	// 			move.EnterStop(); 
	// 			current_state = States.run_stop; 
	// 		}
	// 	}
	// 	else if(info == "Impact")
	// 	{
	// 		if(state)
	// 		{
	// 			move.EnterImpact(); 
	// 			current_state = States.impact; 
	// 		}
	// 	}
	// 	else if(info == "Landed")
	// 	{
	// 		float a = 0f; 
	// 	}

	// }

	// public bool DodgeInform()
	// {
	// 	if(inputs.Dodge)
	// 		return true; 
	// 	else
	// 		return false; 
	// }

	// public void HitInform(NierHitData data, bool state)
	// {
	// 	fight.Activation(data, state); 
	// 	if(state)
	// 	{
	// 		move.HitImpulsion(data); 
	// 	}
	// 	return; 
	// }

	// public void WeaponInform(string state)
	// {
	// 	fight.GetWeapon(state); 
	// }

	public void ImpactInform(HitData data, Vector3 direction)
	{
		// bool dodge = DodgeInform(); 

		// if(dodge)
		// {
		// 	fight.Dodge(); 
		// }
		// else
		// {
			fight.Impacted(); // triggers impact animation 
			move.ChangeVelocity(direction*data.HitForce);  
		// }
	}


	// // This function is used to shortcut the hitbox activation in the case of a projectile using particles 

	// public void ProjectileImpactInform()
	// {
	// 	bool dodge = DodgeInform(); 
	// 	if(dodge)
	// 	{
	// 		fight.Dodge(); 
	// 	}
	// 	else
	// 	{
	// 		fight.Impacted(); 
	// 	}
	// }

	// public bool Ask(string info)
	// {
	// 	if(info == "Jump")
	// 	{
	// 		return (current_state != States.jump);
	// 	}

	// 	else
	// 		return false; 
	// }

	// public void ComputeDashDirection()
	// {
	// 	move.ComputeDirectionAndAdjustAnim(player_direction); 
	// }

	void Initialization()
	{
		inputs = GetComponent<Inputs>(); 
		move = GetComponent<Move>(); 
		rb = GetComponent<Rigidbody>(); 
		anim = GetComponent<Animator>(); 
		fight = GetComponent<Fight>(); 
	}
}

}