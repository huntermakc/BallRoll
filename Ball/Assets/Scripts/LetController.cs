using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetController : MonoBehaviour {

    public float timeLife;

    private float valueY;
    private bool decreasing;
    private SphereCollider SpherColl;
    private AudioSource audioData;


    void Start ()
    {
        audioData = GetComponent<AudioSource>();
        SpherColl = GetComponent<SphereCollider>();
        valueY = Random.Range(45, 360);
        decreasing = false;
        Destroy(gameObject, timeLife);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (transform.position.y > 0.2f)
        {
            transform.Rotate(new Vector3(0.0f, valueY, 0.0f) * Time.deltaTime);
            Vector3 movement = new Vector3(0.0f, -0.2f, 0.0f);
            transform.Translate(movement);
        }
        else
        {
            decreasing = true;
        }
        StartCoroutine(Decrease(0.01f));
    }

    IEnumerator Decrease(float value)
    {
        yield return new WaitForSeconds(timeLife - 1);
        if (decreasing && transform.localScale.x>=0.0f)
        {
            transform.localScale -= new Vector3(value, value, value);
            Debug.Log("Decrease Let");
        }
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            audioData.Play();
            decreasing = true;
            timeLife = 1;
            SpherColl.isTrigger = false;
           // StartCoroutine(Decrease(0.1f));
        }
    }

   // private void OnTriggerExit(Collider other)
   // {
    //    if (other.CompareTag("Player"))
    //    {                                                 Если включать тригер сразу после покадания колайдера то игрок болучет огромный минус по очкам
            //decreasing = true;
            //timeLife = 1;
            //SpherColl.isTrigger = true;
            // StartCoroutine(Decrease(0.1f));
    //    }
    //}

}
