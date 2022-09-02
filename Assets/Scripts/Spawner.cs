using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider spwan;
    public GameObject[] fruits;
    public GameObject bombPre;
    public float minD = 0.25f;
    public float maxD = 1.25f;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce =15f;
    public float maxForce = 20f;
    public float maxLife = 5f;
    [Range(0,1f)]
    public float bombChance = 5f; 








    void Awake()
    {
        spwan = GetComponent<Collider>();


        
    }

    private void OnEnable()
    {
        StartCoroutine(Spawne());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

        private IEnumerator Spawne()
    {
        yield return new WaitForSeconds(Random.Range(2, 3));
        while (enabled)
        {

            GameObject fruit = fruits[Random.Range(0, fruits.Length)];
            if (Random.value < bombChance)
            {
                fruit = bombPre;
            }

            Vector3 pos = new Vector3();
            pos.x = Random.Range(spwan.bounds.min.x, spwan.bounds.max.x);
            pos.y = Random.Range(spwan.bounds.min.y, spwan.bounds.max.y) ;
            pos.z = Random.Range(spwan.bounds.min.z, spwan.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
          GameObject realFruit= Instantiate(fruit,pos, rotation);
            Destroy(realFruit, maxLife);
            float force = Random.Range(minForce, maxForce);
            realFruit.GetComponent<Rigidbody>().AddForce(realFruit.transform.up * force, ForceMode.Impulse);



            yield return new WaitForSeconds(Random.Range(minD, maxD));
        }
    }
}
