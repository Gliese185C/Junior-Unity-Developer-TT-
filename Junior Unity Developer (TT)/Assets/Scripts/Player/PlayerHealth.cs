using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public float delayTime = 3f;
    
    public string firstLevelDied;
    public float dieForce = 15.0f;
    Ragdoll ragdoll;
    ActiveWeapon weapons;
    CharacterAiming aiming;
    VolumeProfile postProcessing;
    CameraManager cameraManager;

    protected override void OnStart() {
        ragdoll = GetComponent<Ragdoll>();
        weapons = GetComponent<ActiveWeapon>();
        aiming = GetComponent<CharacterAiming>();
        postProcessing = FindObjectOfType<Volume>().profile;
        cameraManager = FindObjectOfType<CameraManager>();
  
    }

    protected override void OnDeath(Vector3 direction) {
        ragdoll.ActivateRagdoll();
        StartCoroutine(DelayCoroutine());
        direction.Normalize();
        direction.y = 1.0f;
        ragdoll.ApplyForce(direction * dieForce);
        weapons.DropWeapon();
        aiming.enabled = false;
        cameraManager.EnableKillCam();
    }

    protected override void OnDamage(Vector3 direction) {
        Vignette vignette;
        if (postProcessing.TryGet(out vignette)) {
            float percent = 1.0f - (currentHealth / maxHealth);
            vignette.intensity.value = percent * 0.6f;
        }
    }

    public void PlayAgainFirstLevel()
    {
        SceneManager.LoadScene(firstLevelDied);
    }

    IEnumerator DelayCoroutine()
    {
        // Ждем указанное количество секунд
        yield return new WaitForSeconds(delayTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Progress.lose += 1;
        SaveData();
        PlayAgainFirstLevel();
    }

    public void SaveData()
    {
        PlayerScore data = new PlayerScore();
        data.Win = Progress.win;
        data.Lose = Progress.lose;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/Score.json", json);
    }
}
