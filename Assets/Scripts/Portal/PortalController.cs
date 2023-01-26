using System.Collections;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform destination;

    private GameObject player;

    private Animation anim;

    private Rigidbody2D rb;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animation>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bool checkDistance =
                Vector2
                    .Distance(player.transform.position, transform.position) >
                0.3f;

            if (checkDistance)
            {
                StartCoroutine(PortalIn());
            }
        }
    }

    private IEnumerator PortalIn()
    {
        rb.simulated = false;
        anim.Play("PortalIn");
        StartCoroutine(MoveInPortal());

        yield return new WaitForSeconds(0.5f);
        player.transform.position = destination.position;
        rb.velocity = Vector2.zero;
        anim.Play("PortalOut");
        
        yield return new WaitForSeconds(0.5f);
        rb.simulated = true;
    }

    private IEnumerator MoveInPortal(){
        float timer = 0;
        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position,transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }
}
