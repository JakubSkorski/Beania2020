using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class DeleeeetNpc : MonoBehaviour
{
    bool Delet = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Delet = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Delet = false;
        }
    }
    void Update() {

        if (Delet) {
            if(Input.GetKey(KeyCode.E)) Destroy(gameObject);
        }
    }


}



