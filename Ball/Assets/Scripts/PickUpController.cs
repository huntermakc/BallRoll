using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public float timeLife;

    //private CapsuleCollider cC;
    private bool chek;
    private bool growthing;
    private AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        // cC = GetComponent<CapsuleCollider>();
        chek = false;
        Destroy(gameObject, timeLife);
        growthing = true;


        //rb.isKinematic = false;
        //cC.isTrigger = false;

    }

    void Update ()
    {
        if (transform.localScale.x>0.5)
        {
            growthing = false;
        }
        Growth();
        StartCoroutine(Decrease());


        transform.Rotate(new Vector3(0, 45, 0)* Time.deltaTime);
        if (chek)
        {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * 5);
            Vector3 movement = new Vector3(0.0f, 0.2f, 0.0f);
            transform.Translate(movement);
        }
    }

    void Growth()
    {
        if (growthing)
        {
            transform.localScale += new Vector3(0.01F, 0.01F, 0.01F);
        }

    }

    IEnumerator Decrease()
    {
        yield return new WaitForSeconds(timeLife-1);
        if (!growthing)
        {
            transform.localScale -= new Vector3(0.01F, 0.01F, 0.01F);
           // Debug.Log("Decrease");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chek = true;
            audioData.Play();
        }
    }
}
