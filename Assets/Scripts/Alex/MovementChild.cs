using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChild : MonoBehaviour
{
    public AnimationCurve animCurve;
    public float movementDuration;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void MoveChild(int state)
    {
        Debug.Log("Move Child");
        StartCoroutine(MoveChildCor(state));
    }
    public IEnumerator MoveChildCor(int state)
    {
        canMove = false;
        float startValue = transform.position.x;
        float childX;
        float endValue = DadsScript.dadsManager.dadsBunnies[state].position.x;
        float elapsed = 0.0f;
        float ratio = 0.0f;
        while (elapsed < movementDuration)
        {
            ratio = elapsed/ movementDuration;
            childX = Mathf.Lerp(startValue, endValue, animCurve.Evaluate(ratio));
            transform.position = new Vector3(childX, transform.position.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(movementDuration);
        canMove = true;
    }
}
