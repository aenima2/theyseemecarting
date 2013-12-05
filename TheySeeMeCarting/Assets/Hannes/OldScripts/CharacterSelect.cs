using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour
{

    [HideInInspector]
    public int CharacterIndex;
    [HideInInspector]
    public GameObject CharacterSelected;
    public GameObject[] CharactersAvailable;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
