using UnityEngine;

public class CameraPanScript : MonoBehaviour
{
    [SerializeField] float targetYPosition = -10f;
    [SerializeField] float panSpeed = 2f;
    Vector2 targetPosition;
    bool panStarted = false;

    void Start()
    {
        targetPosition = new Vector2(transform.position.x, targetYPosition);
        panStarted = true;
        Debug.Log("ooh i ran!");
    }

    void Update()
    {
        if (panStarted)
        {
            float step = panSpeed * Time.deltaTime;
            transform.position += new Vector3(0, -step, 0);
            /*if (Mathf.Approximately(transform.position.y, targetYPosition))
            {
                panStarted = false;
            }*/

            if(transform.position.y < targetYPosition)
            {
                panStarted = false;
            }


        }
    }
}
