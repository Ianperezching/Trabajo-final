using UnityEngine;

public class NodeController : MonoBehaviour
{

    public SimplyLinkedList<NodeController> adjacentNodes;
    public Vector3 position;
    public int nodeTag;

    void Awake()
    {
        adjacentNodes = new SimplyLinkedList<NodeController>();
    }

    public void SetInitialValues(Vector3 position, int nodeTag)
    {
        this.position = position;
        transform.position = new Vector3(position.x, 0.2f, position.z);
        this.nodeTag = nodeTag;
    }

    public void AddAdjacentNode(NodeController node)
    {
        adjacentNodes.InsertNodeAtEnd(node);
    }

    public NodeController GetNextNode()
    {
        if (adjacentNodes.length == 0)
            return null;

        float minDistance = float.MaxValue;
        NodeController closestNode = null;

        for (int i = 0; i < adjacentNodes.length; i++)
        {
            NodeController adjacentNode = adjacentNodes.ObtainNodeAtPosition(i);
            float distance = Vector3.Distance(transform.position, adjacentNode.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestNode = adjacentNode;
            }
        }

        return closestNode;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            NodeController nextNode = GetNextNode();
            if (nextNode != null)
            {
                other.GetComponent<EnemyPatrol>().ChangeMovePosition(nextNode.transform.position);
            }
        }
    }
}
