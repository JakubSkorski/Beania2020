using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClassmateController : MonoBehaviour
    {
        //public float movmentSpeed;
        public string displayName;
        public int id;

        private Animator anim;

        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();

            var x = gameObject.GetComponentInChildren<TextMesh>();
            x.text = displayName;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
           var player = collision.gameObject.GetComponent<PlayerController>();
           if (player != null)
           {
                player.Found(this);
           }
       }

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("Collision");
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //var player = collision.gameObject.GetComponent<PlayerController>();
            //if (player != null)
            //{
            //    player.ExitTarget();
            //}
        }

        // Update is called once per frame
        /*void Update()
        {
          

        }*/
    }
}
