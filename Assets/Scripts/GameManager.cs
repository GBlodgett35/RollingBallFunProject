/*
 * Author: Greg Blodgett
 * Class: Game Development
 * Instructor: Dr. McCown
 * Due Date: 9/7/2020
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*
 * This is a class that will manage the Game - starting, restarting, and exiting the game
 * Will contain generic functions that every scene will need
 * 
 */
public class GameManager : MonoBehaviour
{
    //https://www.loekvandenouweland.com/content/use-unity-button-to-change-between-scenes.html
    public TextMeshProUGUI button;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Got here");
        //SceneManager.LoadScene (sceneBuildIndex:/*Put the number here*/);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
