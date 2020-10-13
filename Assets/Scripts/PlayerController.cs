using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float animationSpeed;

    private Animator anim;
    private Rigidbody2D rigidbody2d;

    // lista uczniów dodanych do drużyny
    private List<ClassmateController> group = new List<ClassmateController>();

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Found(ClassmateController classmate)
    {
        if(!group.Contains(classmate)) // sprawdza czy dany uczeń znajduje się już w drużynie
        {
            group.Add(classmate); // dodaje ucznia do drużyny

            // Proszę wpisać tu co ma się stać do po dodaniu ucznia do drużyny

            
            Debug.Log($"Found: {classmate.displayName}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2 * movementSpeed;
            anim.speed = 2 * animationSpeed; //= 3.5f;
        }
        else
        {
            speed = movementSpeed;
            anim.speed = animationSpeed;
        }

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        var horizontal = (x > 0.5f) || (x < -0.5f) ? x : 0;
        var vertical = (y > 0.5f) || (y < -0.5f) ? y : 0;

        var deltaX = horizontal * speed * Time.deltaTime;
        var deltaY = vertical * speed * Time.deltaTime;

        rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(deltaX, deltaY));
        
        // ustawia kierunek chodzenia w animacji:
        anim.SetFloat("DirectionX", horizontal);
        anim.SetFloat("DirectionY", vertical);
    }
}
