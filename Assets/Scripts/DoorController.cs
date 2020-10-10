using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    // Sterowanie drzwiami:
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz D.   //// edit O czy D bo z kodu wynika ze O
    public class DoorController : MonoBehaviour
=======
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz D.
    public class DoorController
>>>>>>> parent of d474c87... Merge branch 'master' of https://github.com/JakubSkorski/Beania2020
=======
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz D.
    public class DoorController
>>>>>>> parent of d474c87... Merge branch 'master' of https://github.com/JakubSkorski/Beania2020
=======
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz D.
    public class DoorController
>>>>>>> parent of d474c87... Merge branch 'master' of https://github.com/JakubSkorski/Beania2020
    {
        private bool isPlayerNextToTheDoor = false;
        private bool isDoorOpened = false;
<<<<<<< HEAD
=======
        private Rigidbody2D door;

        void Start()
        {
            door = GetComponent<Rigidbody2D>();
            positionClosed = door.position;
            rotationClosed = door.rotation;
        }
>>>>>>> parent of faaca3b... Create a new door opening and closing animation. Use new wall models.

        void OnTriggerEnter2D(Collider2D collision)
        {
            isPlayerNextToTheDoor = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(isDoorOpened)
            {
                isDoorOpened = false;
<<<<<<< HEAD
                // close doors
=======
                door.MovePosition(positionClosed);
                door.MoveRotation(rotationClosed);
>>>>>>> parent of faaca3b... Create a new door opening and closing animation. Use new wall models.
            }
        }

        void Update()
        {
            if (isPlayerNextToTheDoor && Input.GetKey(KeyCode.D))
            {
                isDoorOpened = true;
                // open doors
            }
        }
    }
}
