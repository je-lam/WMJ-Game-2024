using UnityEngine;
using System.Collections;

public class SquashAndStretch : MonoBehaviour
{
    [Header("Ground Detection")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    [Header("Squash and Stretch Settings")]
    public float squashFactor = 0.8f; // Scale factor when squashing (e.g., 0.8 means 80% of original height)
    public float stretchFactor = 1.2f; // Scale factor when stretching (e.g., 1.2 means 120% of original height)
    public float transitionSpeed = 5f; // Speed of the transition

    [Header("Particle System Settings")]
    public ParticleSystem groundParticleSystem;

    private Vector3 originalScale;
    private bool isGrounded;
    private bool wasGrounded;
    private Rigidbody2D rb;

    void Start()
    {
        // Store the original scale of the character
        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the character is grounded
        bool previouslyGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && !previouslyGrounded)
        {
            // Apply squash and stretch effect on landing
            StopAllCoroutines();
            StartCoroutine(SquashAndStretchEffect());

            // Play particle system on landing
            if (groundParticleSystem != null && !groundParticleSystem.isPlaying)
            {
                groundParticleSystem.Play();
            }
        }
        else if (!isGrounded && previouslyGrounded)
        {
            // Stop particle system when leaving the ground
            if (groundParticleSystem != null && groundParticleSystem.isPlaying)
            {
                groundParticleSystem.Stop();
            }
        }

        // Stop particle system if speed is 0
        if (groundParticleSystem != null && rb.linearVelocity.magnitude == 0 && groundParticleSystem.isPlaying)
        {
            groundParticleSystem.Stop();
        }

        // Update wasGrounded
        wasGrounded = isGrounded;
    }

    private IEnumerator SquashAndStretchEffect()
    {
        Vector3 targetScale = new Vector3(originalScale.x * stretchFactor, originalScale.y * squashFactor, originalScale.z);
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        transform.localScale = targetScale;

        // Return to original scale
        while (Vector3.Distance(transform.localScale, originalScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * transitionSpeed);
            yield return null;
        }
        transform.localScale = originalScale;
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
