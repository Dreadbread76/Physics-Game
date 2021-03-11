using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public ClickDrag clickDrag;
    public GameObject cam;

    public GameObject[] spawnables = new GameObject[2];
    public int spawnIndex;

    public TMP_Text currentTool;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject;
        clickDrag = GetComponent<ClickDrag>();
        currentTool.text = "Drag Tool";
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
            currentTool.text = "Drag Tool";
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            clickDrag.enabled = false;
            spawnIndex = 0;
            currentTool.text = "Spawn: Ball";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            clickDrag.enabled = false;
            spawnIndex = 1;
            currentTool.text = "Spawn: Sink";
        }
        if (Input.GetMouseButtonDown(0) && clickDrag.enabled == false)
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                

                Instantiate(spawnables[spawnIndex],hit.point , Quaternion.Euler(0,0,0));
            }
        }
        
    }
    
   
}
