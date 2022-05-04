using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStretch : MonoBehaviour
{
    readonly int INTRO_STEPS_HOLD_1 = 75;

    [SerializeField] GameObject copyright;
    byte state = 0;

    readonly static float[] scaleTable1 = { // 20 of them; used for showing
    0.016000f, 0.052000f, 0.002500f, 0.148300f,
    0.189200f, 0.035200f, 0.471600f, 0.525300f,
    0.116600f, 0.875800f, 0.947000f, 0.222100f,
    1.250500f, 1.341300f, 0.327000f, 1.485400f,
    1.594900f, 0.406500f, 1.230500f, 1.563700f,
    0.464300f, 0.913900f, 1.351300f, 0.520200f,
    1.022900f, 1.216100f, 0.574400f, 1.122300f,
    1.097200f, 0.627000f, 1.028300f, 0.955600f,
    0.678100f, 0.934800f, 1.049400f, 0.727700f,
    0.994200f, 1.005200f, 0.775900f, 1.070200f,
    0.961500f, 0.822900f, 0.995600f, 0.995000f,
    0.868700f, 0.991600f, 1.005700f, 0.913500f,
    1.016500f, 0.985200f, 0.957200f, 0.985200f,
    1.007100f, 1.000000f, 0.999900f, 0.999800f,
    1.010600f, 1.000000f, 1.000000f, 1.000000f,
    };

    // 0x0700C880
    readonly static float[] scaleTable2 = { // 91; used for hiding
    1.000000f, 1.000000f, 1.000000f, 0.987300f,
    0.987300f, 0.987300f, 0.951400f, 0.951400f,
    0.951400f, 0.896000f, 0.896000f, 0.896000f,
    0.824600f, 0.824600f, 0.824600f, 0.740700f,
    0.740700f, 0.740700f, 0.648000f, 0.648000f,
    0.648000f, 0.549900f, 0.549900f, 0.549900f,
    0.450100f, 0.450100f, 0.450100f, 0.352000f,
    0.352000f, 0.352000f, 0.259300f, 0.259300f,
    0.259300f, 0.175400f, 0.175400f, 0.175400f,
    0.104000f, 0.104000f, 0.104000f, 0.048600f,
    0.048600f, 0.048600f, 0.012800f, 0.012800f,
    0.012800f, 0.000000f, 0.000000f, 0.000000f,
    };
    int sIntroFrameCounter = 0;

    void Start()
    {
        // SoundManager.playSoundAtPos(3, 0x11, Vector3.zero, SoundManager.PlaybackFlags.SOUND_NO_VOLUME_LOSS, SoundManager.LowerBitflags.SOUND_DISCRETE);
        Invoke("Transition", 4);
    }

    void FixedUpdate()
    {
        var mr = copyright.GetComponent<MeshRenderer>();
        sIntroFrameCounter += 1;
        if (state == 0)
        {
            if (sIntroFrameCounter >= 15 && mr.material.color.a < 1)
            {

                mr.material.color = new Color(1, 1, 1, mr.material.color.a + (1f / 15f));
            }
            if (sIntroFrameCounter < 20)
                transform.localScale = new Vector3(
                    scaleTable1[sIntroFrameCounter * 3],
                    scaleTable1[sIntroFrameCounter * 3 + 1],
                    scaleTable1[sIntroFrameCounter * 3 + 2]);
            if (sIntroFrameCounter > INTRO_STEPS_HOLD_1)
            {
                state = 1;
            }
        }
        else if (state == 1)
        {
            if (mr.material.color.a > 0)
            {
                mr.material.color = new Color(1, 1, 1, mr.material.color.a - (1f / 15f));
            }
            if (sIntroFrameCounter < 91)
                transform.localScale = new Vector3(
                    scaleTable2[(sIntroFrameCounter - INTRO_STEPS_HOLD_1) * 3],
                    scaleTable2[(sIntroFrameCounter - INTRO_STEPS_HOLD_1) * 3 + 1],
                    scaleTable2[(sIntroFrameCounter - INTRO_STEPS_HOLD_1) * 3 + 2]);
        }
    }

    void Transition()
    {
        SceneManager.LoadScene(1);
    }
}
