/*
 * Author: Greg Blodgett
 * Class: Game Development
 * Instructor: Dr. McCown
 * Due Date: 9/7/2020
 * Citations:
 * 
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


/*
 * This is a class that will manage the Game - starting, restarting, and exiting the game
 * Will contain generic functions that every scene will need
 * 
 */
public class GameManager2 : ScriptableObject
{
    static Timer prefab = Resources.Load<Timer>("/Assets/Prefabs/Timer") as Timer;
    //static Timer timerPrefab = ((GameObject)AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/Timer.prefab")).GetComponent<Timer>();
    //https://www.loekvandenouweland.com/content/use-unity-button-to-change-between-scenes.html
    public static TextMeshProUGUI button;
    public static Timer timer = Instantiate(prefab);
    // Start is called before the first frame update


    // Update is called once per frame

}
