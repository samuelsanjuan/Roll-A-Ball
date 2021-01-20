using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject looseText;
    public GameObject winText;
    public TextMeshProUGUI countText;
    public float speed = 10;
    public GameObject player;
    private int count;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public int monedas;

    void Start()
    {
        rb =GetComponent<Rigidbody>();
        count=0;
        monedas=9;

        SetCountText();
        winText.SetActive(false);
        looseText.SetActive(false);
    }

    void OnMove(InputValue movementValue){

        Vector2 movementVector= movementValue.Get<Vector2>();

        movementX=movementVector.x;
        movementY=movementVector.y;

    }

    void SetCountText(){

        countText.text= "Puntiacion: "+count.ToString();

        if (monedas+count<0){
            looseText.SetActive(true);
            winText.SetActive(false);
        }

        if (monedas<=0&&monedas+count>0){
            winText.SetActive(true);
        }

    }

    void FixedUpdate(){

        Vector3 movement= new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count=count+1;
            monedas=monedas-1;
            SetCountText();
        } 

    }

    void OnCollisionEnter(Collision collision){
    
        if (collision.gameObject.CompareTag("Enemy")){

            player.transform.position=new Vector3(0,3,0);

            count=count-1;
            SetCountText();
        }
    }
}
