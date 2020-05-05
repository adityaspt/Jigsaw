using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Kakera
{
    public class PickerController : MonoBehaviour
    {
        public Image img;
       // public Sprite carryForward;
      //  public RawImage rI;
        public Sprite tsprite;
        [SerializeField]
        private Unimgpicker imagePicker;

        [SerializeField]
        private MeshRenderer imageRenderer;

        public DontDestoryOnLoadScript pickscript;
        //[SerializeField]
        //private Dropdown sizeDropdown;

        private int[] sizes = {1024, 256, 16};

        void Awake()
        {
            imagePicker.Completed += (string path) =>
            {
                StartCoroutine(LoadImage(path, imageRenderer));// thesprite.GetComponent<SpriteRenderer>().sprite));
            };
            //tsprite=pickscript.GetComponent<D>
            
        }

        private void OnLevelWasLoaded(int level)
        {
            if (level == 0)
            {
                img = GameObject.Find("OwnImage").GetComponent<Image>();
               // pickscript.theSprite = null;
            }
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
            Rect rec = new Rect(0, 0, texture.width, texture.height);
            // output = texture;
            //output.material.mainTexture = texture;
            //thesprite.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f),100 /*256*/);
            img.GetComponent<Image>().sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 256);
             //  pickscript.theSprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 256);
            pickscript.theSprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f));
            //rI.texture =texture;
        }
    }
}