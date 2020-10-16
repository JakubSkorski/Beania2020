using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG2PortalControl : MonoBehaviour
{

    public GameObject PortalSprite;
    public GameObject Prop;
    private bool is_trigg;

    public GameObject prop_clone_GO;


    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject portal = (GameObject)Instantiate(PortalSprite, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            yield return new WaitForSeconds(2);

            prop_clone_GO = (GameObject)Instantiate(Prop, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z-1), Quaternion.identity);

            yield return new WaitForSeconds(4);
            Destroy(portal);
            Destroy(gameObject);
        }
    }


}
    