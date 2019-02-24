﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginWrapper : MonoBehaviour {

    private AndroidJavaObject javaClass;
    public Text myText;
	public Text myText2;



	// Use this for initialization
	void Start () {
		Debug.Log ("Start");
        javaClass = new AndroidJavaObject("com.example.vrlibrary.Keys");
        javaClass.Call("LogNativeAndroidLogcatMessage");
        javaClass.Call("LogNumberSentFromUnity", 76);

		Debug.Log ("Juhu" + javaClass);

        myText.text = javaClass.Call<int>("AddFiveToMyNumber", 4).ToString();

		Physics.IgnoreLayerCollision(8, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
    }


	public void leiser(){
		myText.text = "leiser";
	}

	public void lauter(){
		myText.text = "lauter";
	}


	public GameObject hand;
	public GameObject objectA;
	public Transform objectB;
	public bool angeschaut=false;

	public bool snapallowed;
	Vector3 npos;

	public void greifen(string ok){
		myText.text = "greifen"+ok;

		if ((ok == "1") && (angeschaut == true)) {
			if (hand.transform.childCount == 0) {
				Debug.Log ("yay");	
				objectA.transform.position = objectB.position;
				objectA.transform.parent = objectB;
				objectA.GetComponent<Rigidbody>().useGravity = false;
			}

			}
		else if ((ok == "1")&&(hand.transform.childCount == 1)){
			getpospointer ();

			npos.x = wpos.x;
			npos.z = wpos.z;
			npos.y = wpos.y+0.1f;
			objectA.transform.position = npos;
			hand.transform.DetachChildren ();


			if (snapallowed = true) {
				snap ();
			} else {
				objectA.GetComponent<Rigidbody> ().useGravity = true;
			}
		}
	}

	public GameObject snapzo;
	public GameObject objecttosnap;
	public GameObject planetenbahn;
	public GameObject snappos;
	bool enter=true;

	public void snap(){
		

		objectA.GetComponent<Rigidbody> ().useGravity = true;
		OnTriggerStay (snapzo.GetComponent<SphereCollider> ());

		if (objecttosnap.name == "Sonne") {
			objecttosnap.GetComponent<Rotation> ().isSnappedso = true;
			myText2.text = "Sonne snapped";
		}
		
	}

 void OnTriggerStay(Collider other)
	{
		if (enter) {	
			planetenbahn.GetComponent<SphereCollider> ().enabled = false;
			snappos.GetComponent<SphereCollider> ().enabled = false;
			objecttosnap.transform.position = snappos.transform.position;
			objectA.GetComponent<Rigidbody> ().useGravity = false;

		} else {
			objectA.GetComponent<Rigidbody> ().useGravity = true;
		}
	}

	public void anschauen(){
		angeschaut = true;
	}

	public void wegschauen(){
		angeschaut = false;
	}

	public GameObject pointer;
	public Vector3 wpos;

	public void getpospointer(){
		wpos = pointer.GetComponent<GvrReticlePointer> ().CurrentRaycastResult.worldPosition;
	
	}



}
