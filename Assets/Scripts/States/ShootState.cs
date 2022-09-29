using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ShootState : State
    {

        string animName = "Shoot";
        // constructor
        public ShootState(PlayerScript player, StateMachine sm) : base(player, sm)
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

            PhysicsUpdate();
            

            if (player.ReadMovement() == true && player.ReadDance() == false)
            {
                sm.ChangeState(player.walkingState);

            }
            else if (player.ReadMovement() == false && player.ReadDance() == false)
            {
                sm.ChangeState(player.idleState);
            }
            else if (player.ReadDance() == true)
            {
                sm.ChangeState(player.danceState);

            }

        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            player.ShootingProjectile();
        }


        public override void PlayAnim(string name)
        {
            player.PlayAnim(name);
        }


    }
}