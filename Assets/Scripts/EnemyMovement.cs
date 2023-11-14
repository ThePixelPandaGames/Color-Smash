using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform wheelCenter;
    [HideInInspector] public float moveSpeed;
    Vector2 normDirectionVector;
    [SerializeField] float xDestroy, yDestroy;



    void Start()
    {
        wheelCenter = GameObject.FindGameObjectWithTag("Wheel Center").GetComponent<Transform>();

        if(wheelCenter == null)
        {
            throw new System.Exception("Could not find center of wheel");
        }

        normDirectionVector = GetDirection();
    }

    void Update()
    {
        Move();

        if(Mathf.Abs(transform.position.y) > yDestroy || Mathf.Abs(transform.position.x) > xDestroy)
        {
            Destroy(gameObject);
        }
    }


    private void Move()
    {
        transform.Translate(normDirectionVector * moveSpeed * Time.deltaTime);  
    }


    private Vector2 GetDirection()
    {
        return (wheelCenter.position - transform.position).normalized;   
    }

    
}
