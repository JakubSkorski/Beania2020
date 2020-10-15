using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    // Sterowanie drzwiami:
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz O.
    public class DoorControllerUpdated : MonoBehaviour
    {
        public float openedDoorAngle;
        public float rotationSpeed;

        private float rotated;

        private bool isPlayerNextToTheDoor = false;
        private bool isDoorOpened = false;
        private bool isDoorOpening = false;
        //private Rigidbody2D door;

        void Start()
        {
            //door = GetComponent<Rigidbody2D>();
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                isPlayerNextToTheDoor = true;
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                isPlayerNextToTheDoor = false;
                if (isDoorOpened || isDoorOpening)
                {
                    isDoorOpened = false;
                    isDoorOpening = false;
                    transform.Rotate(new Vector3(0, 0, -openedDoorAngle));
                    //door.SetRotation(rotationClosed);
                    //door.MovePosition(positionClosed);
                }
            }
        }

        void Update()
        {
            if(isDoorOpening)
            {
                var angle = rotationSpeed * Time.deltaTime;
                rotated += angle;
                if(rotated >= openedDoorAngle)
                {
                    //angle = rotationOpened;
                    isDoorOpening = false;
                    isDoorOpened = true;
                }
                transform.Rotate(new Vector3(0, 0, angle));
                return;
            }

            if (isPlayerNextToTheDoor && Input.GetKey(KeyCode.O) && !isDoorOpened)
            {
                isDoorOpening = true;
            }
        }
    }
}
