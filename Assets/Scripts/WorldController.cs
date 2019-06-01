using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldController : MonoBehaviour
{
	private int EN_COUNT;
    public int NEXT_SCENE;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
    	if(EN_COUNT <= 0)
        {
            //move on to the next level
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(NEXT_SCENE);
    }

    //called by enemies to register themselves
    public void RegisterEnemy(){
    	EN_COUNT++;
    }
    public void EnemyDead(){
    	EN_COUNT--;
    }
}
