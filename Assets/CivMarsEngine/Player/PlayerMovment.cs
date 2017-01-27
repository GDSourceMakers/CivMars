using UnityEngine;
using System.Collections;
namespace CivMarsEngine
{
    public class PlayerMovment : MonoBehaviour
    {
        public float speed;
        Animator anim;
        private bool moving;
        bool presd;

        // Use this for initialization
        void Start()
        {
            //anim = GetComponent<Animator>();
            //g = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Globals> ();
        }

        // Update is called once per frame
        void Update()
        {
            //GetComponent<Rigidbody2D>().angularVelocity = 0;
            //transform.eulerAngles = Vector3.zero;

            //if (Input.anyKey && g.gameState == Globals.GameState.InGame) {

            //anim.SetBool("Stay", false);

            Rigidbody2D a = gameObject.GetComponent<Rigidbody2D>();
            float accSpeed = (Input.GetAxis("Sprint") != 0) ? speed * 2 : speed;

            if (Input.GetAxis("Horizontal") != 0)
            {
                a.velocity = new Vector2(accSpeed * Input.GetAxis("Horizontal"), a.velocity.y);
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
                //anim.SetInteger("Direction", 1);
                moving = true;
            }
            if (Input.GetAxis("Vertical") != 0)
            {
                a.velocity = new Vector2(a.velocity.x, accSpeed * Input.GetAxis("Vertical"));
                //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed * Input.GetAxis("Vertical")));
                //anim.SetInteger("Direction", 0);
                moving = true;
            }
            if (!moving)
            {
                a.velocity = Vector2.zero;

            }
            moving = false;


            //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(gameObject.GetComponent<Rigidbody2D>().velocity, Vector2.zero, Time.deltaTime * speed * speed);
            //anim.SetBool("Stay", true);




        }
    }
}