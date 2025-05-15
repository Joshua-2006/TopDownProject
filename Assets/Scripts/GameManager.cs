using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Movement player;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Movement>();
        player.health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
