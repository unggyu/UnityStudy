using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float shotVelocity;
    public float shotAngle;

    private Rigidbody2D ballRB2D;
    private bool isGround = true;
    private bool isCenter = false;
    private float totalTime = 0f;

    void Start()
    {
        ballRB2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShotBall());
        }
    }
    IEnumerator ShotBall()
    {
        Debug.Log("=== Simulation ===");

        isGround = false;
        transform.right = new Vector2(Mathf.Cos(shotAngle * Mathf.Deg2Rad), Mathf.Sin(shotAngle * Mathf.Deg2Rad));
        ballRB2D.velocity = transform.right * shotVelocity;

        totalTime = 0f;
        while (true)
        {
            yield return null;
            if (isGround) break;
            totalTime += Time.deltaTime;
            if (Mathf.Abs(ballRB2D.velocity.y) < 0.1f && !isCenter)
            {
                isCenter = true;
                Debug.Log("CenterHeight: " + transform.position.y);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D _col)
    {
        if(isGround == false)
        {
            isGround = true;
            ballRB2D.velocity = Vector2.zero;
            Debug.Log("Totaltime: " + totalTime);
            Debug.Log("TotalMeter: " + (transform.position.x + 8));

            Verification();
        }
    }

    private void Verification()
    {
        Debug.Log("=== Verification ===");

        float totalTime = 2 * shotVelocity * Mathf.Sin(shotAngle * Mathf.Deg2Rad) / 9.81f;
        // 총 걸린 시간은 2t
        // 2*V*sin(theta)/g
        float centerHeight = Mathf.Pow(shotVelocity * Mathf.Sin(shotAngle * Mathf.Deg2Rad), 2) / (2 * 9.81f);
        // (V*sin(theta))^2/2g
        float totalMeter = Mathf.Pow(shotVelocity,2) / 9.81f * Mathf.Sin(2 * shotAngle * Mathf.Deg2Rad);
        // 총 날아간 거리
        // 2*V^2*sin(theta)*cos(theta)/g => 2sin(theta)cos(theta) == sin(2theta)
        // v^2/g*sin(2*theta)

        Debug.Log("Totaltime: " + totalTime);
        Debug.Log("CenterHeight: " + centerHeight);
        Debug.Log("TotalMeter: " + totalMeter);
    }
}
