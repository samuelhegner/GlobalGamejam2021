using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerTractorBeam beam;
    [SerializeField] private AudioSource engineSource;
    [SerializeField] private AudioSource tractorBeamSource;


    void Start()
    {
        
    }

    void Update()
    {
        engineSource.pitch = FloatExtensions.Map(movement.movement.magnitude, 0, 0.25f, 1, 3f);

        if (beam.tractorBeamOn)
        {
            if (!tractorBeamSource.isPlaying)
                tractorBeamSource.Play();
        }
        else 
        {
            if (tractorBeamSource.isPlaying)
                tractorBeamSource.Stop();
        }
    }
}
