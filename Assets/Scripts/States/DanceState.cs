using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class DanceState : State
    {

        string animName = "Dance";
        // constructor
        public DanceState(PlayerScript player, StateMachine sm) : base(player, sm)
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
            else if (player.ReadMovement() == false && player.ReadDance() == false)
            {
                sm.ChangeState(player.idleState);
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