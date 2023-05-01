using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSM : MonoBehaviour
{
   public void Mail()
    {
        Application.OpenURL("mailto:4366@holbertonstudents.com");
    }
    public void github()
    {
        Application.OpenURL("https://github.com/FerchichiXIII");
    }
    public void Lindin()
    {
        Application.OpenURL("https://www.linkedin.com/in/anas-ferchichi-7b9aa8230/");
    }
    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/FerchichiXIII");
    }
}
