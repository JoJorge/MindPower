using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    #region Variables
    [SerializeField] private MagicMissle.MagicType nowMagicType;
    private bool controllable;
    [SerializeField] private MagicController magicController;
    [SerializeField] private GameObject fireOrb;
    [SerializeField] private GameObject iceOrb;
    private GameObject nowOrb;
    #endregion

    #region Behaviours
    void Start () {
        Debug.Assert (magicController != null);
        controllable = true;
        if (nowMagicType == MagicMissle.MagicType.Fire) {
            nowOrb = fireOrb;
        }
        else {
            nowOrb = iceOrb;
        }
        nowOrb.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
        if (controllable) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                nowOrb.transform.Find ("Orb").gameObject.SetActive(true);
                magicController.startReading ();
            }
            if (Input.GetKeyUp (KeyCode.Space)) {
                nowOrb.transform.Find ("Orb").gameObject.SetActive(false);
                magicController.endReading ();
            }
            if (Input.GetKeyDown (KeyCode.X)) {
                switchMagicType ();
            }
        }
	}
    #endregion

    #region Functions
    public void startControl() {
        controllable = true;
    }
    public void stopControl() {
        controllable = false;
        if (magicController.isReading ()) {
            magicController.endReading ();
        }
    }
    protected void switchMagicType() {
        if (magicController.isReading ()) {
            return;
        }
        if (nowMagicType == MagicMissle.MagicType.Fire) {
            nowOrb.SetActive (false);
            nowMagicType = MagicMissle.MagicType.Ice;
            nowOrb = iceOrb;
        }
        else {
            nowOrb.SetActive (false);
            nowMagicType = MagicMissle.MagicType.Fire;
            nowOrb = fireOrb;
        }
        nowOrb.SetActive (true);
    }
    #endregion
}
