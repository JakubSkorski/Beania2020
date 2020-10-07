using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    // SCHODY
    // gdy gracz wejdzie na schody zmieniany jest model szkoły z parteru na 2 pietro.
    public class StairsController
    {
        private int floorNumber = 0;
        void OnTriggerEnter2D(Collider2D collision)
        {
            floorNumber = (floorNumber == 1) ? 0 : 1;

            // change floor object
        }
    }
}
