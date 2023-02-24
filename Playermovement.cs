using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour
{   
    public GameObject pauseMenuScreen;
    public float maxDrad = 4f;
    public float power = 8f;
    public Rigidbody2D rb;
    public LineRenderer lr;



    [SerializeField] private AudioSource dragSoundEffect;

    Vector3 dragStartPositon;
    bool dragging = false;

    public void Start()
    {
        Time.timeScale= 1f;
    }

    void Update()
    {
        if(dragging == true)
        {
            
            Vector3 draggingPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            draggingPosition.z = 0;
            

            Vector3 finalDraggingposition = 2 * dragStartPositon - draggingPosition;

            lr.positionCount = 2;
            lr.SetPosition(1, finalDraggingposition);
            
        }

        if(dragging == false && Input.GetMouseButtonDown(0))
        {
           dragStartPositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           dragStartPositon.z = 0;

           dragging = true;

           lr.positionCount = 1;
           lr.SetPosition(0, dragStartPositon);

        }

        if (Input.GetMouseButtonUp(0))
        {
            dragSoundEffect.Play();
            lr.positionCount = 0;
            dragging = false;

            Vector3 dragReleasePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 force = dragStartPositon - dragReleasePosition;
            Vector3 clampedforce = Vector3.ClampMagnitude(force, maxDrad) * power;

            if(rb.velocity.magnitude >=0 && rb.velocity.magnitude <= 0.5f)
            {
                rb.AddForce(clampedforce, ForceMode2D.Impulse);
            }
        }
    } 

    public void Pausegame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}