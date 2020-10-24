using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG2PortalControllerForPlayer : MonoBehaviour
{
    public GameObject PortalSprite;
    public GameObject Prop;
    //public GameObject prop_clone_GO;
    public AudioSource audioData;

    private bool is_trigg, usingPortal;
    private bool played = false;

    float playerX;
    float playerY;

    private static GameObject floor0;
    private static GameObject floor2;


    void Start() {
        audioData = GetComponent<AudioSource>();
        floor0 = GameObject.FindGameObjectWithTag("floor0-object");
        floor2 = GameObject.FindGameObjectWithTag("floor2-object");
    }



    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !played)
        {
            playerX = GameObject.Find("Player").transform.position.x;
            playerY = GameObject.Find("Player").transform.position.y;

            var playercol = collision.gameObject.GetComponent<PlayerController>();
            played = true;
            usingPortal = true;
            audioData.Play(0);
            yield return new WaitForSeconds(4);

            GameObject portal1 = (GameObject)Instantiate(PortalSprite, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), Quaternion.identity);
            GameObject portal = (GameObject)Instantiate(PortalSprite, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            audioData.Pause();

            yield return new WaitForSeconds(2);
            //Destroy(collision.gameObject); 
            playercol.SetVisible();
            yield return new WaitForSeconds(1);
            Debug.Log("Test");
            floor2.SetActive(true);
            floor0.SetActive(false);
            playercol.MoveTo(transform.position.x, transform.position.y);
            yield return new WaitForSeconds(1);
            playercol.SetVisible();
            //prop_clone_GO = (GameObject)Instantiate(Prop, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z - 1), Quaternion.identity);

            yield return new WaitForSeconds(3);

            Destroy(portal);
            Destroy(portal1);

            Destroy(gameObject);
            usingPortal = false;
        }
    }

    private void Update()
    {
        if(usingPortal)
        {
            GameObject.Find("Player").transform.position = new Vector3(playerX, playerY, 0);
        }
    }

}
