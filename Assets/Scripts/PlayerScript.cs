using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public StateMachine sm;

        // Add your variables holding the different player states here
        public IdleState idleState;
        public WalkingState walkingState;
        public DanceState danceState;
        public ShootState shootState;

        public GameObject projPrefab;

        public Rigidbody2D m_Rigidbody;
        public float turnSmoothing = 1f;
        Vector2 direction;
        public float speed = 10f;

        public Animator anim;


        public Text text;


        // Start is called before the first frame update
        void Start()
        {
            sm = gameObject.AddComponent<StateMachine>();

            // set up the variables for your new states here
            idleState = new IdleState(this, sm);
            walkingState = new WalkingState(this, sm);
            danceState = new DanceState(this, sm);
            shootState = new ShootState(this, sm);


            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();

            text.text = sm.CurrentState.ToString();

        }

        public bool ReadSpaceBar()
        {
            if (Input.GetKey("space"))
            {
                return true;
            }
            return false;

        }
        public bool ReadDance()
        {
            if (Input.GetKey("t"))
            {
                return true;
            }
            return false;

        }
        public bool ReadShot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                return true;
            }
            return false;

        }
        public bool ReadMovement()
        {
            if (sm.CurrentState.GetDirectionInput(direction).magnitude >= 0.1f)
            {                
                return true;
            }
            return false;

        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }

        public void PlayAnim(string animName)
        {
            anim.Play(animName);
        }


        public void PhysicsBehaviour()
        {
            float targetangle = Mathf.Atan2(sm.CurrentState.GetDirectionInput(direction).x, sm.CurrentState.GetDirectionInput(direction).y) * Mathf.Rad2Deg;// finds direction of movement


            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, -targetangle, ref turnSmoothing, 0.2f);// makes it so the player faces its movement direction
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            Vector3 movedir = Quaternion.Euler(0f, 0f, -targetangle) * Vector2.up;// here is the movement
            m_Rigidbody.AddForce(movedir.normalized * speed, ForceMode2D.Impulse);

        }

        public void ShootingProjectile()
        {
            Rigidbody2D rb = Instantiate(projPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            Destroy(rb.gameObject, 2f);
            rb.AddForce(transform.up * 15f, ForceMode2D.Impulse);

        }
    }

}