using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int counterBlock;

    SceneLoader sceneloader;
    private void  Start() {
        sceneloader = FindObjectOfType<SceneLoader>();
    }   
    public void CounterBlock()
    {
        counterBlock++;
    }
    public void BlockDestroyed()
    {
        counterBlock--;
        if (counterBlock <= 0)
        {
            sceneloader.LoadNextScene();
        }
            
    }
}
