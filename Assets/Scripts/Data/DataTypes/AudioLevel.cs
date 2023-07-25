namespace Assets.Scripts.Data.DataTypes
{
    public struct AudioLevel
    {
        public float Sound;
        public float Music;

        public AudioLevel(float sound, float music)
        {
            Sound = sound;
            Music = music;  
        }
    }
}
