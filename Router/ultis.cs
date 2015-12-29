using GiauTM.CSharp.TikiRouter.Properties;
using System.Media;

namespace GiauTM.CSharp.TikiRouter
{
    public static class Ultis
    {
        private static bool playAudio(string name)
        {
            var stream = Resources.ResourceManager.GetStream(name);
            if (stream != null)
            {
                var player = new SoundPlayer(stream);
                player.Play();
                return true;
            }

            return false;
        }

        public static bool playNotFound()
        {
            return playAudio("NOTFOUND");
        }

        public static bool playRouter(string name) {
            var soundName = '_' + name.ToUpper().Replace('-', '_');

            return playAudio(soundName);
        }
    }
}