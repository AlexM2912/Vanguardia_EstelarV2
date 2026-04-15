using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolin : MonoBehaviour
{
    public Animator trampolinAnimator;
    // Start is called before the first frame update
    void Start()
    {
        trampolinAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            trampolinAnimator.SetBool("movimiento", false);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            trampolinAnimator.SetBool("movimiento", true);
        }
    }

}
