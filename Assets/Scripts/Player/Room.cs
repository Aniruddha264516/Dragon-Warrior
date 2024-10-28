
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] enemeies;
    private Vector3[] initialposition;

    private void Awake()
    {
        initialposition = new Vector3[enemeies.Length];
        for (int i = 0; i < enemeies.Length; i++)
        {
            if (enemeies[i] != null)
                initialposition[i] = enemeies[i].transform.position;
        }
    }

    public void ActiveRoom(bool _status)
    {
        for (int i = 0;i < enemeies.Length;i++)
        {
            enemeies[i].SetActive(true);
            enemeies[i].transform.position = initialposition[i];
        }
    }
}
