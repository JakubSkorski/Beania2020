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
        private GameObject floor0;
        private GameObject floor2;

        void Start()
        {
            floor0 = GameObject.FindGameObjectWithTag("floor0-object");
            floor2 = GameObject.FindGameObjectWithTag("floor2-object");
            floor2.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            floor0.SetActive(!floor0.activeSelf);
            floor2.SetActive(!floor2.activeSelf);
        }
    }
}
