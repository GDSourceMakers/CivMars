using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour
{
    public float speed;
    Animator anim;
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
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.eulerAngles = Vector3.zero;

        //if (Input.anyKey && g.gameState == Globals.GameState.InGame) {

        //anim.SetBool("Stay", false);

        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
            //anim.SetInteger("Direction", 1);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
            //anim.SetInteger("Direction", 3);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed * Input.GetAxis("Vertical")));
            //anim.SetInteger("Direction", 0);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed * Input.GetAxis("Vertical")));
            //anim.SetInteger("Direction", 2);
        }




        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(gameObject.GetComponent<Rigidbody2D>().velocity, Vector2.zero, Time.deltaTime * speed * speed);
        //anim.SetBool("Stay", true);
 

        

    }
}