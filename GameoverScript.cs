using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour

{
    //[SerializeField] private AudioSource overSoundEffect;
    public void OnCollisionEnter2D(Collision2D col)
    {
        
    if (col.gameObject.tag =="Circle")
    {   
        //overSoundEffect.Play();
        Debug.Log("collision occurs");
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }
        
    }
}
