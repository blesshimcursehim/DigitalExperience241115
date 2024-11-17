using UnityEngine;

public class UserBoundryCheck : MonoBehaviour
{
    // The Y-coordinate limit below which the player is considered to have fallen
    public float fallLimit = -3f;
    // The position to respawn the player after falling
    public Vector3 respawnPosition = Vector3.zero;

    void Update()
    {
        // Check if the player's Y position is below the fall limit and call the Respawn method
        if (transform.position.y < fallLimit)
            Respawn();
    }

    // Respawns the player at the specified position
    void Respawn()
    {
        // Set the player's position to the respawn point
        transform.position = respawnPosition;
        // Get the Rigidbody component to reset its velocity
        Rigidbody rb = GetComponent<Rigidbody>();
        // If the Rigidbody exists, reset its linear velocity to zero
        if (rb != null)
            rb.linearVelocity = Vector3.zero;
        // Log message to indicate that the player has fallen and respawned
        Debug.Log("Ooopsie! You fell.. you klutz!");
    }
}
