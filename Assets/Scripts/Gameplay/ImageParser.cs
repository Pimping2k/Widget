using Cysharp.Threading.Tasks;
using MyPackage.Runtime.ServiceLocator_Core;
using UnityEngine;
using UnityEngine.Networking;

namespace Gameplay
{
    public class ImageParser : MonoBehaviour, IService
    {
        public Texture2D ParsedTexture { get; private set; }

        public async UniTask<Texture2D> GetParsedImage(string keyword = "nature")
        {
            int attempts = 3;
            while (attempts > 0)
            {
                ParsedTexture = await LoadImage(keyword);
                if (ParsedTexture != null) return ParsedTexture;

                attempts--;
                Debug.LogWarning($"[ImageParser] 503 или ошибка. Пробую еще раз... Осталось попыток: {attempts}");
                await UniTask.WaitForSeconds(1f);
            }
            return null;
        }

        private async UniTask<Texture2D> LoadImage(string keyword)
        {
            string randomId = Random.Range(1, 1000).ToString();
            string url = $"https://images.unsplash.com/photo-1541963463532-d68292c34b19?q=80&w=1024&sig={randomId}";

            using (var request = UnityWebRequestTexture.GetTexture(url))
            {
                try 
                {
                    await request.SendWebRequest().ToUniTask();

                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        var tex = DownloadHandlerTexture.GetContent(request);
                        tex.filterMode = FilterMode.Point;
                        return tex;
                    }
                }
                catch (UnityWebRequestException e)
                {
                    if (e.ResponseCode == 503) Debug.LogWarning("Сервер Unsplash временно недоступен (503).");
                    else Debug.LogError($"Ошибка сети: {e.Message}");
                }
                return null;
            }
        }
    }
}