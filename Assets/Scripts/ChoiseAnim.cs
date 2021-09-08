using UnityEngine;
using System.Collections;

public class ChoiceAnim : MonoBehaviour
{
    public float HorizontalMoveSpeed = 1.5f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isAnimating = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && isAnimating == false)
        {
            isAnimating = true;
            Debug.Log("A key was pressed.");
            StartCoroutine(AnimationGauche());
        }
    }


    IEnumerator AnimationGauche()
    {
        Vector2 originalVelocity = rb.velocity;
        rb.AddForce(new Vector2(rb.velocity.x, HorizontalMoveSpeed), ForceMode2D.Impulse);
        yield return new WaitForSeconds(2f);
        rb.velocity = originalVelocity;
        Debug.Log("Le pion avance");
    }
}
