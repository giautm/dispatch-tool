using GiauTM.CSharp.TikiRouter.Properties;
using System.Media;

namespace GiauTM.CSharp.TikiRouter
{
    public static class Ultis
    {
        public static void playAudio(string name)
        {
            name = name.ToUpper();
            if (name != "NOTFOUND")
            {
                name = "_" + name.Replace("-", "_");
            }

            var stream = Resources.ResourceManager.GetStream(name);
            var player = new SoundPlayer(stream);
            player.Play();
        }
    }
}