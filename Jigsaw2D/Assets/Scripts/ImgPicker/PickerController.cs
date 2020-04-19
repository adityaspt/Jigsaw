using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Kakera
{
    public class PickerController : MonoBehaviour
    {
        public GameObject thesprite;
        [SerializeField]
        private Unimgpicker imagePicker;

        [SerializeField]
        private MeshRenderer imageRenderer;

        [SerializeField]
        private Dropdown sizeDropdown;

        private int[] sizes = {1024, 256, 16};

        void Awake()
        {
            imagePicker.Completed += (string path) =>
            {
                StartCoroutine(LoadImage(path, imageRenderer));// thesprite.GetComponent<SpriteRenderer>().sprite));
            };
        }

        public void OnPressShowPicker()
        {
            imagePicker.Show("Select Image", "unimgpicker", 256 /* sizes[sizeDropdown.value] */);
        }

        private IEnumerator LoadImage(string path, /*Sprite output */ MeshRenderer output )
        {
            var url = "file://" + path;
            var www = new WWW(url);
            yield return www;

            var texture = www.texture;
            if (texture == null)
            {
                Debug.LogError("Failed to load texture url:" + url);
            }
           // Rect rec = new Rect(0, 0, texture.width, texture.height);
            // output = texture;
            output.material.mainTexture = texture;
            //output = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 256);
        
        }
    }
}