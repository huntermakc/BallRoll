using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByWall : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Let"))
        {
            Destroy(other.gameObject);
        }
    }
}
