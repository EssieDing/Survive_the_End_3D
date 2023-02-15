using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 100f;               // The amount of health each tank starts with.
    public Slider healthSlider;                       // The slider to represent how much health the tank currently has.
    public Image fillImage;                           // The image component of the slider.
    public Color fullHealthColor = Color.green;       // The color the health bar will be when on full health.
    public Color zeroHealthColor = Color.red;         // The color the health bar will be when on no health.
    public int num_life = 100;                        
    public Vector3 int_pos;

    // Stamina
    public float startingStamina = 100f;     
    public Slider staminaSlider;                       
    public Image fillImage2;                           
    public Color fullStaminaColor = Color.blue;       
    public Color zeroStaminaColor = Color.white;         
    public int num_stamina = 100;                        
   // public Vector3 int_pos;


    private static float currentHealth;                 // How much health the tank currently has.
    private static float currentStamina;
    private static bool isDead;                                // Has the tank been reduced beyond zero health yet?


    private void OnEnable()
    {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        currentHealth = startingHealth;
        currentStamina = startingStamina;
        
        isDead = false;
        int_pos = transform.position;

        // Update the health slider's value and color.
        SetHealthUI();
        SetStaminaUI();
    }


    public void TakeDamage(float amount)
    {
        // change according to hurt stats
        currentHealth -= amount;

        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (currentHealth <= 0f && !isDead)
        {
            AppManager.gameEnd = true;
            Time.timeScale = 0;
            if (num_life > 0) {
                num_life--;
                currentHealth = startingHealth;
                SetHealthUI();
                transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                transform.position = int_pos;
            } else {
                OnDeath();
            }
        }
    }

    public void TakeRun(float amount)
    {
        // change according to hurt stats
        currentStamina -= amount;

        SetStaminaUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        // if (currentHealth <= 0f && !isDead)
        // {
        //     if (num_life > 0) {
        //         num_life--;
        //         currentHealth = startingHealth;
        //         SetHealthUI();
        //         transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        //         transform.position = int_pos;
        //     } else {
        //         OnDeath();
        //     }
        // }
    }

    public void onAddStamina(float amount){
        if (currentStamina < 100) {
            currentStamina += amount;
        }
        SetStaminaUI();
    }


    private void SetHealthUI()
    {
        // Set the slider's value appropriately.
        healthSlider.value = currentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
    }

    private void SetStaminaUI()
    {
        // Set the slider's value appropriately.
        staminaSlider.value = currentStamina;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        fillImage2.color = Color.Lerp(zeroStaminaColor, fullStaminaColor, currentStamina / startingStamina);
    }


    private void OnDeath()
    {
        // Set the flag so that this function is only called once.
        isDead = true;
        //Debug.Log("dead");
        //AppManager.gameEnd = true;
        gameObject.SetActive(false);
    }
}
