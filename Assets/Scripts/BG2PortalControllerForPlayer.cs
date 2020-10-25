using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG2PortalControllerForPlayer : MonoBehaviour
{
    public GameObject PortalSprite;
    //public GameObject Prop;
    //public GameObject prop_clone_GO;
    public AudioSource audioData;
    GameObject portal1, portal;

    //private bool is_trigg, usingPortal;
    private bool played = false;

    void Start() {
        audioData = GetComponent<AudioSource>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !played)
        {
            var go = collision.gameObject;
            var playercol = collision.gameObject.GetComponent<PlayerController>();
            played = true;
            playercol.isLocked = true;
            audioData.Play(0);
            yield return new WaitForSeconds(4);

            portal1 = Instantiate(PortalSprite, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), Quaternion.identity, StairsController.floor0.transform);
            portal = Instantiate(PortalSprite, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            var c = portal.GetComponent<SpriteRenderer>();
            c.sortingLayerName = "Floor2";
            c.sortingOrder = 2;

            audioData.Pause();
            yield return new WaitForSeconds(1.5f);

            go.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            Debug.Log("PORTAL: Change floor...");
            StairsController.SetFloor(2);
            playercol.MoveTo(transform.position.x, transform.position.y);
            yield return new WaitForSeconds(0.5f);
            go.SetActive(true);
            playercol.isLocked = false;

            yield return new WaitForSeconds(2f);
            Debug.Log("PORTAL: Destroy portals...");
            Destroy(portal);
            Destroy(portal1);
            Destroy(gameObject);
        }
    }

}
