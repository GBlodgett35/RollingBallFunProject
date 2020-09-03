/*
 * Author: Greg Blodgett
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;
using System;

public class PlayerController : MonoBehaviour
{
    
    private float radius = 5.0f;
    private int count;
    private int numBlocks = 12;
    public float speed = 0.0f;

    //Variables to hold references to different pieces of the game
    public GameObject prefab;
    public GameObject floorBlock1;
    public GameObject floorBlock2;

    //Various text elements
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    List<GameObject> floorBlocks = new List<GameObject>();

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        floorBlock1.SetActive(true);
        floorBlock2.SetActive(true);
        //Spawn floor
        for (int z = 0; z < 20; ++z)
        {
            for (int x = 0; x < 20; ++x)
            {
                GameObject temp;
                if ((x + z) % 2 == 0)
                {
                    temp = Instantiate(floorBlock1, new Vector3(10 - x, -0.5f, 10 - z), Quaternion.identity);
                } else
                {
                    temp = Instantiate(floorBlock2, new Vector3(10 - x, -0.5f,10 - z), Quaternion.identity);
                }
                floorBlocks.Add(temp);
            }
        }
        //Shuffle list - https://stackoverflow.com/questions/273313/randomize-a-listt
        floorBlocks = floorBlocks.OrderBy(a => Guid.NewGuid()).ToList();

        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        //winTextObject.SetActive(false);
        //loseTextObject.SetActive(true);
        //https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
        for (int i = 0; i < numBlocks; i++)
        {
            float angle = i * Mathf.PI * 2 / numBlocks;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(prefab, pos, rot);
        }

        //Start dropping blocks every 2 seconds
        InvokeRepeating("DropFloorBlock", 0f, 2f);
    }

    int randomX = 0;
    int randomZ = 0;
    System.Random random = new System.Random();

    void spawnPickup()
    {
        randomX = random.Next(0, 20);
        randomZ = random.Next(0, 20);
        Instantiate(prefab, new Vector3(10 - randomX, 0.5f, 10 - randomZ), Quaternion.identity);
    }


    //Deletes a floor block
    int floorBlockCount = 0;
    void DropFloorBlock()
    {
        floorBlocks.ElementAt(floorBlockCount).SetActive(false);
        floorBlockCount++;
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            count++;
            other.gameObject.SetActive(false);
            setCountText();
            spawnPickup();
        }
        if(count >= numBlocks)
        {
            wonGame();
        }
    }

    private void wonGame()
    {
        winTextObject.SetActive(true);
        gameObject.SendMessage("stopTimer");

        enabled = false;
    }

    private void lostGame()
    {
        for (int i = floorBlockCount; i < floorBlocks.Capacity; i++)
        {
            floorBlocks.ElementAt(i).SetActive(false);

        }
        loseTextObject.SetActive(true);

        enabled = false;
    }

}
