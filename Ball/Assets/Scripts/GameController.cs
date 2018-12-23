using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text countText;
    public Text winOrOverText;
    public Text lifeText;
    public GameObject pickUP;
    public GameObject let;
    public GameObject wall;
    public Vector3 spawnValuesPickUp;
    public Vector3 spawnValuesWalls;
    public float startWait;
    public float spawnWait;
    public float spawnWaitLet;

    private int count;
    private int lifeCount;
    private Vector3 spawnValuesLet;


    void Start ()
    {
        count = 0;
        lifeCount = 3;
        SetCountText();
        winOrOverText.text = "";
        SpawnWalls();
        StartCoroutine (SpawnPickUp());
        StartCoroutine(SpawnLet());
    }
	

	void Update ()
    {
        StartCoroutine (SetCountText());
    }

    void SpawnWalls()
    {
        int i = 0;

        Quaternion spawnRotation = Quaternion.identity;

        Vector3 spawnPositionCentr = new Vector3(Random.Range(-6.5f, -4.2f), 0.0f, 0.0f);
        Instantiate(wall, spawnPositionCentr, spawnRotation);
        Instantiate(wall, spawnPositionCentr * -1, spawnRotation);

        while (i<2)
        {
            Vector3 spawnPositionTop = new Vector3(Random.Range(-spawnValuesWalls.x, spawnValuesWalls.x),spawnValuesWalls.y,spawnValuesWalls.z);            
            Vector3 spawnPositionDown = new Vector3(Random.Range(-spawnValuesWalls.x, spawnValuesWalls.x), spawnValuesWalls.y, -spawnValuesWalls.z);
            Instantiate(wall, spawnPositionTop, spawnRotation);            
            Instantiate(wall, spawnPositionDown, spawnRotation);
            i++;
        }

    }

    IEnumerator SpawnPickUp()
    {
        yield return new WaitForSeconds(startWait);
        Quaternion spawnRotation = Quaternion.identity;
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesPickUp.x, spawnValuesPickUp.x), spawnValuesPickUp.y, Random.Range(-spawnValuesPickUp.z, spawnValuesPickUp.z));
            Instantiate(pickUP, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);

            if (lifeCount<=0 || count >= 12)
            {
                break;
            }
        }
        
    }

    IEnumerator SpawnLet()
    {
            yield return new WaitForSeconds(startWait+2);
            Quaternion spawnRotation = Quaternion.identity;
            while (true)
            {

                Vector3 spawnPosition = new Vector3(Random.Range(spawnValuesLet.x - 1, spawnValuesLet.x + 1), spawnValuesLet.y, Random.Range(spawnValuesLet.z - 1, spawnValuesLet.z + 1));
                Instantiate(let, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWaitLet);

                if (lifeCount <= 0 || count >= 12)
                {
                    break;
                }
            }
                

    }

    public void SetSpawnValuesLet(Vector3 Vector3Values)
    {
        spawnValuesLet = Vector3Values;
    }

    IEnumerator SetCountText()
    {
        lifeText.text = " " + lifeCount.ToString();
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winOrOverText.text = "You Win!";
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MenuScens");
        }
        if (lifeCount<=0)
        {
            winOrOverText.text = "Game Over";
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MenuScens");
        }
    }

    public void AddCount()
    {
        if (count < 12)
        {
            count++;
        }
    }

    public void ContactLet()
    {
        if (count < 12)
        {
            if (lifeCount>0)
            {
                lifeCount--;
            }
            if (count > 0)
            {
                count--;
            }
        }
        
    }

   
}
