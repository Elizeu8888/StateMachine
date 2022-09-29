using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class IdleState : State
    {

        string animName = "Idle";
        // constructor
        public IdleState(PlayerScript player, StateMachine sm) : base(player, sm)
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


            if (player.ReadMovement() == true && player.ReadDance() == false)
            {
                sm.ChangeState(player.walkingState);

            }
            else if (player.ReadDance() == true)
            {
                sm.ChangeState(player.danceState);

            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }


        public override void PlayAnim(string name)
        {
            player.PlayAnim(name);
        }


    }
}