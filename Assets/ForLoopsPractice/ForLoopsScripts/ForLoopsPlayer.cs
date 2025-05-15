using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForLoopsPlayer : MonoBehaviour
{
    private float horizontalInput;
    public GameObject wand;
    public float wandRotateSpeed;
    public Transform projectileSpawn;
    public GameObject projectilePrefab;
    public TextMeshProUGUI messageDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the wand
        horizontalInput = Input.GetAxis("Horizontal");
        wand.transform.Rotate(Vector3.back * horizontalInput * wandRotateSpeed * Time.deltaTime);

    }

    public void Shoot()
    {
        Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
    }

    public void Shoot(GameObject prefab)
    {
        Instantiate(prefab, projectileSpawn.position, projectileSpawn.rotation);
    }

    public void Message(string message)
    {
        messageDisplay.text = message;
    }
}
