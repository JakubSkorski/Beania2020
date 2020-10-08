﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    // Sterowanie drzwiami:
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz D.
    public class DoorController : MonoBehaviour
    {
        public Vector2 deltaPositionOpened;
        public float deltaRotationOpened;

        private Vector2 positionClosed;
        private float rotationClosed;

        private bool isPlayerNextToTheDoor = false;
        private bool isDoorOpened = false;
        private Rigidbody2D door;

        void Start()
        {
            door = GetComponent<Rigidbody2D>();
            positionClosed = door.position;
            rotationClosed = door.rotation;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            isPlayerNextToTheDoor = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(isDoorOpened)
            {
                isDoorOpened = false;
                door.MovePosition(positionClosed);
                door.MoveRotation(rotationClosed);
            }
        }

        void Update()
        {
            if (isPlayerNextToTheDoor && Input.GetKey(KeyCode.D))
            {
                isDoorOpened = true;
                door.MovePosition(positionClosed + deltaPositionOpened);
                door.MoveRotation(rotationClosed + deltaRotationOpened);
            }
        }
    }
}
