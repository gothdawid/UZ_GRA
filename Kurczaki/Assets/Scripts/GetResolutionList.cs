using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResolutionList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Utwórz listê rozdzielczoœci
        Resolution[] resolutions = Screen.resolutions;

        // ZnajdŸ duplikaty w liœcie rozdzielczoœci i usuñ je z listy rozdzielczoœci 
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

    // Pobierz dostêpne rozdielczoœci
    // Zwróæ listê rozdzielczoœci
    // https://docs.unity3d.com/ScriptReference/Screen-resolutions.html
    
    

}
