using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    // SCHODY
    // gdy gracz wejdzie na schody zmieniany jest model szkoły.
    public class StairsController : MonoBehaviour
    {
        public static GameObject floor0;
        public static GameObject floor2;


        void Start()
        {

            if (floor0 == null)
            {
                floor0 = GameObject.FindGameObjectWithTag("floor0-object");
                floor2 = GameObject.FindGameObjectWithTag("floor2-object");
                floor2.SetActive(false);

            }
        }

        public static void SetFloor(int n)
        {
            if(n == 0 && floor0.activeSelf == false)
            {
                floor0.SetActive(true);
                floor2.SetActive(false);
            }
            else if(n == 2 && floor2.activeSelf == false)
            {
                floor2.SetActive(true);
                floor0.SetActive(false);
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            floor0.SetActive(!floor0.activeSelf);
            floor2.SetActive(!floor2.activeSelf);
        }
    }
}
