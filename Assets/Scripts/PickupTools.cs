using UnityEngine;

public class Axe : InteractionAnimator
{
    public Transform handTransform; // Assign this in the inspector with the player's hand transform

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Implements IInteractable to attach the axe to the player's hand
    public override void Interact(Animator anim)
    {
        // Animate(); // Uncomment or implement as needed
        InUse = true;
        AttachToHand();
    }

    void AttachToHand()
    {
        if (handTransform != null)
        {
            // Set the Axe's parent to the hand transform
            this.transform.SetParent(handTransform);

            // Reset local position and rotation if needed
            this.transform.localPosition = new Vector3(0.765f, 0.153f, 0.603f);
            this.transform.localRotation = Quaternion.Euler(-19.782f, -131.002f, 63.631f);

            // Optionally, disable physics if the chest has any Rigidbody to prevent unexpected physics behaviour
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Make Rigidbody not be affected by physics
            }
        }
        else
        {
            Debug.LogError("HandTransform is not assigned. Please assign the player's hand transform to the chest.");
        }
    }
}
