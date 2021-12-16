using UnityEngine;

public class ObjectController: MonoBehaviour
{
    public Transform ObjectParent;

    GameObject[] objects;
    int currentObjectIndex;

    GameObject spawnedObject;

    void Start()
    {
        objects = Resources.LoadAll<GameObject>("Input");

        ChangeObject(0);
    }

    public void ChangeObject(int shift)
    {
        if (objects.Length == 0)
            return;

        if(spawnedObject != null)
            Destroy(spawnedObject);

        if (currentObjectIndex + shift < 0)
        {
            currentObjectIndex = objects.Length - 1;
        }
        else
        {
            currentObjectIndex = (currentObjectIndex + shift) % objects.Length;
        }

        spawnedObject = Instantiate(objects[currentObjectIndex], ObjectParent);
        spawnedObject.AddComponent<ObjectRotation>();
    }
}
