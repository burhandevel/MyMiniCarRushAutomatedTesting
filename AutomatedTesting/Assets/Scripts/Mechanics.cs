using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Mechanics : MonoBehaviour
{
    public float speed = 5;
    bool grounded = true;
    float maxLanes = 3;
    float rightLaneBoundary;
    float leftLaneBoundary;
    float distanceToMove = 1;
    float jumpHeight = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (maxLanes % 2 == 0)
        {
            rightLaneBoundary = maxLanes;
            leftLaneBoundary = 1;
            /*Debug.Log("Left Lane = " + leftLaneBoundary);
            Debug.Log("Right Lane = " + rightLaneBoundary);*/
        }
        else
        {
            rightLaneBoundary = (maxLanes / 2) - 0.5f;
            leftLaneBoundary = -rightLaneBoundary;
            /*Debug.Log("Left Lane = " + leftLaneBoundary);
            Debug.Log("Right Lane = " + rightLaneBoundary);*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            SwipeLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SwipeRight();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SwipeUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SwipeDown();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Boost();
        }
    }

    public void SwipeLeft()
    {
        Vector3 pos = this.transform.position;
        if (pos.x == leftLaneBoundary)
        {
            this.transform.position = pos;
        }
        else
        {
            pos.x -= distanceToMove;
            this.transform.position = pos;
        }
    }

    public void SwipeRight()
    {
        Vector3 pos = this.transform.position;
        if (pos.x == rightLaneBoundary)
            this.transform.position = pos;
        else
        {
            pos.x += distanceToMove;
            this.transform.position = pos;
        }
    }

    public void SwipeUp()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + jumpHeight, this.transform.position.z);
        grounded = false;
        StartCoroutine("JumpDelay");
    }

    public void SwipeDown()
    {
        if(this.transform.localScale.y < 1)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 0.5f, 1);
            StartCoroutine("DuckDelay");
        }
        
    }


    public void Dash()
    {
        speed = 8;
        //StartCoroutine("DashDelay");
    }

    public void Boost()
    {
        speed = 12;
        StartCoroutine("BoostDelay");
    }

    public IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(1);
        this.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
        grounded = true;
    }

    public IEnumerator DuckDelay()
    {
        yield return new WaitForSeconds(1);
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    public IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(2);
        speed = 5;
    }

    public IEnumerator BoostDelay()
    {
        yield return new WaitForSeconds(8);
        speed = 5;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
}
