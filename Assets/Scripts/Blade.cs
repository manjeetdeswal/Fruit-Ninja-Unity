using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera camera;
    private bool slicing;
    private Collider collider;
    public float sliceForce = 5f;
    public Vector3 direction;
    private TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        collider = GetComponent<Collider>();
        camera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSliceing();
            
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopSliceing();
        }else if (slicing)
        {
            contineUing();
        }
    }

    private void OnEnable()
    {
        StopSliceing();
    }
    private void OnDisable()
    {
        StopSliceing();
    }
    void StartSliceing()
    {
        Vector3 newPos = camera.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0f;
        transform.position = newPos;
        slicing = true;
        collider.enabled = true;
        trail.enabled = true;
        trail.Clear();
    }

    void StopSliceing()
    {
        slicing = true;
        collider.enabled = false;
        trail.enabled = false;
    }

    void contineUing()
    {
        Vector3 newPos = camera.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0f;
        direction = newPos - transform.position;
        float velocity =direction.magnitude / Time.deltaTime;
        collider.enabled = velocity > 0.01f;
        transform.position = newPos;

     }
}
