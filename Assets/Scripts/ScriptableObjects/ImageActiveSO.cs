using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "imageActive", menuName = "SO/imageActive")]
public class ImageActiveSO : ScriptableObject
{
    private Image image;
    public void ActivateImage(bool activate)
    {
        image = FindObjectOfType<ImageDialog>().GetComponent<Image>();
        image.enabled = activate;
    }
}
 