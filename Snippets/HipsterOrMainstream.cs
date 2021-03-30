using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipsterOrMainstream : MonoBehaviour
{
    public bool isHipster;
    public bool isMainstream;
   public float time = 0.0f;
    public CircleCollider2D spreadRange;
    public SpriteRenderer trend;
    public Color HipsterColor;
    public Color MainstreamColor;
    public GameObject person;
    public int chooser;
    public WorldManager WM;
    public int chooser2;
    public bool isConformist;
    public bool isNonConformist;
    

    void Start()
    {
        chooser2 = Random.Range(0, 100);
        
        spreadRange.radius = 0.01f;
        //color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 255);
        //trend.color = color;
        chooser = Random.Range(0, 100);
        if (chooser2 <= 50)
        {
            isConformist = true;
            isNonConformist = false;
        }
        else
        {
            isNonConformist = true;
            isConformist = false;
        }
        
        if(chooser <= 50)
        {
            this.gameObject.tag = "Hipster";
            isHipster = true;
            isMainstream = false;
        }
        else
        {
            this.gameObject.tag = "Mainstream";
            isMainstream = true;
            isHipster = false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += 0.1f;
        if(isHipster == true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = HipsterColor;
            this.gameObject.tag = "Hipster";
            isMainstream = false;
        }
        if(isMainstream ==true)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = MainstreamColor;
            this.gameObject.tag = "Mainstream";
            isHipster = false;
            isMainstream = true;
        }

       
        
    }
    
   void OnTriggerEnter2D(Collider2D other)
    {
        
        if (time >= 10.0f)
        {
            if (other.CompareTag("Mainstream") || other.CompareTag("Hipster") && (this.gameObject.tag == "Hipster" && WM.isMainstreamWorld==true && isNonConformist==true)==true)
            {

                this.isHipster = true;
                this.isMainstream = false;
                
            }
            else if (other.CompareTag("Hipster") || other.CompareTag("Mainstream") && (this.gameObject.tag == "Mainstream" && WM.isMainstreamWorld==true && isNonConformist==true)==true)
            {

                this.isHipster = true;
                this.isMainstream = false;

            }
            else if (other.CompareTag("Hipster") || other.CompareTag("Mainstream") && (this.gameObject.tag == "Hipster" && WM.isMainstreamWorld==true && isConformist==true)==true)
            {

                this.isMainstream = true;
                this.isHipster = false;

            }
            else  if (other.CompareTag("Hipster") || other.CompareTag("Mainstream") && (this.gameObject.tag == "Mainstream" && WM.isMainstreamWorld==true && isConformist==true)==true)
            {

                this.isMainstream = true;
                this.isHipster = false;

            }
           else if (other.CompareTag("Hipster") || other.CompareTag("Mainstream") && (this.gameObject.tag == "Hipster" && WM.isHipsterWorld==true && isNonConformist==true)==true)
            {

                this.isMainstream = true;
                this.isHipster = false;

            }
            else  if (other.CompareTag("Hipster") || other.CompareTag("Mainstream") && (this.gameObject.tag == "Mainstream" && WM.isHipsterWorld==true && isNonConformist==true)==true)
            {

                this.isMainstream = true;
                this.isHipster = false;

            }
           else if (other.CompareTag("Hipster") || other.CompareTag("Mainstream") && (this.gameObject.tag == "Hipster" && WM.isHipsterWorld==true && isConformist==true)==true)
            {

                this.isHipster = true;
                this.isMainstream = false;

            }
            else if (other.CompareTag("Hipster") || other.CompareTag("Mainstream") && (this.gameObject.tag == "Mainstream" && WM.isHipsterWorld==true && isConformist==true)==true)
            {

                this.isHipster = true;
                this.isMainstream = false;
            }
        }
    }
}