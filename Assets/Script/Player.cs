using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ClickDrag clickDrag;
    public GameObject cam;

    public List<GameObject> spawnables = new List<GameObject>();
    public int spawnIndex;

    float spawnDistance;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject;
        clickDrag = GetComponent<ClickDrag>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        #region Movement
        if (Input.GetKey(KeyCode.W))
        {
            cam.transform.Translate(Vector3.forward * 0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cam.transform.Translate(Vector3.back * 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cam.transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam.transform.Translate(Vector3.right * 0.1f);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cam.transform.Translate(Vector3.down * 0.1f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            cam.transform.Translate(Vector3.up * 0.1f);
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.E))
        {
            clickDrag.enabled = true;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnItems(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnItems(1);
        }
        if (Input.GetMouseButtonDown(0) && clickDrag.enabled == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                spawnDistance = Vector3.Distance(ray.origin, hit.point);

                
            }
        }
        
    }
    public void SpawnItems(int spawnIndex)
    {
        clickDrag.enabled = false;
        
    }
   
}
