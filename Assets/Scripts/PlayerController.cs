using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movmentSpeed;

    private Animator anim;
    private Rigidbody2D rigidbody2d;

    private List<ClassmateController> group = new List<ClassmateController>();

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        anim.speed = 1.75f;
    }

    // znaleziono ucznia
    public void Found(ClassmateController classmate)
    {
        if(!group.Contains(classmate))
        {
            group.Add(classmate);
            Debug.Log($"Found: {classmate.displayName}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2 * movmentSpeed;
            anim.speed = 3.5f;
        }
        else
        {
            speed = movmentSpeed;
            anim.speed = 1.75f;
        }

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        var horizontal = (x > 0.5f) || (x < -0.5f) ? x : 0;
        var vertical = (y > 0.5f) || (y < -0.5f) ? y : 0;

        var deltaX = horizontal * speed * Time.deltaTime;
        var deltaY = vertical * speed * Time.deltaTime;

        rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(deltaX, deltaY));
        
        anim.SetFloat("DirectionX", horizontal);
        anim.SetFloat("DirectionY", vertical);
    }
}
