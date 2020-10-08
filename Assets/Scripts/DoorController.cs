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
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz D.   //// edit O czy D bo z kodu wynika ze O
    public class DoorController : MonoBehaviour
=======
    // drzwi otwierają się, gdy gracz znajduje się w zasięgu collider-a drzwi i wciśnie klawisz D.
    public class DoorController
>>>>>>> parent of d474c87... Merge branch 'master' of https://github.com/JakubSkorski/Beania2020
    {
        private bool isPlayerNextToTheDoor = false;
        private bool isDoorOpened = false;

        void OnTriggerEnter2D(Collider2D collision)
        {
            isPlayerNextToTheDoor = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if(isDoorOpened)
            {
                isDoorOpened = false;
                // close doors
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
