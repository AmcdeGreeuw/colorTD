using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.Log(hit[i].collider.gameObject.name);
            }
                //if (raycastHit.transform != null)
                //{
                //    //Our custom method. 
                    
                //}
            
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        Debug.Log($"{gameObject.name}");
    }
}
