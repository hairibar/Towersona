﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDispenser : MonoBehaviour
{
    public Camera detailCamera;

    [HideInInspector]
    public Towersona towersona;
    [HideInInspector]
    public TowersonaAnimation towersonaAnim;
    [HideInInspector]
    public TowersonaNeeds towersonaNeeds;

    [SerializeField]
    private float dispenseDelay = 1f;

    [SerializeField]
    private Food foodPrefab = null;
    private TowersonaHOD detailedTowersonaView;    

    private void Awake()
    {
        detailedTowersonaView = transform.parent.gameObject.GetComponent<TowersonaHOD>();
    }

    private void Start()
    {
        towersonaAnim = detailedTowersonaView.towersonaAnim;
        towersonaNeeds = detailedTowersonaView.towersonaNeeds;
        DispenseImmidiately();
    }

    public void DispenseImmidiately()
    {
        Food newFood = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        newFood.dispenser = this;
        newFood.transform.SetParent(transform);

        Draggable draggable = newFood.GetComponentInChildren<Draggable>();
        draggable.detailCamera = detailCamera;
        draggable.OnDragStart.AddListener(NotifyFoodDrag);

        towersonaAnim.SetIsLookingAtFood(false);
        towersonaAnim.SetLookAtTransform(draggable.transform);
    }

    public void DispenseWithDelay()
    {
        Invoke("DispenseImmidiately", dispenseDelay);
        towersonaAnim.SetIsLookingAtFood(false);
    }

    private void NotifyFoodDrag()
    {
        towersonaAnim.SetIsLookingAtFood(true);    
    }
}
