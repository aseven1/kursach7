using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetTextToObjectName : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToName;
    public Text nameText;
    public int leng;
    void Start()
    {
        if (objectToName != null)
        {
            TextMesh textMesh = GetComponent<TextMesh>();
            if (textMesh != null)
            {
                textMesh.text = objectToName.name;
            }
        }
        if(objectToName.name.Length==0)
        {
          Destroy(this.gameObject);
        }
        leng=objectToName.name.Length;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
