using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flap_strength;
    public LogicScript logic;
    private Vector2 ScreenBounds;
    private float bird_height;
    public bool bird_is_alive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bird_height = transform.GetComponent<SpriteRenderer>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bird_is_alive)
        {
            myRigidBody.velocity = Vector2.up * flap_strength;
        }
        if (transform.position.y > ScreenBounds.y + bird_height || -1 * transform.position.y > ScreenBounds.y + bird_height)
        {
            logic.GameOver();
            bird_is_alive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        bird_is_alive = false;
    }
}
