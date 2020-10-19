using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts
{
    // Sterowanie drzwiami:
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz O.
    public class DoorControllerUpdated : MonoBehaviour
    {
        public float openedDoorAngle;
        public float rotationSpeed;
        public float acceleration;
        public float baseSpeed = 0.6f;

        private float rotated;
        private float currentSpeed;

        private bool isPlayerNextToTheDoor = false;
        private bool isDoorOpened = false;
        private bool isDoorOpening = false;
        //private Rigidbody2D door;

        void Start()
        {
            //door = GetComponent<Rigidbody2D>();
            currentSpeed = baseSpeed;
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
                    rotated = 0;
                    currentSpeed = baseSpeed;
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    //door.SetRotation(rotationClosed);
                    //door.MovePosition(positionClosed);
                }
            }
        }

        void Update()
        {
            if(isDoorOpening)
            {
                currentSpeed *= acceleration;
                var check = CheckAngle(currentSpeed * Time.deltaTime,rotated, openedDoorAngle, out var angle);
                if(check)
                {
                    isDoorOpening = false;
                    isDoorOpened = true;
                }
                rotated += angle;
                transform.Rotate(new Vector3(0, 0, angle));
                return;
            }

            if (isPlayerNextToTheDoor && Input.GetKey(KeyCode.O) && !isDoorOpened)
            {
                isDoorOpening = true;
            }
        }

        private bool CheckAngle(float delta, float rotationA, float maxAngle, out float output)
        {
            var rotation = rotationA + delta;
            if((maxAngle < 0 && rotation < maxAngle) || (maxAngle > 0 && rotation > maxAngle))
            {
                output = maxAngle - rotationA;
                return true;
            }
            output = delta;
            return false;
        }
    }
}
