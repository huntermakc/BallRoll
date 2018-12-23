using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    private GameController gameController;
    private Quaternion calibrationQuaterion;

    private void Start()
    {
        CalibrateAccelerometr();
        rb = GetComponent<Rigidbody>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject!=null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    public void CalibrateAccelerometr()
    {
        Vector3 acceleratorSnapshot = Input.acceleration;

        Quaternion rotateQuaterion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), acceleratorSnapshot);

        calibrationQuaterion = Quaternion.Inverse(rotateQuaterion);
    }

    public Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixAcceleration = calibrationQuaterion * acceleration;
        return fixAcceleration;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        Vector3 position = new Vector3(transform.position.x, transform.position.y+10, transform.position.z);
        gameController.SetSpawnValuesLet(position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            gameController.AddCount();
        }
        if (other.gameObject.CompareTag("Let"))
        {
            gameController.ContactLet();
        }
    }

}
