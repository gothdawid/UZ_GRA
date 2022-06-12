using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResolutionList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Utw�rz list� rozdzielczo�ci
        Resolution[] resolutions = Screen.resolutions;

        // Znajd� duplikaty w li�cie rozdzielczo�ci i usu� je z listy rozdzielczo�ci 
        List<Resolution> uniqueResolutions = new List<Resolution>();
        foreach (Resolution resolution in resolutions)
        {
            if (!uniqueResolutions.Contains(resolution))
            {
                uniqueResolutions.Add(resolution);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pobierz dost�pne rozdielczo�ci
    // Zwr�� list� rozdzielczo�ci
    // https://docs.unity3d.com/ScriptReference/Screen-resolutions.html
    
    

}
