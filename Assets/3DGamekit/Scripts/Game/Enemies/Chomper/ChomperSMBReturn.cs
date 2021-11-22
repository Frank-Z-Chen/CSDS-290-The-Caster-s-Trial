using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
    public class ChomperSMBReturn : SceneLinkedSMB<ChomperBehavior>
    {
        public string state;

        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            m_MonoBehaviour.WalkBackToBase();
            var controller = animator.gameObject.GetComponent<EnemyController>();
            if (controller == null) return;
            controller.state = state;
        }

        public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var controller = animator.gameObject.GetComponent<EnemyController>();
            if (controller == null) return;
            controller.state = "";
        }

        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnSLStateNoTransitionUpdate(animator, stateInfo, layerIndex);

            m_MonoBehaviour.FindTarget();

            if(m_MonoBehaviour.target != null)
                m_MonoBehaviour.StartPursuit(); // if the player got back in our vision range, resume pursuit!
            else 
                m_MonoBehaviour.WalkBackToBase();

        }
    }
}