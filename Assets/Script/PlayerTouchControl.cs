using UnityEngine;

public class PlayerTouchControl : MonoBehaviour
{
    public Transform player;
    public Transform pauseMenu;
    public Transform weaponObject;
    Player2DControl playerControl;
    PistolWeapon pWeapon;
    private void Start()
    {
        playerControl = player.GetComponent<Player2DControl>();
        pWeapon = weaponObject.GetComponent<PistolWeapon>();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void GoLeft()
    {
        playerControl.move = -1f;
    }

    public void GoRigt()
    {
        playerControl.move = 1f;
    }

    public void StopMoving()
    {
        playerControl.move = 0;
    }

    public void Jump()
    {
        playerControl.Jump();
    }

    public void Shoot()
    {
        pWeapon.Shoot();
    }
}
