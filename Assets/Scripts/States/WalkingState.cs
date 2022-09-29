using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class WalkingState : State
    {

        string animName = "Walking";
        // constructor
        public WalkingState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }


        public override void Enter()
        {
            base.Enter();
            PlayAnim(animName);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            PhysicsUpdate();



            if (player.ReadMovement() == false && player.ReadDance() == true)
            {
                sm.ChangeState(player.danceState);

            }
            else if (player.ReadMovement() == false && player.ReadDance() == false)
            {
                sm.ChangeState(player.idleState);
            }


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.PhysicsBehaviour();
        }

        public override void PlayAnim(string name)
        {
            player.PlayAnim(name);
        }

        

    }
}
