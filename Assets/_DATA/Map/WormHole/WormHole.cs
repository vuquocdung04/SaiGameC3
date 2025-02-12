using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : LoadAutoComponents
{
    protected string sceneName = "GalaxyDemo";

    private void OnMouseDown()
    {
        LoadGalaxy();
    }


    protected virtual void LoadGalaxy()
    {
        SceneManager.LoadScene(sceneName);
    }
}
