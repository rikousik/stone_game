using UnityEngine;


public class PlayerPrefsHandler
{
	
	#region PlayerPrefs keys
	public const string VOL_INT = "vol";
	public const string VOLUME_F = "volume";
	#endregion
	private const bool DEBUG_ON = true;
	float volpm = 0.16666666666666666666666666666667f;

	public void RestorePreferences(int level)
	{
	//	SetMuted(GetIsMuted());
	//	SetVolume(GetVolume());
		for(int i=1;i<level;i++){
		SetLevel(i,GetLevel(i));
	}
	}

	/// <summary>
	/// Sets the AudioListener to be (un)muted and saves the value to player prefs.
	/// </summary>
	/// <param name="muted">Whether we should mute or not.</param>
/*	public void SetMuted(bool muted)
	{
		// Set the MUTE_INT key to 1 if muted, 0 if not muted
		PlayerPrefs.SetInt(MUTE_INT, muted ? 1 : 0);

		// Pausing the AudioListener will disable all sounds.
		AudioListener.pause = muted;

		if (DEBUG_ON)
			Debug.LogFormat("SetMuted({0})", muted);
	}

	/// <summary>
	/// Reads from PlayerPrefs to tell us if we should mute or not.
	/// </summary>
	/// <returns>Whether the MUTE_INT pref has been set to 1 or not.</returns>
	public bool GetIsMuted()
	{
		// If the value of the MUTE_INT key is 1 then sound is muted, otherwise it is not muted.
		// The default value of the MUTE_INT key is 0 (i.e. not muted).
		return PlayerPrefs.GetInt(MUTE_INT, 0) == 1;
	}
*/
	/// <summary>
	/// Sets the volume on the AudioListener and saves the value to PlayerPrefs.
	/// </summary>
	/// <param name="volume">A value between 0 and 1</param>
	public void SetVolume(int volint)
	{ 	
		float volume = volint * volpm;
		// Prevent values less than 0 and greater than 1 from
		// being stored in the PlayerPrefs (AudioListener.volume expects a value between 0 and 1).
		volume = Mathf.Clamp(volume, 0, 1);
	//	PlayerPrefs.SetInt (VOL_INT, volint);
		PlayerPrefs.SetFloat(VOLUME_F, volume);
		AudioListener.volume = volume;
	}

	public void SetLevel(int level, int stars)
	{	
		PlayerPrefs.SetInt ("level"+level, stars);
		}
	public int GetLevel(int level){
		return PlayerPrefs.GetInt ("level"+level,0);
	}
	/// <summary>
	/// Retrieves the stored or default (1) volume from PlayerPrefs
	/// and ensures it is no less than 0 and no greater than 1
	/// </summary>
	/// <returns>The volume setting between 0 and 1</returns>
	public int GetVolume()
	{	 return (int)Mathf.Round(PlayerPrefs.GetFloat(VOLUME_F,0)/volpm);
		
	}

}
