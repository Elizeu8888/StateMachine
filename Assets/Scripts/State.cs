using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class State
    {
        protected PlayerScript player;
        protected StateMachine sm;

        // base constructor
        protected State(PlayerScript player, StateMachine sm)
        {
            this.player = player;
            this.sm = sm;
        }

        public virtual void Enter()
        {

        }

        public virtual void PlayAnim(string anim)
        {
            
        }

        public virtual Vector2 GetDirectionInput(Vector2 direction)
        {

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector2(horizontal, vertical).normalized;
            return direction;
        }

        public virtual void PhysicsBehaviour(Rigidbody2D m_Rigidbody2D)
        {

        }

        public virtual void HandleInput()
        {
        }

        public virtual void LogicUpdate()
        {
            if (player.ReadShot() == true)
            {
                sm.ChangeState(player.shootState);
            }
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {

        }
    }


}
