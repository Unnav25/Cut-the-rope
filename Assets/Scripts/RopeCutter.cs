using UnityEngine;
public class RopeCutter : MonoBehaviour
{
    private Vector2 lastMousePos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePos =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D[] hits =
                Physics2D.LinecastAll(lastMousePos, currentMousePos);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.CompareTag("Rope") || hit.collider.CompareTag("Rope2")||hit.collider.CompareTag("Rope1"))
                {
                    HingeJoint2D joint =
                        hit.collider.GetComponent<HingeJoint2D>();

                    if (joint != null)
                    {
                        
                        Destroy(joint);
                       Transform ropeParent = hit.collider.transform.parent;

                        if (ropeParent != null)
                        {
                            Destroy(ropeParent.gameObject, 1f);
                        }
                        }

                    break;
                }
            }

            lastMousePos = currentMousePos;
        }
    }
}