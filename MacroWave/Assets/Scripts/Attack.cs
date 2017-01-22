using Application;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public GameObject Michael;
    public int speed;
    public bool full = false;
    public GameObject held;
    bool hungry = false;
    public Rigidbody2D body;
    public CookingEventMaster cook;
    public Health life;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!full)
            {
                var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                hungry = true;
                if (transform.position == target)
                {
                    hungry = false;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (hungry)
        {
            held = other.gameObject;
            Destroy(other.gameObject);
            full = true;
            transform.position = transform.position;
            hungry = false;
            //call QTE script
            cook.Activate(10);
        }
        else
        {
            //call get hurt script
            life.takeHealth(1);
        }
    }
}
