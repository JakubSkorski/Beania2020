using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;

    private Animator anim;
    private Rigidbody2D rigidbody2d;

    private bool playerMoving;
    private Vector2 lastMove;

    // lista uczniów dodanych do drużyny
    private List<NPCController> group = new List<NPCController>();

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Found(NPCController npc)
    {
        if(!group.Contains(npc)) // sprawdza czy dany uczeń znajduje się już w drużynie
        {
            group.Add(npc); // dodaje ucznia do drużyny

            // Proszę wpisać tu co ma się stać do po dodaniu ucznia do drużyny

            
            Debug.Log($"Found: {npc.displayName}");
        }
    }
    public void SetVisible()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void MoveTo(float x, float y)
    {
        rigidbody2d.MovePosition(new Vector2(x,y));
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;
        float speed = movementSpeed;
        float horizontal, vertical;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = (float)1.5 * movementSpeed;
        }
        anim.speed = speed;

        var deltaX = horizontal * speed * Time.deltaTime;
        var deltaY = vertical * speed * Time.deltaTime;

       if (horizontal > 0.5f || horizontal < -0.5f)
       {
            transform.Translate(deltaX, 0f, 0f);
            playerMoving = true;
            lastMove = new Vector2(horizontal, 0f);
       }

       if (vertical > 0.5f || vertical < -0.5f)
       {
           transform.Translate(0f, deltaY, 0f);
           playerMoving = true;
           lastMove = new Vector2(0f, vertical);
       }


        rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(deltaX, deltaY));
        
        // ustawia kierunek chodzenia w animacji:
        anim.SetFloat("DirectionX", horizontal);
        anim.SetFloat("DirectionY", vertical);
        anim.SetFloat("LastX", lastMove.x);
        anim.SetFloat("LastY", lastMove.y);
        anim.SetBool("Moving", playerMoving);
    }
}
