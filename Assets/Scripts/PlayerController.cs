using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movmentSpeed;

    private Animator anim;
    private List<Classmate> Group = new List<Classmate>();
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        anim.speed = 2.5f;
    }

    public void Found(Classmate classmate)
    {
        if(!Group.Contains(classmate))
        {
            Group.Add(classmate);
            Debug.Log($"Found: {classmate.DisplayName} id: {classmate.Id}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2 * movmentSpeed;
        }
        else
        {
            speed = movmentSpeed;
        }

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var deltaX = horizontal * speed * Time.deltaTime;
        var deltaY = vertical * speed * Time.deltaTime;

        rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(deltaX, deltaY));
        
        anim.SetFloat("DirectionX", horizontal*50);
        anim.SetFloat("DirectionY", vertical*50);
    }
}
