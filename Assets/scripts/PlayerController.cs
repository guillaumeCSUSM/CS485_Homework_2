using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private GameObject[] pickups;

    void Start()
    {
        speed = 2F;
        rb = GetComponent<Rigidbody>();
        //pickups = GameObject.FindGameObjectsWithTag("Pickup");
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveVertical > 0)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if (moveVertical < 0)
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
        transform.Rotate(new Vector3(0, moveHorizontal * speed, 0));
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine("Attack");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
        }*/
    }

    IEnumerator Attack()
    {
        transform.Find("Sword").Translate(new Vector3(-1, 0, 0));
        yield return new WaitForSeconds(.1f);
        transform.Find("Sword").Translate(new Vector3(1, 0, 0));
    }
}