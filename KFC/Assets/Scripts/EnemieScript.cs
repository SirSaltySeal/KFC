using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieScript : MonoBehaviour
{
    public float MaxSpeed;
    private float Speed;

    private Collider[] hitCollider;
    private RaycastHit Hit;

    public float SightRange;
    public float DetectionRagne;

    public Rigidbody rb;
    public GameObject Target;

    private bool seePlayer;

    public float Damage;
    //public float KOTime;

    private bool CanAttack;
    //private bool CanAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        Speed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        ///Detect player in range and follow the player
        if (!seePlayer)
        {
            hitCollider = Physics.OverlapSphere(transform.position, DetectionRagne);
            foreach (var HitCollider in hitCollider)
            {
                if(HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;
                }
            }    
        }
        else
        {
            if(Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if(Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    ///Calclate the direction
                    var Heading = Hit.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direction = Heading / Distance;


                    Vector3 Move = new Vector3(Direction.x * Speed, 0, Direction.z * Speed);
                    rb.velocity = Move;
                    transform.forward = Move;
                }
            }
        }
    }
    /// <summary>
    /// When enemie touch the player, it will damage the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("Taking Dmg");
            collision.collider.gameObject.GetComponent<Player>().TakeDamage(Damage);
            //StartCoroutine(AttackDelay(KOTime));
        }
    }

    ///Attack delay after each hit
    //public IEnumerable AttackDelay(float Delay)
    //{
    //    Speed = 0;
    //    CanAttack = false;
    //    yield return new WaitForSeconds(Delay);
    //    Speed = MaxSpeed;
    //    CanAttack = true;
    //}
}
