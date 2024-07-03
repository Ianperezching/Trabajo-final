using UnityEngine;

public class Grafos : MonoBehaviour
{
    public SimplyLinkedList<NodeController> nodes;
    public GameObject nodePrefab;
    [SerializeField] Transform parentRefences;

    void Awake()
    {
        nodes = new SimplyLinkedList<NodeController>();
        GenerateWalk();
    }

    void GenerateWalk()
    {
        
        for (int i = 0; i < parentRefences.childCount; i++)
        {
            GameObject nodeObject = Instantiate(nodePrefab, parentRefences.GetChild(i).position, Quaternion.identity, parentRefences);
            AddNode(nodeObject, i);
        }

        AddAdjacentNodes(0, new int[] { 1, 2 });
        AddAdjacentNodes(1, new int[] { 0, 3 });
        AddAdjacentNodes(2, new int[] { 0, 3 });
        AddAdjacentNodes(3, new int[] { 1, 2 });
    }

    void AddNode(GameObject nodeObject, int nodeTag)
    {
        NodeController nodeController = nodeObject.GetComponent<NodeController>();
        nodeController.SetInitialValues(nodeObject.transform.position, nodeTag);
        nodes.InsertNodeAtEnd(nodeController);
    }

    void AddAdjacentNodes(int nodeTag, int[] adjacentTags)
    {
        NodeController node = FindNode(nodeTag);
        if (node != null)
        {
            for (int i = 0; i < adjacentTags.Length; i++)
            {
                NodeController adjacentNode = FindNode(adjacentTags[i]);
                if (adjacentNode != null)
                {
                    node.AddAdjacentNode(adjacentNode);
                }
            }
        }
    }

    NodeController FindNode(int nodeTag)
    {
        for (int i = 0; i < nodes.length; i++)
        {
            NodeController node = nodes.ObtainNodeAtPosition(i);
            if (node.nodeTag == nodeTag)
            {
                return node;
            }
        }
        return null;
    }
}
