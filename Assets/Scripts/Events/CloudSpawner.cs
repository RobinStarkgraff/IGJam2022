using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    
    [SerializeField] private GameObject cloud1;
    [SerializeField] private GameObject cloud2;
    [SerializeField] private GameObject cloud3;
    [SerializeField] private  GameObject cloud4;
    public int  speed = 2;
    
    public List<GameObject> upcomingclouds = new List<GameObject>();
    
        private void Awake()
        {
            GameObject cloudi = Instantiate(cloud1, new Vector3(100, 0, 0), Quaternion.identity);
            GameObject cloudii = Instantiate(cloud2, new Vector3(100, 0, 0), Quaternion.identity);
            GameObject cloudiii = Instantiate(cloud3, new Vector3(100, 0, 0), Quaternion.identity);
            GameObject cloudiiii = Instantiate(cloud4, new Vector3(100, 0, 0), Quaternion.identity);
            upcomingclouds.Add(cloudi);
            upcomingclouds.Add(cloudii);
            upcomingclouds.Add(cloudiii);
            upcomingclouds.Add(cloudiiii);
        }
    private void Update()
        {
            foreach(GameObject cloud in upcomingclouds)
            {
                cloud.transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
            }
        }
}
