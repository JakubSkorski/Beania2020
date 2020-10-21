using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class NPCController : MonoBehaviour
    {
        //public float movementSpeed;
        public string displayName;
        public int id;

        private TextMesh nameText;
        ////private Animator anim;

        void Start()
        {
            ////anim = GetComponent<Animator>();

            nameText = gameObject.GetComponentInChildren<TextMesh>();
            nameText.text = displayName;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
           var player = collision.gameObject.GetComponent<PlayerController>();
           if (player != null)
           {
                player.Found(this);
                //Destroy(gameObject, 1);
           }
            /////anim.SetFloat("DirectionX", -1);
        }

        //void OnCollisionEnter2D(Collision2D col)
        //{
            //Debug.Log("Collision");
        //}

        private void OnTriggerExit2D(Collider2D collision)
        {
            //var player = collision.gameObject.GetComponent<PlayerController>();
            if (collision.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        /*void Update()
        {
          

        }*/
    }
}
