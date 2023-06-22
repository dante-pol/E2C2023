using UnityEngine;

public class SlidingGround : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().IsSlide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().IsSlide = false;
            collision.gameObject.GetComponent<PlayerMove>().SlideForce *= -1;
        }
    }

}
