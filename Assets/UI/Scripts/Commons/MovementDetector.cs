using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    [SerializeField]
    private Collider m_colliderPath;

    [SerializeField]
    private Collider m_colliderNode;

    [SerializeField]
    private Collider m_colliderTakeItem;

    [SerializeField]
    private string m_nameObject;

    [SerializeField]
    private bool m_isCollidingPath;

    [SerializeField]
    private bool m_isCollidingPlayer;

    [SerializeField]
    private bool m_isCollidingEnemy;

    [SerializeField]
    private bool m_isCollidingTakeItem;

    [SerializeField]
    private bool m_isCollidingNode;

    private Collider m_collider;

    public bool IsCollidingPath
    {
        get { return m_isCollidingPath; }
    }
    public bool IsCollidingPlayer
    {
        get { return m_isCollidingPlayer; }
    }
    public bool IsCollidingEnemy
    {
        get { return m_isCollidingEnemy; }
    }
    public bool IsCollidingTakeItem
    {
        get { return m_isCollidingTakeItem; }
    }
    public bool IsCollidingNode
    {
        get { return m_isCollidingNode; }
    }

    public Collider Collider
    {
        get { return m_collider; }
    }

    private void Start()
    {
        m_nameObject = gameObject.tag;
    }

    private void OnTriggerEnter(Collider collider)
    {
        m_collider = collider;
        //CheckColliderHandler();
    }

    private void OnTriggerStay(Collider collider)
    {
        m_collider = collider;
        //CheckColliderHandler();
        CheckingCollider();
    }

    private void OnTriggerExit(Collider collider)
    {
        m_collider = collider;
        //CheckColliderHandler(true);
    }

    private void CheckColliderHandler(bool revBool = false)
    {
        m_isCollidingPath = CheckIsCollidedWith("Path", revBool);
        m_isCollidingPlayer = CheckIsCollidedWith("Player", revBool);
        m_isCollidingEnemy = CheckIsCollidedWith("Enemy", revBool);
        m_isCollidingTakeItem = CheckIsCollidedWith("TakeItem", revBool);
        m_isCollidingNode = CheckIsCollidedWith("Node", revBool);
    }

    private bool CheckIsCollidedWith(string nameTag, bool revBool = false)
    {
        if (!revBool)
            return m_collider.CompareTag(nameTag) ? true : false;
        else
            return m_collider.CompareTag(nameTag) ? false : true;
    }

    private void CheckingCollider()
    {
        Debug.Log(m_collider.tag);

        m_isCollidingPath = (m_collider == m_colliderPath) ? true : false;
        m_isCollidingNode = (m_collider == m_colliderNode) ? true : false;
        m_isCollidingTakeItem = (m_collider == m_colliderTakeItem) ? true : false;
    }
}
