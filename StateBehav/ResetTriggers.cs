using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Isom;

namespace Isom{

public class ResetTriggers : StateMachineBehaviour {

	public string [] Triggers;
	public string [] Bools; 
	public float test;  

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// Call(animator, true); 
		Reset(animator); 
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// Call(animator, false);
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	// override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	// }

	void Reset(Animator animator)
	{
		foreach(string s in Bools)
		{
			animator.SetBool(s, false); 
		}

		foreach(string s in Triggers)
		{
			animator.ResetTrigger(s); 
		}
	}

	void Call(Animator animator, bool state)
	{
		// animator.gameObject.GetComponent<Modular>().InformHit(Information, state);
	}
}

}