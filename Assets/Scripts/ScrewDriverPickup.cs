using UnityEngine;

public class ScrewDriver : MonoBehaviour
{
    private Transform PickUpPoint;
    private Transform player;
    public  float PickUpdistance;
    public  float ForceMulti;
    public GameObject contextPrompt;

    public bool ReadyToThrow;
    public bool itemIsPicked;
    private Rigidbody RB;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        player = GameObject.Find("Eldric Player").transform;
        PickUpPoint = GameObject.Find("PickUpPoint").transform;
        //anim = GetComponent<Animator>();
    }

    // //Implements IInteractable to open chest
    //public override void Interact(Animator anim)
    //{
    //    // Animate();
    //    InUse = true;
        
    //}

    public void Update()
    {
        if (Input.GetKey(KeyCode.M) && itemIsPicked == true && ReadyToThrow)
        {
            
            ForceMulti += 300 * Time.deltaTime;
        }

        PickUpdistance = Vector3.Distance(player.position, transform.position);

        if (PickUpdistance <= 15)
        {
            if (Input.GetKeyDown(KeyCode.M) && itemIsPicked == false && PickUpPoint.childCount < 1)

            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = PickUpPoint.position;
                this.transform.parent = GameObject.Find("PickUpPoint").transform;

                itemIsPicked = true;
                ForceMulti = 0;
            }
            
        }

            if (Input.GetKeyUp(KeyCode.M) && itemIsPicked == true)

            {
                ReadyToThrow = true;
                if (ForceMulti > 20)

                {
                    RB.AddForce(player.transform.forward * ForceMulti);
                    this.transform.parent = null;
                    GetComponent<Rigidbody>().useGravity = true;
                    GetComponent<BoxCollider>().enabled = true;
                    itemIsPicked = false;
                    ForceMulti = 0;
                    ReadyToThrow = false;

                }
                ForceMulti = 0;
            

              
            }
        
    }

}

