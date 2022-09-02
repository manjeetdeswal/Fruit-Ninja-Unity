using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slice;
    public GameObject whole;
    public Rigidbody rigidbody;
    public Collider collider;
    private AudioSource audio;
    private ParticleSystem particle;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        audio = GetComponent<AudioSource>();
        particle = GetComponentInChildren<ParticleSystem>();

    }
    private void Slice(Vector3 direction, Vector3 postion,float force)
    {

        FindObjectOfType<GameManagert>().IncreseScore();
        
        audio.Play();
        whole.SetActive(false);
        slice.SetActive(true);
        collider.enabled=(false);
        particle.Play();
        float angle = Mathf.Atan2(direction.y, direction.x)  * Mathf.Rad2Deg;
        slice.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Rigidbody[] slices = slice.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody slice in slices)
        {
            slice.velocity = rigidbody.velocity;
            slice.AddForceAtPosition(direction * force, postion,ForceMode.Impulse);


        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blader = other.GetComponent<Blade>();
            Slice(blader.direction, blader.transform.position, blader.sliceForce);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
