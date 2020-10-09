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

    public class DoorController : MonoBehaviour
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
