using UnityEngine;

// place first and last elements in children array manually
// other elements will be placed automatically with equal distance betaween first and last elements
public class SameDistanceChildren : MonoBehaviour
{
    public Transform[] children;

    // Use for initialization
    private void Awake()
    {
        Vector3 firstElementPos = this.children[0].transform.position;
        Vector3 lastElementPos = this.children[this.children.Length - 1].transform.position;

        // dividing by last child ( children.Length - 1 ) because for example: between 10 points that are 9 segments
        float xDist = (lastElementPos.x - firstElementPos.x) / (this.children.Length - 1);
        float yDist = (lastElementPos.y - firstElementPos.y) / (this.children.Length - 1);
        float zDist = (lastElementPos.z - firstElementPos.z) / (this.children.Length - 1);

        var dist = new Vector3(xDist, yDist, zDist);

        for (int i = 1; i < this.children.Length; i++)
        {
            this.children[i].transform.position = this.children[i - 1].transform.position + dist;
        }
    }
}
