﻿#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set; }
   

    [Header("Victory and Defeat References")]
    [SerializeField]
    private GameObject victoryPrompt;     
    [SerializeField]
    private GameObject defeatPrompt;      

    [Header("Other References")]
    [SerializeField][Tooltip("The first detailed scene camera without the detailed model")]
    private Camera emptyCamera;

    //Private Parameters             

    //Private references
    private LevelManager wavesController;
    private BuildManager towerDefenseManager;
    private Camera activeCamera;                    //Camera of the detailed scene of the Towersona selected
  
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        activeCamera = GameObject.FindGameObjectWithTag("Default Camera").GetComponent<Camera>();     

        wavesController = GetComponent<LevelManager>();             
    }   
    
    /// <summary>
    /// Changes to victory state
    /// </summary>
    public void WinGame()
    {
        victoryPrompt.SetActive(true);
    }

    /// <summary>
    /// Changes to defeat state
    /// </summary>
    public void GameOver()
    {
        defeatPrompt.SetActive(true);        
    }

    /// <summary>
    /// Changes the camera of the Detailed Scene to the Detailed Scene of a specific Towersona.
    /// </summary>
    /// <param name="towersona">Towersona to be shown in the Detailed Scene</param>
    public void ChangeCamera(Camera camera)
    {     
        if (emptyCamera.gameObject.activeSelf)
        {
            emptyCamera.gameObject.SetActive(false);
        }
        else
        {
            activeCamera.enabled = false;
        }

        activeCamera = camera;

        activeCamera.enabled = true;
    }

    public void ActivateEmptyCamera()
    {
        emptyCamera.gameObject.SetActive(true);
    }
}
