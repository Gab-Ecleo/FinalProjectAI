using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class ArcherIdleState : StateMachineBehaviour
{
    NewAiBehaviour aiBehaviour;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aiBehaviour = animator.GetComponentInParent<NewAiBehaviour>();
        
        #region will walk after 5 seconds
        //await Task.Delay(5000);
        animator.SetBool("isWalking", true);
        #endregion
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
     {
         // GameObject nearestGameObject = GameObject.FindWithTag(aiBehaviour.tag);
         // if (nearestGameObject != null)
         // {
         //     animator.SetBool("isWalking", true);
         //     animator.SetBool("isIdle", false);
         // }
     }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     
    // }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
