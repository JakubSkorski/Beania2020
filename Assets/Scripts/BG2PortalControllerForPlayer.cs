using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG2PortalControllerForPlayer : MonoBehaviour
{
    public GameObject PortalSprite;
    public GameObject Prop;
    //public GameObject prop_clone_GO;
    public AudioSource audioData;

    private bool is_trigg;
    private bool played = false;



    void Start() {
        audioData = GetComponent<AudioSource>();
    }



    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !played)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            played = true;
            audioData.Play(0);
            yield return new WaitForSeconds(4);

            GameObject portal1 = (GameObject)Instantiate(PortalSprite, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), Quaternion.identity);
            GameObject portal = (GameObject)Instantiate(PortalSprite, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

            audioData.Pause();

            yield return new WaitForSeconds(2);
            //Destroy(collision.gameObject); 
            player.SetVisible();
            yield return new WaitForSeconds(1);
            player.MoveTo(transform.position.x, transform.position.y);
            yield return new WaitForSeconds(1);
            player.SetVisible();
            //prop_clone_GO = (GameObject)Instantiate(Prop, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z - 1), Quaternion.identity);

            yield return new WaitForSeconds(3);

            Destroy(portal);
            Destroy(portal1);

            Destroy(gameObject);    
        }
    }
}
