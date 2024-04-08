using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrade : MonoBehaviour
{
    public GameObject up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.name == collision.gameObject.name)
        {
            Destroy(this.gameObject);

            collision.gameObject.GetComponent<upgrade>().up = null;
            if (up)
            {
                Instantiate(up, this.transform.position, this.transform.rotation);
            }
        }
    }

}
