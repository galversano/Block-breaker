using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloack : MonoBehaviour {

    [SerializeField] AudioClip clip;
    [SerializeField] GameObject SparkBlock;
    [SerializeField] int timesHits;
    [SerializeField] Sprite[] SpriteHits;
    //
    Level level;
    private void Start()
    { 
        level = FindObjectOfType<Level>();
        if (tag == "BreakAble")
        {
            level.CounterBlock();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "BreakAble")
        {
            int maxHits= SpriteHits.Length+1;
            timesHits++;
            if (timesHits >= maxHits)
            {
                DestroyBlocks();
            }
            else
            {
                ShowNextScene();
            }
        }
    }
    private void ShowNextScene()
    {
        int spriteindex = timesHits-1;
        if (SpriteHits[spriteindex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = SpriteHits[spriteindex];
        }
        else
        {
            Debug.LogError("Block sprite is missing error" + gameObject.name);
        }
    }
    private void DestroyBlocks()
    {
        FindObjectOfType<GameStatus>().AddScore();
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparkVFX();
    }
    private void TriggerSparkVFX()
    {
        GameObject sparkels = Instantiate(SparkBlock, transform.position, transform.rotation);
        Destroy(sparkels, 2f);
    }
    
 
}
